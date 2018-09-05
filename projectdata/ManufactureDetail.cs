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
    public partial class ManufactureDetail : Form
    {
        public ManufactureDetail()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        int name;
        int unit;
        int unitma;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        public void poppulate()
        {
            String query = "SELECT * FROM detail_manufacture";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        
    

        public void fillcombo()
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
            String query = "select * from manufacture";
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

        private void ManufactureDetail_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) - 1;
                comboBox2.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) - 1;
                textBoxUnit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something Wrong");
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from product where type = '" + comboBox1.Text + "'";
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

        private void insert_Click(object sender, EventArgs e)
        {
            try
            {
                String insert = "INSERT INTO detail_manufacture(id,pd_id,mn_id,unit) VALUES (" + textBoxid.Text + "," + (comboBox1.SelectedIndex + 1) + "," + comboBox2.Text + "," + textBoxUnit.Text + ")";
                executemyquery(insert);
                String query = "select * from product where id = " + (comboBox1.SelectedIndex + 1);
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unit = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update = "UPDATE product SET unit=" + (unit + int.Parse(textBoxUnit.Text)) + " WHERE id = " + (comboBox1.SelectedIndex + 1);
                executemyquery(update);
                String query1 = "select * from manufacture where id = " + (comboBox2.SelectedIndex + 1);
                command = new MySqlCommand(query1, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unitma = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update1 = "UPDATE manufacture  SET unit=" + (unitma + int.Parse(textBoxUnit.Text)) + " WHERE id = " + (comboBox2.SelectedIndex + 1);
                executemyquery(update1);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something wrong");
            }
          
        }

       

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM detail_manufacture WHERE id= " + int.Parse(textBoxid.Text);
                executemyquery(delete);
                String query = "select * from product where id = " + (comboBox1.SelectedIndex + 1);
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unit = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update22 = "UPDATE product SET unit=" + (unit - int.Parse(textBoxUnit.Text)) + " WHERE id = " + (comboBox1.SelectedIndex + 1);
                executemyquery(update22);
                String query1 = "select * from manufacture where id = " + (comboBox2.SelectedIndex + 1);
                command = new MySqlCommand(query1, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unitma = myread.GetInt32("unit");
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update11 = "UPDATE manufacture  SET unit=" + (unitma - int.Parse(textBoxUnit.Text)) + " WHERE id = " + (comboBox2.SelectedIndex + 1);
                executemyquery(update11);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
            
        }
    }
}
