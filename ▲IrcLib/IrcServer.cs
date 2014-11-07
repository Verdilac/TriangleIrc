using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
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
        private readonly T ircCommandsHandler;
        private readonly Dictionary<string, MethodInfo> ircCommandMethods = new Dictionary<string, MethodInfo>();

        private TcpClient tcpClient;
        private NetworkStream tcpStream;
        private readonly byte[] tcpStreamBuffer = new byte[4096];
        private MemoryStream ircMessagesBuffer;
        private MemoryStream tcpSendBuffer;
        private bool isSending;        

        public event EventHandler Disconnected;
        protected virtual void OnDisconnect(EventArgs e)
        {
            if (Disconnected != null) Disconnected(this, e);
        }
        public event EventHandler Connected;
        protected virtual void OnConnected(EventArgs e)
        {
            if (Connected != null) Connected(this, e);
        }
        public event EventHandler ConnectFailed;
        protected virtual void OnConnectionFailed(EventArgs e)
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
            ircCommandsHandler = instantion;
            var t = typeof(T);

            var methodsInfo = t.GetMethods();
            foreach (var methodInfo in methodsInfo)
            {
                var attributes = (IrcCommandAttribute[]) methodInfo.GetCustomAttributes(typeof(IrcCommandAttribute));

                if (attributes == null)
                    continue;

                foreach (var attribute in attributes)
                {
                    if (ircCommandMethods.ContainsKey(attribute.Command))
                        throw new ArgumentException("Provided class type can only provide one function per IRC command");

                    ircCommandMethods.Add(attribute.Command, methodInfo);
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

            try
            {
                if (tcpClient == null)
                    tcpClient = new TcpClient();
            
                tcpClient.BeginConnect(hostname, port, ConnectCallback, null);
            }
            catch (Exception)
            {
                OnConnectionFailed(new EventArgs());
            }
            
        }

        public void Login(string pass, sbyte mode, string nickname, string username, string realname)
        {
            Send(String.Format("PASS {0}", String.IsNullOrEmpty(pass) ? "*" : pass));
            Send(String.Format("NICK {0}", nickname));
            Send(String.Format("USER {0} {1} * :{2}", username, mode, realname));
        }

        public void Disconnect()
        {
            if (!IsConnected)
                return;

            tcpClient.Client.Disconnect(true);
            tcpStream.Close();
            OnDisconnect(new EventArgs());
        }

        private void ConnectCallback(IAsyncResult result)
        {
            try
            {
                tcpClient.EndConnect(result);               

                ircMessagesBuffer = new MemoryStream();
                tcpSendBuffer = new MemoryStream();
                tcpStream = tcpClient.GetStream();

                OnConnected(new EventArgs());

                tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, TcpStreamReadCallback, null);
                
            }
            catch (Exception)
            {
                OnConnectionFailed(new EventArgs());
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
                byte[] crlf = { 13, 10 };
                tcpSendBuffer.Write(crlf, 0, 2);
            }

            WriteToTcpStream(null);
        }

        /// <summary>
        /// Send message to server.
        /// </summary>
        /// <param name="message">Message string.</param>
        public void Send(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);
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
                if (isSending || tcpSendBuffer.Length <= 0)
                    return;

                isSending = true;
                using (var ms = new MemoryStream(tcpSendBuffer.ToArray()))
                {
                    tcpSendBuffer.SetLength(0);
                    tcpStream.BeginWrite(ms.ToArray(), 0, (int)ms.Length, WriteToTcpStream, null); 
                }
            }
        }

        private void HandleMssageData(byte[] messageData)
        {
            // Parse message data.
            var messageString = Encoding.UTF8.GetString(messageData);
            var ircMsg = IrcMessage.Parse(messageString);

            // Use the default method if there is no method binded to the command.
            var mInfo = ircCommandMethods.ContainsKey(ircMsg.Command) ? ircCommandMethods[ircMsg.Command] : ircCommandMethods["default"];

            // Invoke command-binded method.
            var obj = new Object[] { ircMsg };

            mInfo.Invoke(ircCommandsHandler, obj);
        }

        private void TcpStreamReadCallback(IAsyncResult result)
        {
            var tcpStreamDataLenght = tcpStream.EndRead(result);

            if (tcpStreamDataLenght == 0)   // Triggers whenever server disconects.
            {
                tcpClient.Close();
                OnDisconnect(new EventArgs());
                return;
            }

            var ircMessagesBufferLenght = (int)ircMessagesBuffer.Length;
            var totalDataLenght = ircMessagesBufferLenght + tcpStreamDataLenght;
            var data = new byte[totalDataLenght];

            // Copy stored and received data in a new buffer.
            ircMessagesBuffer.ToArray().CopyTo(data, 0);
            Array.Copy(tcpStreamBuffer, 0, data, ircMessagesBufferLenght, tcpStreamDataLenght);

            ircMessagesBuffer.SetLength(0);

            // Look for the whole message and handle it.
            var ircMessageStart = 0;
            for (var i = 0; i < data.Length - 1; i++)
            {
                if (data[i] != 13 || data[i + 1] != 10)
                    continue;

                var messageData = new byte[i - ircMessageStart];
                Array.Copy(data, ircMessageStart, messageData, 0, i - ircMessageStart);
                HandleMssageData(messageData);
                i += 2;
                ircMessageStart = i;
            }

            // Save unfinished message.
            ircMessagesBuffer.Write(data, ircMessageStart, data.Length - ircMessageStart);

            tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, TcpStreamReadCallback, null);
        }
    }
}
