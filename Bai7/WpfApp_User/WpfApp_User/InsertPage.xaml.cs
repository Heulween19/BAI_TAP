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
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        Db_UserContext db = new Db_UserContext();

        public InsertPage()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Password.ToString(),
                Email = txtEmail.Text,
                Age = int.Parse(txtAge.Text),
                Gender= bool.Parse(txtGender.Text),
                GroupId=int.Parse(txtGroupID.Text),
                Status = bool.Parse(txtStatus.Text),
            };
            db.Users.Add(user);
            db.SaveChanges();
            MainWindow.datagrid.ItemsSource = db.Users.ToList();
            this.Hide();


        }
    }
}
