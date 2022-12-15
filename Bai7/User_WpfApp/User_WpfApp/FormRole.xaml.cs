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
using System.Windows.Shapes;

namespace User_WpfApp
{
    /// <summary>
    /// Interaction logic for FormRole.xaml
    /// </summary>
    public partial class FormRole : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I6S80K2\SQLEXPRESS;Initial Catalog=User;Persist Security Info=True;User ID=sa;Password=123456");
        public FormRole()
        {
            InitializeComponent();
            LoadDGV();
        }

        public void LoadDGV()
        {
            SqlCommand cmd = new SqlCommand("select * from Role", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dgvRole.ItemsSource = dt.DefaultView;
        }
    }
}
