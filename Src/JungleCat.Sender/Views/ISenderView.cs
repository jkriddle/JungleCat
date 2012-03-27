using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JungleCat.Sender.Presenters
{
    public interface ISenderView
    {
        event EventHandler CloseButtonClick;
        event EventHandler SendButtonClick;
        event EventHandler ScanForReceiverClick;
        event EventHandler ScanPortsClick;

        string CommandText { get; set; }
        string EndpointIP { get; set; }
        int Port { get; set; }
        string Log { get; set; }

        void CloseView();
        void RefreshScreen();
    }
}
