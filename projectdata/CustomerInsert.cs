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
    public partial class CustomerInsert : Form
    {
        public CustomerInsert()
        {
            InitializeComponent();
        }
        int idcus;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void update_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text != "")
            {
                String insert1 = "INSERT INTO customer(id, idcard, fname, lname, email, phone, address, idcompany, namecompany) VALUES (" + textBoxid.Text + ",'" + tic.Text + "','" + tfn.Text + "','" + tln.Text + "','" + te.Text + "','" + tp.Text + "','" + ta.Text + "','" + tidc.Text + "','" + tnc.Text + "')";
                executemyquery(insert1);
                Close();
            }
            else
            {
                idcus = 0;
                String query = "select * from customer";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        idcus++;
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String insert = "INSERT INTO customer(id, idcard, fname, lname, email, phone, address, idcompany, namecompany) VALUES (" + (idcus + 1) + ",'" + tic.Text + "','" + tfn.Text + "','" + tln.Text + "','" + te.Text + "','" + tp.Text + "','" + ta.Text + "','" + tidc.Text + "','" + tnc.Text + "')";
                executemyquery(insert);
                Close();
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

    }
}
