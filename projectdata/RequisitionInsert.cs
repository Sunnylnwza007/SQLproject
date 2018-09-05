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
    public partial class RequisitionInsert : Form
    {
        public RequisitionInsert()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (type_id.Text != "")
            {
                String insert = "INSERT INTO requistion(id, em_id,mn_id,date, unit, status) VALUES (" + type_id.Text + "," + (comboBox1.SelectedIndex + 1) + "," + int.Parse(comboBox2.Text) + ",'" + dateTimePicker1.Text + "'," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
            else
            {
                int idr =0;
                String query = "select * from requistion";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        idr++;
                    }
                    dbcon1.Close();
                }
                catch (Exception e1)
                {

                }
                String insert = "INSERT INTO requistion(id, em_id,mn_id,date, unit, status) VALUES (" + (idr+1) + "," + (comboBox1.SelectedIndex + 1) + "," + int.Parse(comboBox2.Text) + ",'" + dateTimePicker1.Text + "'," + 0 + "," + 0 + ")";
                executemyquery(insert);
            }
           
        }
    }
}
