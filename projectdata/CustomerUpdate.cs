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

    public partial class CustomerUpdate : Form
    {
        String id;
        String idcard;
        String fname;
        String lname;
        String email;
        String phone;
        String address;
        String idcompany;
        String namecompany;
        
        public CustomerUpdate(String id,String idcard,String fname,String lname,String email,String phone,String address,String idcompany,String namecompany)
        {

            InitializeComponent();
            this.id = id;
            this.idcard = idcard;
            this.fname = fname;
            this.lname = lname;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.idcompany = idcompany;
            this.namecompany = namecompany;
        }
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        private void CustomerUpdate_Load(object sender, EventArgs e)
        {
            tic.Text = idcard;
            tfn.Text = fname;
            tln.Text = lname;
            te.Text = email;
            tp.Text = phone;
            ta.Text = address;
            tidc.Text =idcompany;
            tnc.Text = namecompany;
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
            String update = "UPDATE customer SET idcard='"+tic.Text+"',fname = '"+tfn.Text+"',lname = '"+tln.Text+"',email = '"+te.Text+"',phone = '"+tp.Text+"',address = '"+ta.Text+"',idcompany = '"+tidc.Text+"',namecompany = '"+tnc.Text+"' WHERE id = "+int.Parse(id);
            executemyquery(update);
            Close();
            
        }

    }
}
