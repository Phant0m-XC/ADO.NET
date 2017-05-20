using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DZ6_2
{
    class LibraryEntity : DbContext
    {
        public LibraryEntity(): base()
        {
        }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonsBooks> PersonsBooks { get; set; }
    }
}
