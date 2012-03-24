using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace JungleCat.Receiver
{
    public partial class BrowserView : Form
    {
        public BrowserView()
        {
            InitializeComponent();
        }

        public void DisplayImage(string imageUrl)
        {
            string html = System.IO.File.ReadAllText("image.html");
            html = html.Replace("[IMAGEURL]", imageUrl);
            createBrowser(html);
        }

        public void PlayVideo(string videoID)
        {
            string html = System.IO.File.ReadAllText("video.html");
            html = html.Replace("[VIDEOID]", videoID);
            createBrowser(html);
        }

        private void createBrowser(string html)
        {
            WebBrowser browser = new WebBrowser();
            browser.DocumentText = html;
            browser.Width = this.Width;
            browser.Height = this.Height;
            browser.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.Controls.Clear();
            this.Controls.Add(browser);
            this.BringToFront();
        }
    }
}
