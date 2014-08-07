using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TriangleIrcLib
{
    class IrcServerConnection
    {
        private TcpClient tcpClient;
        private NetworkStream tcpStream;
        private byte[] tcpStreamBuffer = new byte[4096];
        private MemoryStream ircMessagesBuffer;

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
        /// Connects to the specified port on the specified host.
        /// </summary>
        /// <param name="hostname">The DNS name of the remote host to which you intend to connect.</param>
        /// <param name="port">The port number of the remote host to which you intend to connect.</param>
        public void Connect(string hostname, int port)
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
            lock (tcpStream)
            {
                tcpStream.Write(message, 0, message.Length);
                byte[] CLFR = { 13, 10 };
                tcpStream.Write(CLFR, 0, 2);
            }
        }

        /// <summary>
        /// TcpClient.BeginRead callback which stores incoming data and pass complete IRC messages for further handling.
        /// </summary>
        /// <param name="result">Asynchronous operation status</param>
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
            int totalDataLenght = +tcpStreamDataLenght;
            byte[] data = new byte[totalDataLenght];

            ircMessagesBuffer.ToArray().CopyTo(data, 0);
            Array.Copy(tcpStreamBuffer, 0, data, ircMessagesBufferLenght, tcpStreamDataLenght);
            ircMessagesBuffer.SetLength(0);

            int ircMessageStart = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 13 && data[i + 1] == 10)
                {
                    byte[] ircMessageData = new byte[i - ircMessageStart];
                    Array.Copy(data, ircMessageStart, ircMessageData, 0, i - ircMessageStart);
                        throw new NotImplementedException("Message handling is not implemented yet.");
                    i += 2;
                    ircMessageStart = i;
                }
            }

            ircMessagesBuffer.Write(data, ircMessageStart, data.Length - ircMessageStart);

            tcpStream.BeginRead(tcpStreamBuffer, 0, tcpStreamBuffer.Length, new AsyncCallback(TcpStreamReadCallback), null);
        }
    }
}
