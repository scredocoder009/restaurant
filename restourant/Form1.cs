using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourant
{
    public partial class Form1 : Form
    {
        private Employee employee;
        private object birornarsa;
        public Form1()

        {
            InitializeComponent();
            employee = new Employee();

        }



        private void button1_Click(object sender, EventArgs e)
        {

            int quantity = int.Parse(textBox1.Text);


            if (Chicken.Checked)
            {
                birornarsa = employee.NewRequest(quantity, typeof(ChickenOrder));
                label2.Text = employee.Inspect(birornarsa);
            }
            else if (checkBox2.Checked)
            {
                birornarsa = employee.NewRequest(quantity, typeof(EggOrder));
                label2.Text = employee.Inspect(birornarsa);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            birornarsa = employee.CopyRequest();

            label2.Text = employee.Inspect(birornarsa);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = employee.PrepareFood(birornarsa);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
