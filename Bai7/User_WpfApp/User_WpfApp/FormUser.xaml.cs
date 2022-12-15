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
    /// Interaction logic for FormUser.xaml
    /// </summary>
    public partial class FormUser : Window
    {
        public FormUser()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I6S80K2\SQLEXPRESS;Initial Catalog=User;Persist Security Info=True;User ID=sa;Password=123456");
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from LstUser", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dgvUser.ItemsSource = dt.DefaultView;

        }



        private void btnExitUser_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }
        public bool IsValid()
        {
            if(txtUserName.Text==String.Empty)
            {
                MessageBox.Show("Name is Require", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("PassWord is Require", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtGroupID.Text == String.Empty)
            {
                MessageBox.Show("GroupID is Require", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void btnInsertUser_Click(object sender, RoutedEventArgs e)
        {
            if(IsValid())
            {
                
                SqlCommand cmd = new SqlCommand("Insert into LstUser Values (@UserName,@Password,@Birthday,@Address,@Email,@Age,@Gender,@GroupID,@Status)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password",txtPassword.Text);
                //cmd.Parameters.AddWithValue("@Bỉthday", txtBirthday.SelectedDate.Value);
                cmd.Parameters.AddWithValue("@Birthday",txtBirthday.DisplayDate);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@GroupID", txtGroupID.Text);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadGrid();
                MessageBox.Show("Successful","Saved",MessageBoxButton.OK,MessageBoxImage.Information);
                ClearData();

            }    
        }

        public void ClearData()
        {
            txtUserId.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            //txtBirthday.ClearValue();
            txtAddress.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            txtGender.Clear();
            txtGroupID.Clear();
            txtStatus.Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from LstUser where UserID = "+txtUserId.Text+" ",con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful","Deleted",MessageBoxButton.OK,MessageBoxImage.Information);
                con.Close();
                ClearData();
                LoadGrid();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not Deleted!" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update LstUser set UserName='"+txtUserName.Text+"',Password='"+txtPassword.Text+"',Birthday='"+txtBirthday.Text+"',Address='"+txtAddress.Text+"', Email= '"+txtEmail.Text+"',Age='"+txtAge.Text+"',Gender='"+txtGender.Text+"',GroupID='"+txtGroupID.Text +"',Status='"+txtStatus.Text+"' where UserID ='"+txtUserId.Text+"'  ",con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful","Updated",MessageBoxButton.OK,MessageBoxImage.Information);

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
                ClearData();
                LoadGrid();
            }

        }
    }
}
