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

namespace Lab1
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder strBuilder;
        private SqlConnection conn;
        private SqlCommand comm;
        private DataTable table;
        private SqlDataReader reader;
        private string login;
        private string pass;
        private string conStr;

        public Form1()
        {
            InitializeComponent();
            strBuilder = new SqlConnectionStringBuilder();
            strBuilder.DataSource = "CYBER\\SQLEXPRESS";
            strBuilder.InitialCatalog = "MyDB";
            while (connection()) { }
            button1.Enabled = false;
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 5)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private bool connection()
        {
            try
            {
                Form2 form2 = new Form2();
                form2.ShowDialog(out login, out pass);
                strBuilder.UserID = login;
                strBuilder.Password = pass;
                conn = new SqlConnection(strBuilder.ConnectionString);
                conn.Open();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn != null)
                    conn.Close();
                return true;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
                if (reader != null)
                    reader.Close();
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = textBox1.Text;
                reader = comm.ExecuteReader();
                table = new DataTable();
                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        if(line == 0)
                        {
                            for(int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for(int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }
                } while (reader.NextResult());
                dataGridView1.DataSource = table;
                reader.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (reader != null)
                    reader.Close();
                if (conn != null)
                    conn.Close();
            }
        }
    }
}
