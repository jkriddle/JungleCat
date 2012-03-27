using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JungleCat.Sender
{
    public class ResponseReceivedEventArgs : EventArgs
    {

        public string ResponseText { get; set; }

        public ResponseReceivedEventArgs(string responseText)
        {
            ResponseText = responseText;
        }

    }

}
