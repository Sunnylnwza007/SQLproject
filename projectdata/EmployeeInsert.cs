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
    public partial class EmployeeInsert : Form
    {
        public EmployeeInsert()
        {
            InitializeComponent();
            fillcombo();
            DateTime dt = DateTime.Now;
        }
        int idem;
        String idposition;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;

        public void fillcombo()
        {
            String query = "select * from job_position";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    String type = myread.GetString("name");
                    comboBox1.Items.Add(type);
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String query = "select * from job_position where name = '" + comboBox1.Text + "'";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    idposition = myread.GetInt16("id").ToString();
                    
                }
                dbcon1.Close();
                
            }
            catch (Exception e1)
            {

            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("") || type_fname.Text.Equals("") || textBox1.Text.Equals("") || textBox2.Text.Equals("") || type_email.Text.Equals("") || type_phone.Text.Equals("") || type_address.Text.Equals("") || type_gender.Text.Equals("") || type_education.Text.Equals("") || textBox3.Text.Equals("") || type_wage.Text.Equals(""))
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน");
            }
            else
            {
                if (textBoxid.Text != "")
                {
                    String insert = "INSERT INTO employee(id, jp_id, fname, lname, idcard, email, phone, address, gender,birthday, education, nation, hiredate, wage) VALUES (" + textBoxid.Text + "," + comboBox1.SelectedIndex + ",'" + type_fname.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + type_email.Text + "','" + type_phone.Text + "','" + type_address.Text + "','" + type_gender.Text + "','" + birthday.Text + "','" + type_education.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString("yyyyMMdd") + "'," + type_wage.Text + ")";
                    executemyquery(insert);
                }
                else
                {
                    idem = 0;
                    String query = "select * from employee";
                    command = new MySqlCommand(query, dbcon1);
                    try
                    {
                        dbcon1.Open();
                        myread = command.ExecuteReader();
                        while (myread.Read())
                        {
                            idem++;
                        }
                        dbcon1.Close();

                    }
                    catch (Exception e1)
                    {

                    }
                    String insert = "INSERT INTO employee(id, jp_id, fname, lname, idcard, email, phone, address, gender,birthday, education, nation, hiredate, wage) VALUES (" + (idem + 1) + "," + comboBox1.SelectedIndex + ",'" + type_fname.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + type_email.Text + "','" + type_phone.Text + "','" + type_address.Text + "','" + type_gender.Text + "','" + birthday.Text + "','" + type_education.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString("yyyyMMdd") + "'," + type_wage.Text + ")";
                    executemyquery(insert);
                }
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
