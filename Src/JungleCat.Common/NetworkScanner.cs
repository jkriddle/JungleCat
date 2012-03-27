using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace JungleCat.Common
{
    public class NetworkScanner
    {

        /// <summary>
        /// Bind to this event to be notified when an unused port is found.
        /// </summary>
        public event EventHandler<OpenPortFoundArgs> OnOpenPortFound;

        /// <summary>
        /// Get a list of ports that are open on a specified IP.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public IList<int> GetOpenPorts(string endpointIP, int min, int max)
        {
            IList<int> open = new List<int>();

            for (int portIndex = min; portIndex < max; portIndex++)
            {
                bool isOpen = false;

                using (TcpClient client = new TcpClient())
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(endpointIP), portIndex);
                    try
                    {
                        client.Connect(endPoint);
                        open.Add(portIndex);
                        if (OnOpenPortFound != null)
                        {
                            OnOpenPortFound(this, new OpenPortFoundArgs(portIndex));
                        }
                        if (isOpen) open.Add(portIndex);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return open;
        }


        public IList<string> GetNetworkedDevices()
        {
            IList<string> endpoints = new List<string>();
            IPGlobalProperties network = IPGlobalProperties.GetIPGlobalProperties();
            foreach (TcpConnectionInformation connection in network.GetActiveTcpConnections())
            {
                endpoints.Add(connection.LocalEndPoint.Address.ToString());
            }
            return endpoints.Distinct().ToList();
        }


    }
}
