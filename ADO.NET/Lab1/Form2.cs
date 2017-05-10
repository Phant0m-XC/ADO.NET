using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Enabled = false;
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox2_TextChanged;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "" &&
                textBox2.Text != null && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "" &&
                textBox2.Text != null && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        public DialogResult ShowDialog(out string login, out string pass)
        {
            DialogResult result;
            result = this.ShowDialog();
            login = textBox1.Text;
            pass = textBox2.Text;
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
