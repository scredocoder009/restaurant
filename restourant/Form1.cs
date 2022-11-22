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
        private Server server;
        public int calc = 0; //TODO: Field-и нолозима
        private bool _clickSend = false;
        private bool _clickResive = false;
        private int index; //TODO: Field-и нолозима
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Enum.GetNames(typeof(Drink)));
            comboBox1.Text = "" + Drink.NoDrink;
            server = new Server();
        }

        //TODO: Баъди кабул кардан ва хато пахш кардани тугмаи Prepare ва баъдан пахш кардани Send хабари "Enjoy your meal" баромада истодааст
        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            bool text1 = false;
            bool text2 = false;
            text1 = int.TryParse(textBox1.Text, out number);
            text2 = int.TryParse(textBox2.Text, out number);

            if (text1 == true && text2 == true)
            {
                try
                {
                    index = server.Receive(int.Parse(textBox1.Text), int.Parse(textBox2.Text), comboBox1.SelectedIndex + 2);
                    _clickResive = true;
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(ex.Message.ToString());
                }
            }
            else
            {
                listBox1.Items.Add("please enter a number");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_clickResive)
            {
                _clickSend = true;
                _clickResive = false;
                eggQuality.Text = (server.Send());
            }
            else
            {
                listBox1.Items.Add("no request");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] result = server.Serve();
            if (_clickSend)
            {
                _clickSend = false;
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] != null)
                    {
                        listBox1.Items.Add(result[i].ToString());
                    }
                }
                listBox1.Items.Add("Enjoy your meal !");
            }
            else
            {
                listBox1.Items.Add("no request");
            }
        }
    }
}


