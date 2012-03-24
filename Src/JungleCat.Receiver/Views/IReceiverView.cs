using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JungleCat.Receiver.Presenters
{
    public interface IReceiverView
    {
        string Log { get; set; }

        // Commands
        void DisplayImage(string imageUrl);
        void PlayVideo(string videoID);
        void Say(string message);
    }
}
