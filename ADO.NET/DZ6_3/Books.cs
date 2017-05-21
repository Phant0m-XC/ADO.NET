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
    [Table("TableBooks")]
    public class Books
    {
        public Books()
        {
            Authors = new List<Authors>();
            Person = new List<Person>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Authors> Authors { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
