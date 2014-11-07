using System;
using TriangleIrcLib;
using TriangleIrcLib.Response;

namespace TriangleIrc
{
    /// <summary>
    /// Interaction logic for IrcServerTabItem.xaml
    /// </summary>
    public partial class IrcServerTabItem
    {
        public IrcServer<IrcServerTabItem> IrcServer { get; private set; }
        public IrcServerData Data { get; private set; }

        private IrcChannelTabItem metaChannel;
        private int nickFailureCount;

        public IrcServerTabItem(IrcServerData data)
        {
            Data = data;

            InitializeComponent();
            Header = Data.ServerName;
            metaChannel = new IrcChannelTabItem(Data.ServerName);
            metaChannel.UserInput += ChannelUserInput;
            ChannelsTabControl.Items.Add(metaChannel);
            metaChannel.Focus();
        }

        void ChannelUserInput(object sender, ChannelInputEventArgs e)
        {
            if (!e.Channel.Equals(metaChannel) && e.Text[0] != '/')
            {
                IrcServer.Send(new IrcMessage(null, "PRIVMSG", new []{ e.Channel.Name }, e.Text));
            }
            else
                IrcServer.Send(e.Text);
        }

        public void Initialize()
        {
            IrcServer = new IrcServer<IrcServerTabItem>(this);
            IrcServer.Connected += IrcServer_Connected;
            IrcServer.ConnectFailed += IrcServer_ConnectFailed;
            IrcServer.Disconnected += IrcServer_Disconnected;

            IrcServer.Connect(Data.ServerAddress, Data.ServerPort);
        }

        private void IrcServer_Disconnected(object sender, EventArgs e)
        {
            metaChannel.PrintLine("Disconected.");
        }

        private void IrcServer_ConnectFailed(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                metaChannel.PrintLine("Connection Failed. Retrying...");
                IrcServer.Connect("irc.rizon.net");
            });
        }

        private void IrcServer_Connected(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                metaChannel.PrintLine("Connected.");
                IrcServer.Login(Data.ServerPassword, 8, Data.Nickname, Data.Username, Data.Realname);
            });
        }

        [IrcCommand("default")]
        public void Default(IrcMessage msg)
        {
            metaChannel.PrintLine(msg.ToString());
        }

        [IrcCommand("PING")]
        public void Ping(IrcMessage msg)
        {
            Dispatcher.Invoke(() => IrcServer.Send(new IrcMessage(null, "PONG", null, msg.Trailing)));
        }


        [IrcCommand(IrcError.ERR_NICKNAMEINUSE)]
        [IrcCommand(IrcError.ERR_NICKCOLLISION)]
        [IrcCommand(IrcError.ERR_ERRONEUSNICKNAME)]
        public void NickError(IrcMessage msg)
        {
            Dispatcher.Invoke(() => metaChannel.PrintLine(msg.ToString()));
            nickFailureCount++;
            var nick = Data.Nickname + nickFailureCount;
            Dispatcher.Invoke(() => IrcServer.Login(Data.ServerPassword, 8, nick, Data.Username, Data.Realname));
        }

        [IrcCommand("NOTICE")]
        public void Notice(IrcMessage msg)
        {
            Dispatcher.Invoke(() => metaChannel.PrintLine(msg.Trailing));
        }

        [IrcCommand("JOIN")]
        public void Join(IrcMessage msg)
        {
            Dispatcher.Invoke(() =>
            {
                var channel = new IrcChannelTabItem(msg.Trailing);
                channel.UserInput += ChannelUserInput;
                ChannelsTabControl.Items.Add(channel);
                channel.Focus();
                channel.PrintLine("Now talking on " + channel.Name);
            });
        }
    }
}
