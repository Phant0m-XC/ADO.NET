using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4
{
    class Seller
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }

        public Seller(string firstName, string lastName)
        {
            FirsName = firstName;
            LastName = lastName;
        }
    }
}
