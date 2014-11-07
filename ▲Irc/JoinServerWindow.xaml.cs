using System;
using System.Windows;

namespace TriangleIrc
{
    /// <summary>
    /// Interaction logic for JoinServerWindow.xaml
    /// </summary>
    public partial class JoinServerWindow
    {
        public IrcServerData Result{ get; private set; }

        public JoinServerWindow()
        {
            InitializeComponent();
            ServerName.Text = Properties.Settings.Default.ServerName;
            ServerAddress.Text = Properties.Settings.Default.ServerAddress;
            ServerPort.Text = Properties.Settings.Default.ServerPort.ToString();
            ServerPassword.Text = Properties.Settings.Default.ServerPassword;
            Nickname.Text = Properties.Settings.Default.Nickname;
            Username.Text = Properties.Settings.Default.Username;
            Realname.Text = Properties.Settings.Default.Realname;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Result = new IrcServerData
            {
                ServerName = ServerName.Text,
                ServerAddress = ServerAddress.Text,
                ServerPort = Int32.Parse(ServerPort.Text),
                ServerPassword = ServerPassword.Text,
                Nickname = Nickname.Text,
                Username = Username.Text,
                Realname = Realname.Text
            };
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
