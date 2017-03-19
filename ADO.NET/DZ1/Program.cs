using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DZ1
{
    class Program
    {
        SqlConnection conn = null;

        public Program()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.insertTable();
        }

        public void insertTable()
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = @"CREATE TABLE [dbo].[gruppa]
                               (
                                    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
                                    Name NVARCHAR(200) NOT NULL
                               )";
                comm.ExecuteNonQuery();
                Console.WriteLine("Таблица создана...");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
    }
}