using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace User_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(!AllowLogin())
                return;

            DataTable dtData = Connect.Connect.DataTransport("select * from LstUser ");
            for(int i=0; i<dtData.Rows.Count;i++)
            {
                if(txtUser.Text.ToLower().Trim()==Convert.ToString(dtData.Rows[i]["UserName"]).ToLower().Trim())
                {
                    if (txtPassword.Password == Convert.ToString(dtData.Rows[i]["PassWord"]))
                        {
                        MessageBox.Show("Dang nhap thanh cong", "Chuc mung", MessageBoxButton.OK, MessageBoxImage.Information);
                        Menu m = new Menu();
                        m.Show();
                        this .Close();
                        return;
                        }
                    else
                        {
                        MessageBox.Show("Sai PassWord", "Eror", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtPassword.Focus();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Sai user name", "Eror", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUser.Focus();
                    return;
                }
            }    

        }
        private bool AllowLogin()
        {
            if(txtUser.Text.Trim() =="")
            {
                MessageBox.Show("Ban chua nhap user name", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUser.Focus();
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
