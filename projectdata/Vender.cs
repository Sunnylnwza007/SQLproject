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
    public partial class Vender : Form
    {
        public Vender()
        {
            InitializeComponent();
        }
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;

        private void Vender_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        public void poppulate()
        {
            String query = "SELECT * FROM Vender";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxadd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxe.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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

        private void insert_Click(object sender, EventArgs e)
        {
            String insert = "INSERT INTO vender(id,name, address, phone, email) VALUES ("+textBoxid.Text+",'"+textBoxname.Text+"','"+textBoxadd.Text+"','"+textBoxp.Text+"','"+textBoxe.Text+"')";
            executemyquery(insert);
            poppulate();
        }

        private void update_Click(object sender, EventArgs e)
        {
            String update= "UPDATE vender SET name= '"+textBoxname.Text+"',address='"+textBoxadd.Text+"',phone= '"+textBoxp.Text+"',email= '"+textBoxe.Text+"' WHERE id ="+int.Parse(textBoxid.Text);
            executemyquery(update);
            poppulate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM vender WHERE id= " + int.Parse(textBoxid.Text);
                executemyquery(delete);
                poppulate();
            }catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
            
        }
    }
}
