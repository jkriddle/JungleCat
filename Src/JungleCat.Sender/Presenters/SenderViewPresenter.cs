using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JungleCat.Common;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace JungleCat.Sender.Presenters
{
    public class SenderViewPresenter
    {
        private ISenderView view;
        private Client client;

        public SenderViewPresenter(ISenderView view)
        {
            this.view = view;
            subscribeViewToEvents();
        }

        private void initClient()
        {
            client = new Client(view.EndpointIP, view.Port);
            client.OnResponseReceived += new EventHandler<ResponseReceivedEventArgs>(OnResponseReceived);
        }

        void OnResponseReceived(object sender, ResponseReceivedEventArgs e)
        {
            view.Log += "Response: " + e.ResponseText;
        }

        private void subscribeViewToEvents()
        {
            this.view.CloseButtonClick += OnCloseButtonClick;
            this.view.SendButtonClick += OnSendButtonClick;
            this.view.ScanForReceiverClick += OnScanForReceiverClick;
            this.view.ScanPortsClick += OnScanPortsClick;
        }

        void OnScanForReceiverClick(object sender, EventArgs e)
        {
            view.Log += "Scanning for receivers..." + Environment.NewLine;

            Thread scannerThread = new Thread(new ThreadStart(() =>
            {
                NetworkScanner scanner = new NetworkScanner();
                scanner.OnOpenPortFound += new EventHandler<OpenPortFoundArgs>(scanner_OnOpenPortFound);
                IList<string> endpoints = scanner.GetNetworkedDevices();
                view.Log += endpoints.Count + " devices found:" + Environment.NewLine;
                foreach (string endpoint in endpoints)
                {
                    view.Log += endpoint.ToString() + Environment.NewLine;
                }
            }));
            scannerThread.IsBackground = true;
            scannerThread.Start();

        }

        void scanner_OnOpenPortFound(object sender, OpenPortFoundArgs e)
        {
            view.Log += e.Port.ToString() + Environment.NewLine;
            view.RefreshScreen();
        }

        void OnScanPortsClick(object sender, EventArgs e)
        {
            view.Log += "Scanning for open port on " + view.EndpointIP + ". This may take a few minutes..." + Environment.NewLine;

            Thread scannerThread = new Thread(new ThreadStart(() =>
            {
                NetworkScanner scanner = new NetworkScanner();
                IList<int> openPorts = scanner.GetOpenPorts(view.EndpointIP, 2999, 3001);
                view.Log += "Found " + openPorts.Count + " open ports:" + Environment.NewLine;
                foreach (int openPort in openPorts)
                {
                    view.Log += openPort + Environment.NewLine;
                }
            }));
            scannerThread.IsBackground = true;
            scannerThread.Start();
        }

        void OnCloseButtonClick(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.CloseConnection();
            }
            view.CloseView();
        }

        void OnSendButtonClick(object sender, EventArgs e)
        {
            initClient();
            view.Log += view.CommandText + ": ";
            try
            {
                view.Log += "Sending command...";
                client.SendCommand(view.CommandText);
                view.Log += "success.";
            }
            catch (SocketException ex)
            {
                view.Log += "failed: " + ex.Message;
            }
            view.Log += Environment.NewLine;
            view.CommandText = String.Empty;
        }

    }
}
