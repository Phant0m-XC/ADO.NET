using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ3
{
    public partial class Form2 : Form
    {
        private User user;
        public Form2(User user)
        {
            InitializeComponent();
            this.user = user;
            textBoxLog.Text = user.Login;
            textBoxPass.Text = user.Pass;
            textBoxAdr.Text = user.Adres;
            textBoxPhone.Text = user.Phone.ToString();
            checkBox1.Checked = user.Admin;
            textBoxPhone.KeyPress += TextBoxPhone_KeyPress;
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user.Login = textBoxLog.Text;
            user.Pass = textBoxPass.Text;
            user.Adres = textBoxAdr.Text;
            user.Phone = Convert.ToInt32(textBoxPhone.Text);
            user.Admin = checkBox1.Checked;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
