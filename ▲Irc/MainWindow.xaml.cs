using System;
using System.Windows.Input;
using TriangleIrcLib;

namespace TriangleIrc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        readonly IrcServer<MainWindow> ircServer;

        public MainWindow()
        {
            InitializeComponent();
            ircServer = new IrcServer<MainWindow>(this);
            ircServer.Connected += ircServer_Connected;

            TextBlock.Text += "Connecting...\n";
            ircServer.Connect("irc.freenode.net");
        }

        void ircServer_Connected(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                TextBlock.Text += "Connected.\n";
                ircServer.Send("PASS *");
                ircServer.Send("USER TriangleIrc 8 * :TriangleIrc");
                ircServer.Send("NICK jakubek");
            });
        }

        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            ircServer.Send(InputBox.Text);
            InputBox.Text = string.Empty;
        }

        [IrcCommand("default")]
        public void Default(IrcMessage msg)
        {
            Dispatcher.Invoke(() =>
            {
                TextBlock.Text += msg.ToString() + '\n';
            });
        }

        [IrcCommand("PING")]
        public void Ping(IrcMessage msg)
        {
            Dispatcher.Invoke(() => ircServer.Send(new IrcMessage(null, "PONG", null, msg.Trailing)));
        }
    }
}
