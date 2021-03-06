﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DZ6_3
{
    class LibraryEntity : DbContext
    {
        public LibraryEntity(): base("LibraryDB")
        {
            Database.SetInitializer<LibraryEntity>(new CreateDatabaseIfNotExists<LibraryEntity>());
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        //public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<Persons> Persons { get; set; }
        //public DbSet<PersonsBooks> PersonsBooks { get; set; }
    }
}
