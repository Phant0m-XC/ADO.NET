using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DZ3
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataSet ds;
        private SqlCommandBuilder cmd;
        private string connStr = "";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            connStr = ConfigurationManager.ConnectionStrings["UsersConn"].ConnectionString;
            conn.ConnectionString = connStr;
            checkBox2.Enabled = false;
            buttonAdd.Enabled = false;
            listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult result;
            User user = (User)((ListBox)sender).SelectedItem;
            Form2 form2 = new Form2(user);
            result = form2.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (checkLogin(user.Login))
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (user.Id == ds.Tables[0].Rows[i].Field<int>(0))
                        {
                            ds.Tables[0].Rows[i].SetField<string>(1, user.Login);
                            ds.Tables[0].Rows[i].SetField<string>(2, user.Pass);
                            ds.Tables[0].Rows[i].SetField<string>(3, user.Adres);
                            ds.Tables[0].Rows[i].SetField<int>(4, user.Phone);
                            ds.Tables[0].Rows[i].SetField<bool>(5, user.Admin);
                            da.Update(ds);
                            loadUsers(checkBox1.Checked);
                            break;
                        }
                    }
                }
                else
                    MessageBox.Show("Логин занят", "Пользователь существует",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void loadUsers(bool flag)
        {
            listBox1.Items.Clear();
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                ds = new DataSet();
                string str = "select * from dbo.Users";
                da = new SqlDataAdapter(str, conn);
                cmd = new SqlCommandBuilder(da);
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (flag)
                    {
                        if (flag == ds.Tables[0].Rows[i].Field<bool>(5))
                        {
                            User user = new User();
                            user.Id = ds.Tables[0].Rows[i].Field<int>(0);
                            user.Login = ds.Tables[0].Rows[i].Field<string>(1);
                            user.Pass = Convert.ToString(ds.Tables[0].Rows[i].Field<string>(2).GetHashCode());
                            user.Adres = ds.Tables[0].Rows[i].Field<string>(3);
                            user.Phone = ds.Tables[0].Rows[i].Field<int>(4);
                            user.Admin = ds.Tables[0].Rows[i].Field<bool>(5);
                            listBox1.Items.Add(user);
                        }
                    }
                    else
                    {
                        User user = new User();
                        user.Id = ds.Tables[0].Rows[i].Field<int>(0);
                        user.Login = ds.Tables[0].Rows[i].Field<string>(1);
                        user.Pass = Convert.ToString(ds.Tables[0].Rows[i].Field<string>(2).GetHashCode());
                        user.Adres = ds.Tables[0].Rows[i].Field<string>(3);
                        user.Phone = ds.Tables[0].Rows[i].Field<int>(4);
                        user.Admin = ds.Tables[0].Rows[i].Field<bool>(5);
                        listBox1.Items.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            loadUsers(checkBox1.Checked);
            buttonAdd.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogResult result;
            User user = new User();
            Form2 form2 = new Form2(user);
            result = form2.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (checkLogin(user.Login))
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row[1] = user.Login;
                    row[2] = user.Pass;
                    row[3] = user.Adres;
                    row[4] = user.Phone;
                    row[5] = user.Admin;
                    ds.Tables[0].Rows.Add(row);
                    da.Update(ds);
                }
                else
                    MessageBox.Show("Логин занят", "Пользователь существует",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            loadUsers(checkBox1.Checked);
        }

        private bool checkLogin(string str)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str.CompareTo(ds.Tables[0].Rows[i].Field<string>(1)) == 0)
                    return false;
            }
            return true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPass.Text = ((User)listBox1.SelectedItem).Pass;
            textBoxAdr.Text = ((User)listBox1.SelectedItem).Adres;
            textBoxPhone.Text = ((User)listBox1.SelectedItem).Phone.ToString();
            checkBox2.Checked = ((User)listBox1.SelectedItem).Admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = (User)listBox1.SelectedItem;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (user.Id == ds.Tables[0].Rows[i].Field<int>(0))
                {
                    ds.Tables[0].Rows[i].Delete();
                    da.Update(ds);
                    loadUsers(checkBox1.Checked);
                    break;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            loadUsers(checkBox1.Checked);
        }
    }
}