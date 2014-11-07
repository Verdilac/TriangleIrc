using System;
using System.Windows.Input;

namespace TriangleIrc
{
    /// <summary>
    /// Interaction logic for IrcChannelTabItem.xaml
    /// </summary>
    public partial class IrcChannelTabItem : IIrcChannel
    {
        public new string Name { get; set; }

        public event EventHandler<ChannelInputEventArgs> UserInput;
        protected virtual void OnUserInput(ChannelInputEventArgs e)
        {
            if (UserInput != null) UserInput(this, e);
        }

        public IrcChannelTabItem(string name)
        {
            InitializeComponent();
            Name = name;
            Header = Name;
        }

        public void Print(string message)
        {
            Dispatcher.Invoke(() => ChannelTextBlock.Text += message);
        }

        public void PrintLine(string message)
        {
            Dispatcher.Invoke(() => ChannelTextBlock.Text += message + '\n');
        }

        private void UserInputTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            OnUserInput(new ChannelInputEventArgs(UserInputTextBox.Text, this));
            UserInputTextBox.Text = String.Empty;
        }
    }
}
