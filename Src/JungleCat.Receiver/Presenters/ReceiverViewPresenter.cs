using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JungleCat.Common;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Configuration;

namespace JungleCat.Receiver.Presenters
{
    public class ReceiverViewPresenter
    {
        private IReceiverView view;
        private Server server;
        private int port;

        public ReceiverViewPresenter(IReceiverView view)
        {
            this.view = view;
            this.port = Int32.Parse(ConfigurationManager.AppSettings["Port"]);
            initServer();
        }

        private void initServer()
        {
            server = new Server(port);
            server.CommandReceived += new EventHandler<CommandReceivedEventArgs>(OnCommandReceived);
        }

        private void OnCommandReceived(object sender, CommandReceivedEventArgs e)
        {
            view.Log = "Message received: " + e.CommandText;
            ProcessCommand(e.CommandText);
        }

        public void ProcessCommand(string command)
        {
            string[] parameters = command.Split(' ');
            if (parameters.Count() < 2) return;

            string pCommand = parameters[0];
            string[] pSubjects = parameters.Skip(1).Take(parameters.Count() - 1).ToArray();

            // Play video
            if (pCommand == "youtube")
            {
                ((Form)view).Invoke(new MethodInvoker(delegate
                {
                    view.PlayVideo(pSubjects[0]);
                }));
            }

            // Show image (by URL)
            if (pCommand == "image")
            {
                ((Form)view).Invoke(new MethodInvoker(delegate
                {
                    view.DisplayImage(pSubjects[0]);
                }));
            }

            // Alert box
            if (pCommand == "say")
            {
                string message = String.Join(" ", pSubjects);
                ((Form)view).Invoke(new MethodInvoker(delegate
                {
                    view.Say(message);
                }));
            }
        }

    }
}
