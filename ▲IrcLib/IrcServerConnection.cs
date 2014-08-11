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
    public class IrcServerConnection<T> where T : class
    {

        private TcpClient tcpClient;
        private NetworkStream tcpStream;
        private byte[] tcpStreamBuffer = new byte[4096];
        private MemoryStream ircMessagesBuffer;

        private T ircCommandsHandler;
        private Dictionary<string, MethodInfo> ircCommandMethods = new Dictionary<string, MethodInfo>();

        public event EventHandler Disconnect;
        protected virtual void OnDisconnect(EventArgs e = null)
        {
            if (Disconnect != null) Disconnect(this, e);
        }

        /// <summary>
        /// Gets a value indicating if IrcServerConnection instance is connected to server.
        /// </summary>
        public bool Connected
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
        public IrcServerConnection(T instantion) 
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
            if (Connected)
                throw new InvalidOperationException("Client is already connected to server.");

            if (tcpClient == null)
                tcpClient = new TcpClient();

            IPEndPoint ipEndPoint = new IPEndPoint(Dns.GetHostAddresses(hostname)[0], port);

            tcpClient.Connect(ipEndPoint);

            ircMessagesBuffer = new MemoryStream();

            tcpStream = tcpClient.GetStream();
            tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, new AsyncCallback(TcpStreamReadCallback), null);
        }

        /// <summary>
        /// Send UTF-8 bytes to server.
        /// </summary>
        /// <param name="message">UTF-8 encoded bytes.</param>
        public void Send(byte[] message)
        {
            // TODO: make it nonblocking
            lock (tcpStream)
            {
                tcpStream.Write(message, 0, message.Length);
                byte[] CLFR = { 13, 10 };
                tcpStream.Write(CLFR, 0, 2);
            }
        }

        private void HandleMssageData(byte[] messageData)
        {
            string messageString = Encoding.UTF8.GetString(messageData);
            IrcMessage message = IrcMessage.Parse(messageString);

            MethodInfo mInfo;
            if (ircCommandMethods.ContainsKey(message.Command))
                mInfo = ircCommandMethods[message.Command];
            else
                mInfo = ircCommandMethods["default"];

            Object[] obj = new Object[] { message };

            mInfo.Invoke(ircCommandsHandler, obj);
        }

        private void TcpStreamReadCallback(IAsyncResult result)
        {
            int tcpStreamDataLenght = tcpStream.EndRead(result);

            if (tcpStreamDataLenght == 0)   // Triggers whenever server disconects
            {
                tcpClient.Close();
                OnDisconnect();
                return;
            }

            int ircMessagesBufferLenght = (int)ircMessagesBuffer.Length;
            int totalDataLenght = ircMessagesBufferLenght + tcpStreamDataLenght;
            byte[] data = new byte[totalDataLenght];

            ircMessagesBuffer.ToArray().CopyTo(data, 0);
            Array.Copy(tcpStreamBuffer, 0, data, ircMessagesBufferLenght, tcpStreamDataLenght);
            ircMessagesBuffer.SetLength(0);

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

            ircMessagesBuffer.Write(data, ircMessageStart, data.Length - ircMessageStart);

            tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, new AsyncCallback(TcpStreamReadCallback), null);
        }
    }
}
