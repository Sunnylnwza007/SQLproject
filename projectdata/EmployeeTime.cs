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
    public partial class EmployeeTime : Form
    {
        int id;
        public EmployeeTime(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        public void poppulate()
        {
            String query = "SELECT * FROM job_detail where em_id = "+id;
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

        private void EmployeeTime_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeTimeInsert eti = new EmployeeTimeInsert();
            eti.Show();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            String update = "UPDATE  job_detail SET out_time= '" + textBox1.Text + "',hours='" + textBox2.Text +"' WHERE id = "+ int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            executemyquery(update);
            poppulate();
        }
    }
}
