using System;

namespace TriangleIrc
{
    public class ChannelInputEventArgs : EventArgs
    {
        public string Text { get; set; }
        public IIrcChannel Channel { get; set; }

        public ChannelInputEventArgs(string text, IIrcChannel channel)
        {
            Text = text;
            Channel = channel;
        }
    }
}
