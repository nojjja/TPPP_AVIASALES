using System.Windows;

namespace AVIASALES
{
    public partial class AdminLoginWindow : Window
    {
        public string UserName
        {
            get { return UsernameTextBox.Text; }
        }

        public string Password
        {
            get { return PasswordTextBox.Password; }
        }

        public AdminLoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
