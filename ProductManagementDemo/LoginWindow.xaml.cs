using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Services;

namespace ProductManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IAccountService accountService;

        public LoginWindow()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string accountID = txtUser.Text.Trim();
            string password = txtPass.Password.Trim();

            if (string.IsNullOrEmpty(accountID) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Account ID and Password!", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var account = accountService.GetAccountById(accountID);

            if (account != null && account.MemberPassword == password)
            {
                ProductManagementDemo.MainWindow mainWindow = new ProductManagementDemo.MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Account ID or Password!", "Login Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                txtPass.Clear();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
