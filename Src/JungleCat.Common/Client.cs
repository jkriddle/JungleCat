using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace JungleCat.Common
{
    /// <summary>
    /// Simple TCP endpoint client to send a command to the listening server.
    /// </summary>
    public class Client
    {

        private string endpointIP;
        private int port;

        public Client(string endpointIP, int port)
        {
            this.endpointIP = endpointIP;
            this.port = port;
        }

        /// <summary>
        /// Send a command to the server.
        /// </summary>
        /// <param name="sendCommand"></param>
        public void SendCommand(string sendCommand)
        {
            using (TcpClient client = new TcpClient())
            {

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(endpointIP), port);

                client.Connect(serverEndPoint);

                NetworkStream clientStream = client.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(sendCommand);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
        }
    }
}
