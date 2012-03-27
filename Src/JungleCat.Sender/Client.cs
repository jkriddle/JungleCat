using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace JungleCat.Sender
{
    /// <summary>
    /// Simple TCP endpoint client to send a command to the listening server.
    /// </summary>
    public class Client
    {
        public event EventHandler<ResponseReceivedEventArgs> OnResponseReceived;

        private TcpClient server;
        private string endpointIP;
        private int port;
        private Thread messageThread;
        private string lastResponse;

        public Client(string endpointIP, int port)
        {
            this.endpointIP = endpointIP;
            this.port = port;
        }

        public void ReceiveMessages()
        {
            /*StreamReader srReceiver = new StreamReader(server.GetStream());
            string response = srReceiver.ReadLine();
            if (OnResponseReceived != null)
            {
                OnResponseReceived(this, new ResponseReceivedEventArgs(response));
            }*/
        }

        public void CloseConnection()
        {
            // @TODO I think this is bad to do (calling Abort)
            messageThread.Abort();
            messageThread.Join();
        }

        /// <summary>
        /// Send a command to the server.
        /// </summary>
        /// <param name="sendCommand"></param>
        public void SendCommand(string sendCommand)
        {
            string reponse = String.Empty;

            // Connect to server if not already connected.
            if (server == null)
            {
                server = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(endpointIP), port);
                server.Connect(serverEndPoint);

                 
                messageThread = new Thread(new ThreadStart(ReceiveMessages));
                messageThread.IsBackground = true;
                messageThread.Start();
            }

            NetworkStream clientStream = server.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(sendCommand);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
    }
}
