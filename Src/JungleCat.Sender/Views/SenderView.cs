using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JungleCat.Sender.Presenters;
using JungleCat.Common;

namespace JungleCat.Sender
{
    public partial class SenderView : Form, ISenderView
    {

        #region Fields

        private SenderViewPresenter presenter;
        public event EventHandler SendButtonClick;
        public event EventHandler CloseButtonClick;
        public event EventHandler ScanForReceiverClick;
        public event EventHandler ScanPortsClick;

        #endregion

        #region Constructor

        public SenderView()
        {
            InitializeComponent();
            MainMenuStrip.Renderer = new MainToolStripRenderer();
            this.Load += new EventHandler(initializeView);
            this.presenter = new SenderViewPresenter(this);
        }

        #endregion

        #region Private Methods

        void initializeView(object sender, EventArgs e)
        {
            this.CloseButton.Click += new EventHandler(OnCloseButtonClicked);
            this.SendButton.Click += new EventHandler(OnSendButtonClicked);
            this.ScanPortsToolStripMenuItem.Click += new EventHandler(OnScanPortsClick);
            this.ScanForReceiverToolStripMenuItem.Click += new EventHandler(OnScanForReceiverClick);
        }

        #endregion

        #region Public Properties

        public string CommandText
        {
            get
            {
                return CommandTextBox.Text;
            }
            set
            {
                CommandTextBox.Text = value;
            }
        }

        public string EndpointIP
        {
            get
            {
                return EndpointTextBox.Text;
            }
            set
            {
                EndpointTextBox.Text = value;
            }
        }

        public int Port
        {
            get
            {
                return Int32.Parse(PortTextBox.Text);
            }
            set
            {
                PortTextBox.Text = value.ToString();
            }
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
                else
                {
                    LogTextBox.Text = value;
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// User submitted send command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSendButtonClicked(object sender, EventArgs e)
        {
            EventHandler sendButtonClicked = this.SendButtonClick;
            if (sendButtonClicked != null)
                sendButtonClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// Close button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            EventHandler closeButtonClicked = this.CloseButtonClick;
            if (closeButtonClicked != null)
                closeButtonClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// Scan for receiver button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnScanForReceiverClick(object sender, EventArgs e)
        {
            EventHandler scanForReceiverClick = this.ScanForReceiverClick;
            if (scanForReceiverClick != null)
            {
                scanForReceiverClick(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Scan for ports button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnScanPortsClick(object sender, EventArgs e)
        {
            EventHandler scanPortsClick = this.ScanPortsClick;
            if (scanPortsClick != null)
            {
                scanPortsClick(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Public Methods

        public void RefreshScreen()
        {
            this.Refresh();
        }

        public void CloseView()
        {
            this.Close();
            Application.Exit();
        }

        #endregion

        #region Drag/Move Form

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
            }
            base.WndProc(ref m);
        }

        #endregion

        private void SenderView_Load(object sender, EventArgs e)
        {
            MainMenuStrip.BackColor = Color.Black;
            MainMenuStrip.ForeColor = Color.Yellow;
        }

    }
}
