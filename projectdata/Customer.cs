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
    public partial class Customer : Form
    {
        String id = "";
        String idcard;
        String fname;
        String lname;
        String email;
        String phone;
        String address;
        String idcompany;
        String namecompany;

        public Customer()
        {
            InitializeComponent();
        }
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        private void Customer_Load(object sender, EventArgs e)
        {
            poppulate();
        }
        private void db()
        {
            String conn = "datasource = localhost; username = root; password=;database = dataproject";
            MySqlConnection dbcon = new MySqlConnection(conn);
            try
            {
                dbcon.Open();
                MessageBox.Show("connect Success");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void poppulate()
        {
            String query = "SELECT * FROM Customer";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            idcard = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lname = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            email = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            phone = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            address = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            idcompany = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            namecompany = dataGridView1.CurrentRow.Cells[8].Value.ToString();

        }

        private void update_Click(object sender, EventArgs e)
        {
            if (id.Equals(""))
            {
                MessageBox.Show("Please select customer");
            }
            else
            {
                CustomerUpdate cu = new CustomerUpdate(id, idcard, fname, lname, email, phone, address, idcompany, namecompany);
                cu.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            poppulate();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            CustomerInsert ci = new CustomerInsert();
            ci.Show();
        }
    }
}
