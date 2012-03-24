﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JungleCat.Common
{
    public class CommandReceivedEventArgs : EventArgs
    {

        public string CommandText { get; set; }

        public CommandReceivedEventArgs(string commandText)
        {
            CommandText = commandText;
        }

    }

}
