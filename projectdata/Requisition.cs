﻿using System;
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
    public partial class Requisition : Form
    {
        public Requisition()
        {
            InitializeComponent();
        }

        private void buttomP_Click(object sender, EventArgs e)
        {
            StorageM sm = new StorageM();
            sm.Show();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            RequisitionInsert ri = new RequisitionInsert();
            ri.Show();
        }
        String id,status;
        MySqlConnection dbcon1 = new MySqlConnection("datasource = localhost;port = 3306;username = root; password=;database = dataproject");
        MySqlCommand command;
        public void poppulate()
        {
            String query = "SELECT requistion.id, employee.fname as employee, requistion.mn_id, requistion.date, requistion.unit, requistion.status FROM requistion natural join employee";
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

        private void Requisition_Load(object sender, EventArgs e)
        {
            poppulate();
        }

        private void buttomd_Click(object sender, EventArgs e)
        {
            RequisitionDetail rd = new RequisitionDetail();
            rd.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            // textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            status = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String delete = "DELETE FROM requistion WHERE id= " + int.Parse(id);
                executemyquery(delete);
                poppulate();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please select list");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            poppulate();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (status.Equals("1"))
            {
                MessageBox.Show("Data is updated");
            }
            else
            {
                String update = "UPDATE requistion  set status = " + 1 + " Where id = " + id;
                executemyquery(update);
                poppulate();
            }
            
        }
    }
}
