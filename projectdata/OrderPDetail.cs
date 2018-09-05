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
    public partial class OrderPUnit : Form
    {
        public OrderPUnit()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        int unit;
        int price;
        int unitor;
        int priceor;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        public void poppulate()
        {
            String query = "SELECT * FROM detail_order_product";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillcombo()
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
            String query = "select * from product";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {

                    String type = myread.GetString("type");
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

        private void OrderPDetail_Load(object sender, EventArgs e)
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
                textBoxUnit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Something Wrong");
            }
            
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if(unit < int.Parse(textBoxUnit.Text))
            {
                MessageBox.Show("Not Enough Product");
            }
            else
            {
                String query = "select * from product where type = '" + comboBox2.Text + "'";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        price = myread.GetInt32("price");
                        unit = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String query1 = "select * from order_product where id = " + int.Parse(comboBox1.Text);
                command = new MySqlCommand(query1, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        priceor = myread.GetInt32("price");
                        unitor = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update = "UPDATE product SET unit = " + (unit - int.Parse(textBoxUnit.Text)) + " WHERE id =" + (comboBox2.SelectedIndex + 1);
                executemyquery(update);
                String update1 = "UPDATE order_product SET unit = " + (unitor+ int.Parse(textBoxUnit.Text)) +",price = "+(priceor+ ((int.Parse(textBoxUnit.Text) * price))) +" WHERE id =" + (comboBox1.SelectedIndex + 1);
                executemyquery(update1);
                String insert = "INSERT INTO detail_order_product(id,op_id,pd_id,price,unit) VALUES (" + textBoxid.Text + "," + comboBox1.Text + "," + (comboBox2.SelectedIndex + 1) + "," + (int.Parse(textBoxUnit.Text) * price) + "," + textBoxUnit.Text + ")";
                executemyquery(insert);
                poppulate();
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from product where type = '" + comboBox2.Text + "'";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    price = myread.GetInt32("price");
                    unit = myread.GetInt32("unit");
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from order_product where id = " + int.Parse(comboBox1.Text) ;
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    priceor = myread.GetInt32("price");
                    unitor = myread.GetInt32("unit");
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
        }


        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from product where type = '" + comboBox2.Text + "'";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        price = myread.GetInt32("price");
                        unit = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String query1 = "select * from order_product where id = " + int.Parse(comboBox1.Text);
                command = new MySqlCommand(query1, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        priceor = myread.GetInt32("price");
                        unitor = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update = "UPDATE product SET unit = " + (unit + int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString())) + " WHERE id =" + (comboBox2.SelectedIndex + 1);
                executemyquery(update);
                String update1 = "UPDATE order_product SET unit = " + (unitor - int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString())) + ",price = " + (priceor - int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString())) + " WHERE id =" + (comboBox1.SelectedIndex + 1);
                executemyquery(update1);
                String delete = "DELETE FROM detail_order_product WHERE id= " + int.Parse(textBoxid.Text);
                executemyquery(delete);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
           
        }
    }


}
