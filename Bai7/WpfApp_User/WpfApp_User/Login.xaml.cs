using Google.Apis.Admin.Directory.directory_v1.Data;
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
using WpfApp_User.Models;

namespace WpfApp_User
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Db_UserContext db = new Db_UserContext();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!AllowLogin())
                return;

            var p = db.Users.ToList();
            var userDetail = p.Where(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Password).SingleOrDefault();
            if(userDetail == null)
            {
                MessageBox.Show("Sai username hoac password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUserName.Focus();

            }
            else
            {
                MainWindow m = new MainWindow();
                m.Show();
                this.Hide();
            }


        }
        private bool AllowLogin()
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Ban chua nhap user name", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Ban chua nhap  password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

    }
}
