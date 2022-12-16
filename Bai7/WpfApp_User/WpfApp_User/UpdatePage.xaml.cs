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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        Db_UserContext db = new Db_UserContext();
        int ID;

       
        public UpdatePage(int uID)
        {
            InitializeComponent();
            ID = uID;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            User updateUser = (from u in db.Users
                               where u.UserId == ID
                               select u).Single();
            updateUser.UserName = txtUserName.Text;
            updateUser.Password = txtPassword.Password.ToString();
            updateUser.Email = txtEmail.Text;
            updateUser.Age = int.Parse(txtAge.Text);
            updateUser.Gender = bool.Parse(txtGender.Text);
            updateUser.GroupId = int.Parse(txtGroupID.Text);
            updateUser.Status = bool.Parse(txtStatus.Text);

            db.SaveChanges();
            MainWindow.datagrid.ItemsSource = db.Users.ToList();
            this.Hide();
        }
    }
}
