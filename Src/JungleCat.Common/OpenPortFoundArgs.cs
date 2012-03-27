using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JungleCat.Common
{
    public class OpenPortFoundArgs : EventArgs
    {

        public int Port { get; set; }

        public OpenPortFoundArgs(int port)
        {
            Port = port;
        }

    }

}
