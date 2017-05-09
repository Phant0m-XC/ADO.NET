using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3
{
    public class User
    {
        public User()
        {
            Id = null;
            Login = "";
            Pass = "";
            Adres = "";
            Phone = 0;
            Admin = false;
        }

        public int? Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Adres { get; set; }
        public int Phone { get; set; }
        public bool Admin { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }
}
