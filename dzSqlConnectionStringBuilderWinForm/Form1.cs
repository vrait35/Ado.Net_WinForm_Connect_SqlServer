using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dzSqlConnectionStringBuilderWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlQuery = "CREATE DATABASE MyDatabase14";
            string connectSqlServer = ConfigurationManager.ConnectionStrings["vrait34"].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectSqlServer);
            using (SqlConnection myConn = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(sqlQuery, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("БД создалась");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (SqlException )
                {
                    MessageBox.Show(" бд существует ");                   
                }

                finally
                {
                    myConn.Close();
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["vrait35"].ConnectionString;
            builder.ConnectionString = connectSqlServer;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "create table customers(" +
                    "id int primary key identity(1,1)," +
                    "name_customer varchar(50) not null," +
                    "mob_number varchar(15) ," +
                    "el_adress varchar(50),)";
                sql.Connection = connection;                
                try
                {
                    sql.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
