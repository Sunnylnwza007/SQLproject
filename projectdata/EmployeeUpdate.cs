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
    public partial class EmployeeUpdate : Form
    {
        String id;
        int jp_id;
        String fname;
        String lname;
        String idcard;
        String email;
        String phone;
        String address;
        String gender;
        String birthda;
        String education;
        String nation;
        String hiredat;
        String wage;
        public EmployeeUpdate(String id, int jp_id, String fname, String lname, String idcard, String email, String phone, String address, String gender, String birthday, String education, String nation, String hiredate, String wage)
        {
            InitializeComponent();
            fillcombo();
            this.id = id;
            this.id = id;
            this.jp_id = jp_id;
            this.fname = fname;
            this.lname = lname;
            this.idcard = idcard;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.gender = gender;
            this.birthda = birthday;
            this.education = education;
            this.nation = nation;
            this.hiredat = hiredate;
            this.wage = wage;
            comboBox1.SelectedIndex = jp_id-1;
            type_fname.Text = fname;
            type_lname.Text = lname;
            type_idcard.Text = idcard;
            type_email.Text = email;
            type_phone.Text = phone;
            type_address.Text = address;
            type_gender.Text = gender;
            type_education.Text = education;
            type_wage.Text = wage;
            textBox1.Text = nation;
           
           
            
            
        }
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
                    idposition = myread.GetInt32("id").ToString();
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


        private void update_Click(object sender, EventArgs e)
        {
            String update = "UPDATE employee SET jp_id="+int.Parse(idposition)+",fname='"+type_fname.Text+"',lname='"+type_lname.Text+"',idcard='"+type_idcard.Text+"',email='"+type_email.Text+"',phone='"+type_phone.Text+"',address= '"+type_address.Text+"',gender='"+type_gender.Text+"',birthday='"+birthday.Text+"',education='"+type_education.Text+"',nation='"+textBox1.Text+"',wage="+int.Parse(type_wage.Text)+" WHERE id = "+int.Parse(id);
            executemyquery(update);
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
