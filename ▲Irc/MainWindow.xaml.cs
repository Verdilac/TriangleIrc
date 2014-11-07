using System.Windows;

namespace TriangleIrc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void JoinServerButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new JoinServerWindow();
            if (dialog.ShowDialog() != true)
                return;

            var result = dialog.Result;
            var tab = new IrcServerTabItem(result);
            ServersTabControl.Items.Add(tab);
            tab.Focus();
            tab.Initialize();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
