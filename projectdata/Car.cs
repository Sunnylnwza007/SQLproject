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
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
            fillcombo();
        }
        int idcar;
        int type;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        MySqlDataReader myread;

        public void fillcombo()
        {
            String query = "select * from type_car";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while(myread.Read())
                {

                    String type = myread.GetString("type");
                    comboBox1.Items.Add(type);
                }
                dbcon1.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void Car_Load(object sender, EventArgs e)
        {
            poppulate();
        }
        public void poppulate()
        {
            String query = "SELECT car.id, type_car.type as type, car.num, car.brand, car.engine, car.color FROM car natural join type_car ";
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

        private void insert_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text != "")
            {
                String insert1 = "INSERT INTO car(id,tc_id,num, brand, engine, color) VALUES (" +int.Parse(textBoxid.Text)+ "," + (comboBox1.SelectedIndex + 1) + ",'" + textBoxnum.Text + "','" + textBoxbrand.Text + "','" + textBoxengine.Text + "','" + textBoxcolor.Text + "')";
                executemyquery(insert1);
                poppulate();
            }
            else
            {
                idcar = 0;
                String query = "select * from car";
                command = new MySqlCommand(query, dbcon1);
                try
                {
                    dbcon1.Open();
                    myread = command.ExecuteReader();
                    while (myread.Read())
                    {
                        idcar++;
                    }
                    dbcon1.Close();

                }
                catch (Exception e1)
                {

                }
                String insert = "INSERT INTO car(id,tc_id,num, brand, engine, color) VALUES (" + (idcar + 1) + "," + (comboBox1.SelectedIndex + 1) + ",'" + textBoxnum.Text + "','" + textBoxbrand.Text + "','" + textBoxengine.Text + "','" + textBoxcolor.Text + "')";
                executemyquery(insert);
                poppulate();
            }
            
        }

        private void update_Click(object sender, EventArgs e)
        {
            String update = "UPDATE car SET color = '"+ textBoxcolor.Text +"' WHERE id =" + int.Parse(textBoxid.Text);
            executemyquery(update);
            poppulate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            String delete = "DELETE FROM car WHERE id= " + int.Parse(textBoxid.Text);
            executemyquery(delete);
            poppulate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.SelectedIndex = (int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) - 1);
                textBoxnum.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBoxbrand.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBoxengine.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBoxcolor.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something wrong");
            }
           
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select * from type_car where type = '"+comboBox1.Text+"'";
            command = new MySqlCommand(query, dbcon1);
            try
            {
                dbcon1.Open();
                myread = command.ExecuteReader();
                while (myread.Read())
                {
                    type = myread.GetInt32("id");
                }
                dbcon1.Close();
                
            }
            catch (Exception e1)
            {

            }
         

        }
    }
}
