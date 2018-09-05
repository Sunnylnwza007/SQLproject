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
    public partial class OrderM : Form
    {
        public OrderM()
        {
            InitializeComponent();
        }
        int total;
        int price;
        String id,status;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void OrderM_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            OrderMInsert omi = new OrderMInsert();
            omi.Show();
        }

        private void buttomP_Click(object sender, EventArgs e)
        {
            PaymentMaterial pm = new PaymentMaterial();
            pm.Show();
        }
        public void poppulate()
        {
            String query = "SELECT order_materials.id, employee.fname as employee, order_materials.vd_id, order_materials.date_order, order_materials.date_deliver, order_materials.price, order_materials.unit, order_materials.status FROM order_materials natural join employee";
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

        private void button3_Click(object sender, EventArgs e)
        {
            OrderMDetail od = new OrderMDetail();
            od.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            total = 0;
            String query = "select * from payment_order_materials where om_id = " + id;
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    if (myread.GetInt32("status") == 1)
                    {
                        total += myread.GetInt32("amount");
                    } 
                }
                dbcon1.Close();
            }
            catch (Exception e1)
            {

            }
            if (status == "False" && total >= price)
            {
                String update = "UPDATE order_materials set status = " + 1 + " Where id = " + id;
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
                    MessageBox.Show("Payment Not Yet");
                }

            }
            poppulate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM order_materials WHERE id= " + int.Parse(textBox1.Text);
                executemyquery(delete);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            poppulate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                status = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                price = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something Wrong");
            }
          
        }
    }
}
