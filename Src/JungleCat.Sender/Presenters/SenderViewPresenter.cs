using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JungleCat.Common;
using System.Net.Sockets;

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
            initClient();
        }

        private void initClient()
        {
            client = new Client(view.EndpointIP, view.Port);
        }

        private void subscribeViewToEvents()
        {
            this.view.CloseButtonClick += OnCloseButtonClick;
            this.view.SendButtonClick += OnSendButtonClick;
        }

        void OnCloseButtonClick(object sender, EventArgs e)
        {
            view.CloseView();
        }

        void OnSendButtonClick(object sender, EventArgs e)
        {
            view.Log += view.CommandText + ": ";
            try
            {
                view.Log += "sending command...";
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
