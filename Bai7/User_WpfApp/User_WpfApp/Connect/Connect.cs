using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_WpfApp.Connect
{
    internal class Connect
    {
        private static string sConnect = @"Data Source=DESKTOP-I6S80K2\SQLEXPRESS;Initial Catalog = User; Persist Security Info=True;User ID = sa; Password=123456";
        private static SqlConnection con = null;

        public Connect()
        {
            OpenConnect();
        }

        private static void OpenConnect()
        {
            con = new SqlConnection(sConnect);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }    
        }
        public static DataTable DataTransport(string sSql)
        {
            OpenConnect();
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, con);

            DataTable dtData = new DataTable();
            dtData.Clear();
            adapter.Fill(dtData);
            return dtData;
        }
        public static int DataExecution(string sSql)
        {
            int iResult = 0;
            OpenConnect();
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }   
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sSql;
            iResult = cmd.ExecuteNonQuery();
            return iResult;


        }


    }
}
