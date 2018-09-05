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
    public partial class ManufactureInsert : Form
    {
        public ManufactureInsert()
        {
            InitializeComponent();
            fillcombo();
        }
        int idma;
        String idemployee;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;

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
        private void Insert_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                String insert = "INSERT INTO manufacture(id, em_id, date, unit, status) VALUES (" + textBox1.Text + "," + (comboBox1.SelectedIndex + 1) + ",'" + dateTimePicker1.Text + "'," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
            else
            {
                idma = 0;
                String query = "select * from manufacture";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        idma++;
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String insert = "INSERT INTO manufacture(id, em_id, date, unit, status) VALUES (" + (idma + 1) + "," + (comboBox1.SelectedIndex + 1) + ",'" + dateTimePicker1.Text + "'," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
            
        }

      
    }
}
