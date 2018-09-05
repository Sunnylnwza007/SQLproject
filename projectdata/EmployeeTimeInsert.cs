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
    public partial class EmployeeTimeInsert : Form
    {
        public EmployeeTimeInsert()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        int idjd;
        String idemployee;
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
            String query = "select * from  job_type";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    String type = myread.GetString("name");
                    comboBox2.Items.Add(type);
                }
                dbcon1.Close();
            }
            catch (Exception e)
            {

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            idjd = 0;
            String query = "select * from job_detail";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    idjd++;
                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
            String insert = "INSERT INTO job_detail(id, em_id, jt_id, in_time,out_time,date,hours ) VALUES (" + (idjd+1) + "," + (comboBox1.SelectedIndex + 1) + "," + (comboBox2.SelectedIndex + 1) + ",'" + textBox1.Text + "','" + null + "','" + dateTimePicker1.Text + "','" + null + "')";
            executemyquery(insert);
        }

    }

}
