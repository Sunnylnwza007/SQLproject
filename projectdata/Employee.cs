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
    public partial class Employee : Form
    {
        String id= "";
        int id2 = 0;
        int jp_id;
        String fname;
        String lname;
        String idcard;
        String email;
        String phone;
        String address;
        String gender;
        String birthday;
        String education;
        String nation;
        String hiredate;
        String wage;

        public Employee()
        {
            InitializeComponent();
        }
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        private void Employee_Load(object sender, EventArgs e)
        {
            poppulate();
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
            String query = "SELECT * FROM employee ";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void insert_Click(object sender, EventArgs e)
        {
            EmployeeInsert ei = new EmployeeInsert();
            ei.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (id.Equals(""))
            {
                MessageBox.Show("Please select employee");
            }
            else
            {
                EmployeeUpdate eu = new EmployeeUpdate(id, jp_id, fname, lname, idcard, email, phone, address, gender, birthday, education, nation, hiredate, wage);
                eu.Show();
            }
           
        }

        private void time_Click(object sender, EventArgs e)
        {
            if (id2 == 0)
            {
                MessageBox.Show("Please Select Employee");
            }
            else
            {
                EmployeeTime et = new EmployeeTime(id2);
                et.Show();
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            poppulate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                id2 = int.Parse(id);
                jp_id = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                fname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                lname = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                idcard = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                email = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                phone = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                address = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                gender = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                birthday = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox1.Text = birthday;
                education = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                nation = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                hiredate = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                wage = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something Wrong");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM employee WHERE id= " + int.Parse(id);
                executemyquery(delete);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
           
        }
    }
}
