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
using System.IO;
using System.Configuration;

namespace DZ2
{
    public partial class Form1 : Form
    {
        private SqlDataReader reader;
        private DataTable table;
        private SqlConnection conn;
        private string connStr = "";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            connStr = ConfigurationManager.ConnectionStrings["SellingConn"].ConnectionString;
            conn.ConnectionString = connStr;
            comboBox1.SelectedIndex = 0;
        }

        private void loadTables(string str)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = $"select * from dbo.{str}";
                comm.Connection = this.conn;
                dataGridView1.DataSource = null;
                conn.Open();
                table = new DataTable();
                reader = comm.ExecuteReader();
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
                if (reader != null)
                    reader.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTables(comboBox1.Text);
        }
    }
}
