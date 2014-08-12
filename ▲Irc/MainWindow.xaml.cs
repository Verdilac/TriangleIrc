using System;
using System.Windows;
using System.Windows.Input;
using TriangleIrcLib;

namespace TriangleIrc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IrcServer<MainWindow> ircServer;

        public MainWindow()
        {
            InitializeComponent();
            ircServer = new IrcServer<MainWindow>(this);
            ircServer.Connected += ircServer_Connected;

            textBlock.Text += "Connecting...\n";
            ircServer.Connect("irc.6irc.net");
        }

        void ircServer_Connected(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                textBlock.Text += "Connected.\n";
                ircServer.Send("PASS *");
                ircServer.Send("USER TriangleIrc 8 * :TriangleIrc");
                ircServer.Send("NICK jakubek");
            }));
        }

        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ircServer.Send(inputBox.Text);
                inputBox.Text = string.Empty;
            }
        }

        [IrcCommand("default")]
        public void Default(IrcMessage msg)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                textBlock.Text += msg.ToString() + '\n';
            }));
        }

        [IrcCommand("PING")]
        public void Ping(IrcMessage msg)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                ircServer.Send(new IrcMessage(null, "PONG", null, msg.Trailing));
            }));
        }
    }
}
