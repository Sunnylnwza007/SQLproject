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
    public partial class Deliver : Form
    {

        public Deliver()
        {
            InitializeComponent();
        }
        String status;
        String id;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void Car_Load(object sender, EventArgs e)
        {
            poppulate();
        }
        private void db()
        {
            String conn = "datasource = localhost;port = 3306; username = root; password=;database = dataproject";
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
            String query = "SELECT deliver.id, deliver.car_id, employee.fname as employee, deliver.date, deliver.distance, deliver.status FROM deliver natural join employee";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void car_Click(object sender, EventArgs e)
        {
            Car c = new Car();
            c.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            status = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
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

        private void button2_Click(object sender, EventArgs e)
        {

            int count = 0;
            int count1 = 0;
            String query = "select * from detail_deliver where de_id = " + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    count++;
                    if (myread.GetInt32("status") == 1)
                    {
                        count1++;
                    }
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
            if (status == "False" && count1 == count)
            {
                String update = "UPDATE deliver set status = " + 1 + " Where id = " + int.Parse(id);
                executemyquery(update);
                MessageBox.Show("Status Update");
            }
            else
            {
                if (status != "False")
                {

                }
                else
                {
                    MessageBox.Show("Delivery Not Yet");
                }
               
            }
            poppulate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeliverInsert di = new DeliverInsert();
            di.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeliverDetail dd = new DeliverDetail();
            dd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            poppulate();
        }
    }
}
