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
    public partial class OrderMInsert : Form
    {
        public OrderMInsert()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        
        String idemployee;
        String idvender;
        String idposition;
        int idom = 0;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

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
                    comboBox2.Items.Add(type);
                }
                dbcon1.Close();
            }
            catch (Exception e)
            {

            }
        }
        public void fillcombo1()
        {
            String query = "select * from vender";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    String type = myread.GetString("name");
                    comboBox3.Items.Add(type);
                }
                dbcon1.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
                }
                dbcon1.Close();
            }
            catch (Exception e1)
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
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                String insert = "INSERT INTO order_materials(id, em_id, vd_id, date_order, date_deliver,price,unit,status) VALUES (" + textBox1.Text + "," + (comboBox2.SelectedIndex + 1) + "," + (comboBox3.SelectedIndex + 1) + ",'" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "'," + 0 + "," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
            else
            {
                pkom();
                String insert = "INSERT INTO order_materials(id, em_id, vd_id, date_order, date_deliver,price,unit,status) VALUES (" + (idom + 1) + "," + (comboBox2.SelectedIndex + 1) + "," + (comboBox3.SelectedIndex + 1) + ",'" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "'," + 0 + "," + 0 + "," + 0 + ")";
                executemyquery(insert);
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

        private void OrderMInsert_Load(object sender, EventArgs e)
        {
           
        }
        public void pkom()
        {
            idom = 0;
            String query1 = "select * from order_materials";
            command = new MySqlCommand(query1, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    idom++;
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
        }
    }
}
