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
    public partial class RequisitionDetail : Form
    {
        public RequisitionDetail()
        {
            InitializeComponent();
            fillcombo();
            fillcombo1();
        }
        int unitr;
        int unitm;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;
        public void poppulate()
        {
            String query = "SELECT * FROM detail_requistion";
            DataTable table = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(query, dbcon1);
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillcombo()
        {
            String query = "select * from requistion";
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
            String query = "select * from materials";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {

                    String type = myread.GetString("type");
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

        private void RequisitionDetail_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) - 1;
                comboBox2.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) - 1;
                textBoxUnit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }catch (Exception e1)
            {
                MessageBox.Show("Something Wrong");
            }
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from requistion where id = " + (comboBox1.SelectedIndex + 1);
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unitr = myread.GetInt32("unit");

                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update1 = "UPDATE requistion SET unit = " + (unitr - int.Parse(textBoxUnit.Text)) + " WHERE id = " + int.Parse(comboBox1.Text);
                executemyquery(update1);
                String query2 = "select * from materials where id = " + (comboBox2.SelectedIndex + 1);
                command = new MySqlCommand(query2, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unitm = myread.GetInt32("unit");

                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update = "UPDATE materials SET unit = " + (unitm + int.Parse(textBoxUnit.Text)) + " WHERE id =" + (comboBox2.SelectedIndex + 1);
                executemyquery(update);
                String delete = "DELETE FROM detail_requistion WHERE id= " + int.Parse(textBoxid.Text);
                executemyquery(delete);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            String query1 = "select * from materials where id = " + (comboBox2.SelectedIndex + 1);
            command = new MySqlCommand(query1, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    unitm = myread.GetInt32("unit");

                }
                dbcon1.Close();

            }
            catch (Exception e1)
            {

            }
            if (unitm < int.Parse(textBoxUnit.Text))
            {
                MessageBox.Show("Not Enough Materials");
            }
            else
            {
                String insert = "INSERT INTO detail_requistion(id,rq_id, m_id, unit) VALUES (" + textBoxid.Text + "," + comboBox1.Text + "," + (comboBox2.SelectedIndex + 1) + "," + textBoxUnit.Text + ")";
                executemyquery(insert);
                String query = "select * from requistion where id = " + (comboBox1.SelectedIndex + 1);
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unitr = myread.GetInt32("unit");

                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update1 = "UPDATE requistion SET unit = " + (unitr + int.Parse(textBoxUnit.Text)) + " WHERE id = " + int.Parse(comboBox1.Text);
                executemyquery(update1);
                String query2 = "select * from materials where id = " + (comboBox2.SelectedIndex + 1);
                command = new MySqlCommand(query2, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        unitm = myread.GetInt32("unit");

                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String update = "UPDATE materials SET unit = " + (unitm - int.Parse(textBoxUnit.Text)) + " WHERE id =" + (comboBox2.SelectedIndex + 1);
                executemyquery(update);
                poppulate();
            }
           
        }
    }
}
