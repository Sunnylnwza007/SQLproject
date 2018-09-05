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
    public partial class OrderPInsert : Form
    {
        public OrderPInsert()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        String idposition;
        String idcustomer;
        String idemployee;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void type_id_TextChanged(object sender, EventArgs e)
        {

        }

        public void fillcombo()
        {
            String query = "select * from customer";
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
            String query = "select * from employee";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    String type = myread.GetString("fname");
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

        private void OrderPInsert_Load(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String query = "select * from customer where fname = '" + comboBox1.Text + "'";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    idcustomer = myread.GetInt32("id").ToString();
                    textBox1.Text = idcustomer;
                }
                dbcon1.Close();
            }
            catch (Exception e1)
            {

            }
        }


        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String query = "select * from employee where fname = '" + comboBox2.Text + "'";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    idemployee = myread.GetInt32("id").ToString();
                    textBox2.Text = idemployee;
                }
                dbcon1.Close();
            }
            catch (Exception e1)
            {

            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (type_id.Text != "")
            {
                String insert = "INSERT INTO order_product(id, c_id, em_id, date_order, date_recive, price, unit, status) VALUES (" + type_id.Text + "," + (comboBox1.SelectedIndex + 1) + "," + (comboBox2.SelectedIndex + 1) + ",'" + dateTimePicker3.Text + "','" + dateTimePicker4.Text + "'," + 0 + "," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
            else
            {
                int idop = 0;
                String query = "select * from order_product";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        idop++;
                    }
                    dbcon1.Close();
                }
                catch (Exception e1)
                {

                }
                String insert = "INSERT INTO order_product(id, c_id, em_id, date_order, date_recive, price, unit, status) VALUES (" + (idop + 1) + "," + (comboBox1.SelectedIndex + 1) + "," + (comboBox2.SelectedIndex + 1) + ",'" + dateTimePicker3.Text + "','" + dateTimePicker4.Text + "'," + 0 + "," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
           
            
        }
    }
}
