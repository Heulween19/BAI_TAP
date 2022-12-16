using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfApp_User.Models;

namespace WpfApp_User
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Db_UserContext db = new Db_UserContext();
        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            var user = db.Users.ToList();
            myDataGrid.ItemsSource = user;
            datagrid = myDataGrid;
        } 

            private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertPage i = new InsertPage();
            i.ShowDialog();



        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int ID = (myDataGrid.SelectedItem as User).UserId;
            
            UpdatePage up = new UpdatePage(ID);
            up.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int ID = (myDataGrid.SelectedItem as User).UserId;
            var delUser = db.Users.Where(x => x.UserId == ID).Single();
            db.Users.Remove(delUser);
            db.SaveChanges();
            myDataGrid.ItemsSource= db.Users.ToList();  


        }
    }
}
