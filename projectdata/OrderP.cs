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
    public partial class OrderP : Form
    {
        public OrderP()
        {
            InitializeComponent();
        }
        String id;
        String status;
        int total;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void OrderP_Load(object sender, EventArgs e)
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

        private void update_Click(object sender, EventArgs e)
        {
            PaymentCustomer pc = new PaymentCustomer();
            pc.Show();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            OrderPInsert opi = new OrderPInsert();
            opi.Show();

        }
        
       
        public void poppulate()
        {
            String query = "SELECT order_product.id, customer.fname as customer, order_product.em_id, order_product.date_order, order_product.date_recive, order_product.price, order_product.unit, order_product.status FROM order_product natural join customer";
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

        private void buttomd_Click(object sender, EventArgs e)
        {
            OrderPUnit od = new OrderPUnit();
            od.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            int count1 = 0;
            String query = "select * from payment_customer where op_id = " + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
            if (status == "False" && count1 == count && int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString())==0)
            {
                String update = "UPDATE order_product set status = " + 1 + " Where id = " + id;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            status = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM order_product WHERE id= " + int.Parse(textBox1.Text);
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
    }
}
