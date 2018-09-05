using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectdata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vender vd = new Vender();
            vd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StorageM sm = new StorageM();
            sm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer cm = new Customer();
            cm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StorageP sp = new StorageP();
            sp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderP op = new OrderP();
            op.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Deliver c = new Deliver();
            c.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Manufacture mn = new Manufacture();
            mn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderM om = new OrderM();
            om.Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
