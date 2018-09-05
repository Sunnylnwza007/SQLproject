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
    public partial class DeliverInsert : Form
    {
        public DeliverInsert()
        {
            InitializeComponent();
            fillcombo();
            fillcombo2();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        int idde;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
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
        public void fillcombo()
        {
            String query = "select * from car";
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
        public void fillcombo2()
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
        private void DeliverInsert_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                String insert1 = "INSERT INTO deliver(id, car_id, em_id, date, distance, status) VALUES (" + textBox1.Text + "," + (comboBox1.SelectedIndex + 1) + "," + (comboBox2.SelectedIndex + 1) + ",'" + dateTimePicker1.Text + "'," + textBox5.Text + "," + 0 + ")";
                executemyquery(insert1);
            }
            else
            {
                idde = 0;
                String query = "select * from deliver";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        idde++;
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String insert = "INSERT INTO deliver(id, car_id, em_id, date, distance, status) VALUES (" + (idde + 1) + "," + (comboBox1.SelectedIndex + 1) + "," + (comboBox2.SelectedIndex + 1) + ",'" + dateTimePicker1.Text + "'," + textBox5.Text + "," + 0 + ")";
                executemyquery(insert);
            }
          
        }
    }
}
