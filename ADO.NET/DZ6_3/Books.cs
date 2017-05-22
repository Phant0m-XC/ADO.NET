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
            Persons = new List<Persons>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }
        [ForeignKey("TableAuthors")]
        public virtual ICollection<Authors> Authors { get; set; }
        [ForeignKey("TablePersons")]
        public virtual ICollection<Persons> Persons { get; set; }
    }
}
