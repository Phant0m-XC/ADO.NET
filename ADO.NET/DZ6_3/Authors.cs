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
    [Table("TableAuthors")]
    public class Authors
    {
        public Authors()
        {
            Books = new List<Books>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Name", TypeName ="nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("Surname", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Surname { get; set; }
        [ForeignKey("TableBooks")]
        public virtual ICollection<Books> Books { get; set; }
    }
}
