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
    public partial class DeliverDetail : Form
    {
        public DeliverDetail()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        String status;
        String type;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        public void poppulate()
        {
            String query = "SELECT * FROM detail_deliver";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillcombo()
        {
            String query = "select * from order_product";
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
        public void fillcombo1()
        {
            String query = "select * from deliver";
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

        private void DeliverDetail_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            status = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void insert_Click(object sender, EventArgs e)
        {
            String insert = "INSERT INTO detail_deliver(id,op_id,de_id, status) VALUES (" + textBoxid.Text + "," + comboBox1.Text+ ",'" + comboBox2.Text + "','" + 0 +"')";
            executemyquery(insert);
            poppulate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM detail_deliver WHERE id= " + int.Parse(textBoxid.Text);
                executemyquery(delete);
                poppulate();
            }catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (status == "False")
            {
                String update = "UPDATE detail_deliver set status = " + 1 + " Where id = " + int.Parse(textBoxid.Text);
                executemyquery(update);

            }
            poppulate();
        }
    }
}
