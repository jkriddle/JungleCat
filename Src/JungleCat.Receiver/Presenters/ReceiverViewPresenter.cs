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
            InitServer();
        }

        public void InitServer()
        {
            if (ConfigurationManager.AppSettings["Port"] != null)
            {
                port = Int32.Parse(ConfigurationManager.AppSettings["Port"]);
            }
            view.Log += "Forcibly starting server on port: " + port.ToString() + Environment.NewLine;

            // Initialize server. If port is "0" one is automatically assigned.
            server = new Server(port);
            server.ConnectionError += new EventHandler(server_ConnectionError);
            server.CommandReceived += new EventHandler<CommandReceivedEventArgs>(OnCommandReceived);
        }

        void server_ConnectionError(object sender, EventArgs e)
        {
            view.Log += "Error connecting on " + port + Environment.NewLine;
            port++;
            InitServer();
        }

        private void OnCommandReceived(object sender, CommandReceivedEventArgs args)
        {
            view.Log += "Message received: " + args.CommandText + Environment.NewLine;
            ProcessCommand(args.CommandText);
        }

        /// <summary>
        /// Handle received command
        /// </summary>
        /// <param name="command"></param>
        public void ProcessCommand(string command)
        {
            string[] parameters = command.Split(' ');
            if (parameters.Count() < 2) return;

            string pCommand = parameters[0];
            string[] pSubjects = parameters.Skip(1).Take(parameters.Count() - 1).ToArray();
            string subjectString = String.Join(" ", pSubjects);

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
                ((Form)view).Invoke(new MethodInvoker(delegate
                {
                    view.Say(subjectString);
                }));
            }
        }

    }
}
