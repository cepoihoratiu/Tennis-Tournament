using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TennisTournament.Model.Repository
{
    public class Repository
    {
        MySqlConnection mySqlConnection = new MySqlConnection("server=127.0.0.1; port=3306; user=root; database=tenis; password=new_password");
        public Repository()
        {
            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open error:" + ex);
            }
        }

        public MySqlConnection GetConnection()
        {
            return mySqlConnection;
        }

        public void CloseConnection()
        {
            mySqlConnection.Close();
        }
    }
}
