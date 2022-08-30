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

    // ҳамма хатогиҳо бояд коркард кара шавад ва ба истифодабаранда нишон дода шавад.
    // таърихи фармонхоро дар оинаи дидани натиҷа ногоҳ доред.
    // Пешхизмат наметавонад 2 фармонро дар як вақт қабул намояд (пешхизмат наметавонад дар як вақт фармони ҳам  chicken ва egg гирад) 
    public partial class Form1 : Form
    {
        private Employee employee;
        private object connect;
        private bool newRequest = false;
        private bool copy = false;

        public Form1()
        {
            InitializeComponent();
            employee = new Employee();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                listBox1.Items.Add("Quantity is not specified");
            }
            else
            {
                copy = false;
                int quantity = int.Parse(textBox1.Text);
                newRequest = true;


                if (radioButton1.Checked)
                {
                    connect = employee.NewRequest(quantity, typeof(ChickenOrder));
                    label2.Text = employee.Inspect(connect);
                }
                else if (radioButton2.Checked)
                {
                    connect = employee.NewRequest(quantity, typeof(EggOrder));
                    label2.Text = employee.Inspect(connect);
                }
            }
        }

        //пешхизмат фаромушхотир мебошад 
        // ба талаботҳои дар саҳифаи 8 ва саҳифаи 17 буда назар кунед

        private void button2_Click(object sender, EventArgs e)
        {
            if (copy == true)
            {
                newRequest = true;
                connect = employee.CopyRequest();
                label2.Text = employee.Inspect(connect);
            }
            else
            {
                listBox1.Items.Add("You don't have new request");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (newRequest == true)
            {
                string result = employee.PrepareFood(connect);

                listBox1.Items.Add(result);
                textBox1.Text = "";
                label2.Text = "";
                newRequest = false;
                copy = true;
            }
            else
            {
                listBox1.Items.Add("no request");
            }
            newRequest = false;
        }
    }
}
