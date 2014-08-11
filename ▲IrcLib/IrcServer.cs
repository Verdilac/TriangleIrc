using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace TriangleIrcLib
{
    /// <summary>
    /// Represent IRC server connection.
    /// </summary>
    /// <typeparam name="T">The type of class containing methods assigned with TriangleIrcLib.IrcCommandAtribute.</typeparam>
    public class IrcServer<T> where T : class
    {
        private T ircCommandsHandler;
        private Dictionary<string, MethodInfo> ircCommandMethods = new Dictionary<string, MethodInfo>();

        private TcpClient tcpClient;
        private NetworkStream tcpStream;
        private byte[] tcpStreamBuffer = new byte[4096];
        private MemoryStream ircMessagesBuffer;
        private MemoryStream tcpSendBuffer;
        private bool isSending = false;        

        public event EventHandler Disconnected;
        protected virtual void OnDisconnect(EventArgs e = null)
        {
            if (Disconnected != null) Disconnected(this, e);
        }
        public event EventHandler Connected;
        protected virtual void OnConnected(EventArgs e = null)
        {
            if (Connected != null) Connected(this, e);
        }
        public event EventHandler ConnectFailed;
        protected virtual void OnConnectionFailed(EventArgs e = null)
        {
            if (ConnectFailed != null) ConnectFailed(this, e);
        }

        /// <summary>
        /// Gets a value indicating if IrcServerConnection instance is connected to server.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return tcpClient != null && tcpClient.Connected;
            }
        }

        /// <summary>
        /// Initializes a new instance of TriangleIrcLib.IrcServerConnection supplied by T class instance.
        /// </summary>
        /// <param name="instantion"></param>
        public IrcServer(T instantion) 
        {
            this.ircCommandsHandler = instantion;
            Type t = typeof(T);

            MethodInfo[] methodsInfo = t.GetMethods();
            foreach (MethodInfo mInfo in methodsInfo)
            {
                IrcCommandAttribute attribute = (IrcCommandAttribute)mInfo.GetCustomAttribute(typeof(IrcCommandAttribute));

                if (attribute == null)
                    continue;
                else
                {
                    ircCommandMethods.Add(attribute.Command, mInfo);
                }
            }

            if (!ircCommandMethods.ContainsKey("default"))
                throw new ArgumentException("Provided class type does not provide method assigned with \"default\" TriangleIrcLib.IrcCommandAtribute.");
        }

        /// <summary>
        /// Connects to the specified port on the specified host.
        /// </summary>
        /// <param name="hostname">The DNS name of the remote host to which you intend to connect.</param>
        /// <param name="port">The port number of the remote host to which you intend to connect.</param>
        public void Connect(string hostname, int port = 6667)
        {
            if (IsConnected)
                throw new InvalidOperationException("Client is already connected to server.");

            if (tcpClient == null)
                tcpClient = new TcpClient();

            tcpClient.BeginConnect(hostname, port, ConnectCallback, null);
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                tcpClient.Client.Disconnect(true);
                tcpStream.Close();
                OnDisconnect();
            }
        }

        private void ConnectCallback(IAsyncResult result)
        {
            try
            {
                tcpClient.EndConnect(result);

                ircMessagesBuffer = new MemoryStream();
                tcpSendBuffer = new MemoryStream();
                tcpStream = tcpClient.GetStream();

                tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, new AsyncCallback(TcpStreamReadCallback), null);
                OnConnected();
            }
            catch (Exception)
            {
                OnConnectionFailed();
            }
        }

        /// <summary>
        /// Send UTF-8 bytes to server.
        /// </summary>
        /// <param name="message">UTF-8 encoded bytes.</param>
        public void Send(byte[] message)
        {
            lock (tcpSendBuffer)
            {
                tcpSendBuffer.Write(message, 0, message.Length);
                byte[] CRLF = { 13, 10 };
                tcpSendBuffer.Write(CRLF, 0, 2);
            }

            WriteToTcpStream(null);
        }

        /// <summary>
        /// Send message to server.
        /// </summary>
        /// <param name="message">Message string.</param>
        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            Send(data);
        }

        /// <summary>
        /// Send messsage to server form TriangleIrcLib.IrcMessage instance.
        /// </summary>
        /// <param name="message">TriangleIrcLib.IrcMessage instance containing IRC message.</param>
        public void Send(IrcMessage message)
        {
            Send(message.ToString());
        }

        private void WriteToTcpStream(IAsyncResult result)
        {
            if (result != null)
            {
                tcpStream.EndWrite(result);
                lock (tcpSendBuffer)
                    isSending = false;
            }

            lock (tcpStream)
            {
                if (isSending)
                    return;

                if (tcpSendBuffer.Length > 0)
                {
                    isSending = true;
                    MemoryStream ms = new MemoryStream(tcpSendBuffer.ToArray());
                    tcpSendBuffer.SetLength(0);
                    tcpStream.BeginWrite(ms.ToArray(), 0, (int)ms.Length, WriteToTcpStream, null);                    
                }
            }
        }

        private void HandleMssageData(byte[] messageData)
        {
            // Parse message data.
            string messageString = Encoding.UTF8.GetString(messageData);
            IrcMessage ircMsg = IrcMessage.Parse(messageString);

            // Use the default method if there is no method binded to the command.
            MethodInfo mInfo;
            if (ircCommandMethods.ContainsKey(ircMsg.Command))
                mInfo = ircCommandMethods[ircMsg.Command];
            else
                mInfo = ircCommandMethods["default"];

            // Invoke command-binded method.
            Object[] obj = new Object[] { ircMsg };

            mInfo.Invoke(ircCommandsHandler, obj);
        }

        private void TcpStreamReadCallback(IAsyncResult result)
        {
            int tcpStreamDataLenght = tcpStream.EndRead(result);

            if (tcpStreamDataLenght == 0)   // Triggers whenever server disconects.
            {
                tcpClient.Close();
                OnDisconnect();
                return;
            }

            int ircMessagesBufferLenght = (int)ircMessagesBuffer.Length;
            int totalDataLenght = ircMessagesBufferLenght + tcpStreamDataLenght;
            byte[] data = new byte[totalDataLenght];

            // Copy stored and received data in a new buffer.
            ircMessagesBuffer.ToArray().CopyTo(data, 0);
            Array.Copy(tcpStreamBuffer, 0, data, ircMessagesBufferLenght, tcpStreamDataLenght);

            ircMessagesBuffer.SetLength(0);

            // Look for the whole message and handle it.
            int ircMessageStart = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 13 && data[i + 1] == 10)
                {
                    byte[] messageData = new byte[i - ircMessageStart];
                    Array.Copy(data, ircMessageStart, messageData, 0, i - ircMessageStart);
                    HandleMssageData(messageData);
                    i += 2;
                    ircMessageStart = i;
                }
            }

            // Save unfinished message.
            ircMessagesBuffer.Write(data, ircMessageStart, data.Length - ircMessageStart);

            tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, new AsyncCallback(TcpStreamReadCallback), null);
        }
    }
}
