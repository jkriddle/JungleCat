using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace JungleCat.Common
{
    /// <summary>
    /// TCP server implementation
    /// </summary>
    public class Server
    {
        private TcpClient tcpClient;
        private NetworkStream clientStream;
        private TcpListener tcpListener;
        private Thread listenThread;

        /// <summary>
        /// Event to run after message has been received successfully.
        /// </summary>
        public event EventHandler<CommandReceivedEventArgs> CommandReceived;

        public Server(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        /// <summary>
        /// Thread to listen for network activity.
        /// </summary>
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                // blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                // create a thread to handle communication 
                // with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        /// <summary>
        /// Take action when a client communication has been received.
        /// </summary>
        /// <param name="client"></param>
        private void HandleClientComm(object client)
        {
            tcpClient = (TcpClient)client;
            clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    // blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    // a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    // the client has disconnected from the server
                    break;
                }

                // message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                string commandText = encoder.GetString(message, 0, bytesRead);
                System.Diagnostics.Debug.WriteLine(commandText);

                if (CommandReceived != null)
                {
                    CommandReceived(this, new CommandReceivedEventArgs(commandText));
                }

                // send response to client
                byte[] buffer = encoder.GetBytes("MESSAGE RECEIVED");

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }

            tcpClient.Close();
        }

    }
}
