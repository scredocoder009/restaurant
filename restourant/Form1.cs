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
        private int quantRequest = 1;
        public Form1()

        {
            InitializeComponent();
            employee = new Employee();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            RequestException();
            int quantity = int.Parse(textBox1.Text);


            if (Chicken.Checked)
            {
                connect = employee.NewRequest(quantity, typeof(ChickenOrder));
                label2.Text = employee.Inspect(connect);
            }
            else if (checkBox2.Checked)
            {
                connect = employee.NewRequest(quantity, typeof(EggOrder));
                label2.Text = employee.Inspect(connect);
            }
        }

//пешхизмат фаромушхотир мебошад 
// ба талаботҳои дар саҳифаи 8 ва саҳифаи 17 буда назар кунед
        private void RequestException()
        {
            if (quantRequest == 3)
            {
                quantRequest = 1;
                if (Chicken.Checked)
                {
                    Chicken.Checked = false;
                    checkBox2.Checked = true;
                }
                else
                {
                    Chicken.Checked = true;
                    checkBox2.Checked = false;
                }
            }
            ++quantRequest;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestException();
            connect = employee.CopyRequest();

            label2.Text = employee.Inspect(connect);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = employee.PrepareFood(connect);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
