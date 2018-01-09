using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arbolb
{
    public partial class Form1 : Form
    {
        ArbolB b = new ArbolB();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n = textBox1.Text;
            string n2 = textBox2.Text;

            int n3 = Convert.ToInt32(n);
            b.insertar(n3, "a");
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.graficarDestinos(b);
        }
    }
}
