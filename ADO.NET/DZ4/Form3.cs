using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        public DialogResult ShowDialog(out string firm, out string model)
        {
            DialogResult result = this.ShowDialog();
            firm = textBox1.Text;
            model = textBox2.Text;
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "" &&
                textBox2.Text != null && textBox2.Text != "")
                button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "" &&
                textBox2.Text != null && textBox2.Text != "")
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
