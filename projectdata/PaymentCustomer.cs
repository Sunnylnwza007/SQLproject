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
    public partial class PaymentCustomer : Form
    {
        public PaymentCustomer()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        String id, status;
        int name;
        int remain;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        public void poppulate()
        {
            String query = "SELECT payment_customer.id, employee.fname as employee, payment_customer.op_id, payment_customer.date, payment_customer.round, payment_customer.type_payment, payment_customer.amount, payment_customer.remaining, payment_customer.Status FROM payment_customer natural join employee";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillcombo()
        {
            String query = "select * from employee";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {

                    String type = myread.GetString("fname");
                    comboBox1.Items.Add(type);
                }
                dbcon1.Close();
            }
            catch (Exception e)
            {

            }
        }
        public void fillcombo1()
        {
            String query = "select * from order_product";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {

                    String type = myread.GetString("id");
                    comboBox2.Items.Add(type);
                }
                dbcon1.Close();
            }
            catch (Exception e)
            {

            }
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

        private void PaymentCustomer_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) - 1;
                comboBox2.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) - 1;
                date.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBoxRound.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBoxType.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBoxAm.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                // textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                status = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something Wrong");
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from employee where fname = '" + comboBox1.Text + "'";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    name = myread.GetInt32("id");
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void insert_Click(object sender, EventArgs e)
        {
            String query = "select * from order_product where id = " + comboBox2.Text + "";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    remain = myread.GetInt32("price");
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
            String insert = "INSERT INTO payment_customer(id,em_id,op_id,date,round,type_payment,amount,remaining,status) VALUES (" + textBoxid.Text + "," + (comboBox1.SelectedIndex+1) + "," + comboBox2.Text + ",'" + date.Text + "'," + textBoxRound.Text + ",'" + textBoxType.Text + "'," + textBoxAm.Text + ","+(remain-int.Parse(textBoxAm.Text))+"," + 0 + ")";
            executemyquery(insert);
            String update = "UPDATE order_product set price = " + (remain - int.Parse(textBoxAm.Text)) + " Where id = " + comboBox2.Text;
            executemyquery(update);
            poppulate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (status == "False")
            {
                String update = "UPDATE payment_customer set status = " + 1 + " Where id = " + id;
                executemyquery(update);

            }
            poppulate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            String query = "select * from order_product where id = " + comboBox2.Text + "";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    remain = myread.GetInt32("price");
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
            String update = "UPDATE order_product set price = " + (remain +int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString()))+ " Where id = " + int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            executemyquery(update);
            String delete = "DELETE FROM payment_customer WHERE id= " + int.Parse(textBoxid.Text);
            executemyquery(delete);
            poppulate();
        }

    }
}
