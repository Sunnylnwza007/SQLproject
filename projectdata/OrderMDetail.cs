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
    public partial class OrderMDetail : Form
    {
        public OrderMDetail()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        
        int unitold;
        int priceold;
        int unit;
        int price;
        int unit2;
        int price2;
        int unit3;
        int price3;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        public void poppulate()
        {
            String query = "SELECT * FROM detail_order_material";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillcombo()
        {
            String query = "select * from order_materials";
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
            String query = "select * from materials";
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

        private void OrderMDetail_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())-1;
                comboBox2.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString())-1;
                textBoxUnit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                unitold = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                priceold = price * unitold;
                textBox1.Text = unit.ToString();
                textBox2.Text = price.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something Wrong");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void insert_Click(object sender, EventArgs e)
        {
                try
                {
                    String insert = "INSERT INTO detail_order_material(id,om_id,m_id,price,unit) VALUES (" + textBoxid.Text + "," + comboBox1.Text + "," + (comboBox2.SelectedIndex + 1) + "," + (int.Parse(textBoxUnit.Text) * price) + "," + textBoxUnit.Text + ")";
                    executemyquery(insert);
                    String query = "select * from order_materials where id = " + int.Parse(comboBox1.Text);
                    command = new MySqlCommand(query, dbcon1);
                    try
                    {
                        dbcon1.Open();
                        myread = command.ExecuteReader();
                        while (myread.Read())
                        {
                            unit2 = myread.GetInt32("unit");
                            price2 = myread.GetInt32("price");
                        }
                        dbcon1.Close();

                    }
                    catch (Exception e1)
                    {

                    }

                String query1 = "select * from materials where id = " + (comboBox2.SelectedIndex + 1);
                command = new MySqlCommand(query1, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unit = myread.GetInt32("unit");
                        price = myread.GetInt32("price");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update = "UPDATE materials SET unit = " + (unit + int.Parse(textBoxUnit.Text)) + " WHERE id =" + (comboBox2.SelectedIndex + 1);
                executemyquery(update);
                String update1 = "UPDATE order_materials SET  price = " + (price2 + ((int.Parse(textBoxUnit.Text) * price))) + ",unit = " + (unit2+ int.Parse(textBoxUnit.Text)) + " WHERE id = " + int.Parse(comboBox1.Text) ;
                executemyquery(update1);
                poppulate();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Something Wrong");
                }
               
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from order_materials where id = " + int.Parse(comboBox1.Text);
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    unit2 = myread.GetInt32("unit");
                    price2 = myread.GetInt32("price");
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from materials where id = " + (comboBox2.SelectedIndex+1);
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    unit = myread.GetInt32("unit");
                    price = myread.GetInt32("price");
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
                String query = "select * from materials where id = " + (comboBox2.SelectedIndex + 1);
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unit = myread.GetInt32("unit");
                        price = myread.GetInt32("price");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update1 = "UPDATE materials SET unit = " + (unit - int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString())) + " WHERE id =" + (comboBox2.SelectedIndex + 1);
                executemyquery(update1);
                
                String query1 = "select * from order_materials where id = " + int.Parse(comboBox1.Text);
                command = new MySqlCommand(query1, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unit2 = myread.GetInt32("unit");
                        price2 = myread.GetInt32("price");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update2 = "UPDATE order_materials SET unit = '" + (unit2 - int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString())) + "',price = '" + (price2 - int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString())) + "' WHERE id = " + int.Parse(comboBox1.Text) ;
                executemyquery(update2);
                String delete = "DELETE FROM detail_order_material WHERE id= " + int.Parse(textBoxid.Text);
                executemyquery(delete);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
       
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = unit2.ToString();
            textBox2.Text = price2.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUnit_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}
