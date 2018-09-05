using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectdata
{
    public partial class StorageM : Form
    {
        public StorageM()
        {
            InitializeComponent();
        }
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        private void StorageM_Load(object sender, EventArgs e)
        {
            poppulate();
        }
        private void db()
        {
            String conn = "datasource = localhost; username = root; password=;database = dataproject";
            MySqlConnection dbcon = new MySqlConnection(conn);
            try
            {
                dbcon.Open();
                MessageBox.Show("connect Success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void poppulate()
        {
            String query = "SELECT * FROM materials";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void openconnection()
        {
            if (dbcon1.State == ConnectionState.Closed)
            {
                dbcon1.Open();
            }
        }

        public void closeconnection()
        {
            if (dbcon1.State == ConnectionState.Open)
            {
                dbcon1.Close();
            }
        }
        public void executemyquery(String query)
        {
            try
            {
                openconnection();
                command = new MySqlCommand(query, dbcon1);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }
                else
                {
                    MessageBox.Show("Query Not Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeconnection();
            }
        }
    }
}
