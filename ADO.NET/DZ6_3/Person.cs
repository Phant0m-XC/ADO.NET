using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DZ6_3
{
    [Table("TablePerson")]
    public class Person
    {
        public Person()
        {
            Books = new List<Books>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public bool IsDeptor { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}
