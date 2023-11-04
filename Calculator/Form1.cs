using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{

    public partial class Form1 : Form
    {
        int num1 = 0;
        int num2 = 0;
        int result = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && comboBox1.Text != string.Empty)
            {
                num1 = Convert.ToInt32(textBox1.Text);
                num2 = Convert.ToInt32(textBox2.Text);
                if (Convert.ToChar(comboBox1.Text) == '-')
                    result = num1 - num2;
                else if (Convert.ToChar(comboBox1.Text) == '+')
                    result = num1 + num2;
                else if (Convert.ToChar(comboBox1.Text) == '*')
                    result = num1 * num2;
                else if (Convert.ToChar(comboBox1.Text) == '/' && Convert.ToChar(textBox2.Text) == '0')
                    label1.Text = "Error";
                else
                    result = num1 / num2;
                label1.Text = result.ToString();

                if (Convert.ToChar(comboBox1.Text) == '%')
                {
                    result = (num1 * 100) / num2;
                    label1.Text = result.ToString() + " %";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Result";
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text != "Result")
                Clipboard.SetText($"{label1.Text}");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
                e.Handled = true;
        }
    }
}
