using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JungleCat.Receiver.Presenters;
using System.Threading;

namespace JungleCat.Receiver
{
    public partial class ReceiverView : Form, IReceiverView
    {
        private ReceiverViewPresenter presenter;

        public ReceiverView()
        {
            InitializeComponent();
            this.presenter = new ReceiverViewPresenter(this);
        }

        public string Log
        {
            get
            {
                return LogTextBox.Text;
            }
            set
            {
                if (LogTextBox.InvokeRequired)
                {
                    LogTextBox.Invoke(new MethodInvoker(delegate
                    {
                        LogTextBox.Text = value;
                    }));
                }
            }
        }

        public void PlayVideo(string videoID)
        {
            BrowserView browser = new BrowserView();
            browser.PlayVideo(videoID);
            browser.Show();
            browser.BringToFront();
        }

        public void DisplayImage(string imageUrl)
        {
            BrowserView browser = new BrowserView();
            browser.DisplayImage(imageUrl);
            browser.Show();
            browser.BringToFront();
        }

        public void Say(string message)
        {
            this.BringToFront();
            MessageBox.Show(message);
        }

    }
}
