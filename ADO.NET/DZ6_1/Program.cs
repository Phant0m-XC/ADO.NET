using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LibraryEntity db = new LibraryEntity())
            {
                //1 - Вывести список должников
                Console.WriteLine("Должники: ");
                var result1 = from p in db.Person
                              where p.IsDeptor == true
                              select p;
                foreach (var item in result1)
                {
                    Console.WriteLine($"{item.Surname} {item.Name}");
                }

                //2 - Вывести список авторов книги №3(по порядку из таблицы)
                Console.WriteLine("\nСписок авторов книги №3: ");
                var query2 = (from b in db.Books select b).OrderBy(b => b.Id).Skip(2).First();
                var result2 = from b in db.Books
                              join ba in db.BooksAuthors on b.Id equals ba.IdBook
                              join a in db.Authors on ba.IdAuthor equals a.Id
                              where b.Id == query2.Id
                              select a;
                foreach (var item in result2)
                {
                    Console.WriteLine($"{item.Surname} {item.Name}");
                }

                //3 - Вывести список книг, доступные в данный момент
                Console.WriteLine("\nСписок книг, доступные в данный момент: ");
                var query3 = from b in db.Books
                             join pb in db.PersonsBooks on b.Id equals pb.IdBook
                             select b;
                var result3 = from b in db.Books
                              where !query3.Contains(b)
                              select b;
                foreach (var item in result3)
                {
                    Console.WriteLine($"{item.Name}");
                }

                //4 - Вывести список книг, которые на руках у пользователя №2
                Console.WriteLine("\nCписок книг, которые на руках у пользователя №2: ");
                var query4 = (from p in db.Person select p).OrderBy(p => p.Id).Skip(1).First();
                var result4 = from b in db.Books
                              join pb in db.PersonsBooks on b.Id equals pb.IdBook
                              where query4.Id == pb.IdPerson
                              select b;
                foreach (var item in result4)
                {
                    Console.WriteLine($"{item.Name}");
                }

                //5 - Обнулить задолжности пользователей
                var result5 = from p in db.Person
                              select p;
                foreach (var item in result5)
                {
                    item.IsDeptor = false;
                }
                db.SaveChanges();
            }
        }

        public static void fillDB()
        {
            Authors author1 = new Authors();
            author1.Name = "Семён";
            author1.Surname = "Семёновоич";
            Authors author2 = new Authors();
            author2.Name = "Александр";
            author2.Surname = "Александрович";
            Authors author3 = new Authors();
            author3.Name = "Антон";
            author3.Surname = "Антонович";

            Books book1 = new Books();
            book1.Name = "Книга 1";
            Books book2 = new Books();
            book2.Name = "Книга 2";
            Books book3 = new Books();
            book3.Name = "Книга 3";

            BooksAuthors ba1 = new BooksAuthors();
            ba1.IdAuthor = 1;
            ba1.IdBook = 1;
            BooksAuthors ba2 = new BooksAuthors();
            ba2.IdAuthor = 2;
            ba2.IdBook = 2;
            BooksAuthors ba3 = new BooksAuthors();
            ba3.IdAuthor = 3;
            ba3.IdBook = 3;

            Person person1 = new Person();
            person1.Surname = "Сергеевич";
            person1.Name = "Сергей";
            person1.IsDeptor = true;
            Person person2 = new Person();
            person2.Surname = "Дмитриевич";
            person2.Name = "Дмитрий";
            person2.IsDeptor = true;
            Person person3 = new Person();
            person3.Surname = "Евгеньевич";
            person3.Name = "Евгений";
            person3.IsDeptor = true;

            PersonsBooks pb1 = new PersonsBooks();
            pb1.IdBook = 1;
            pb1.IdPerson = 1;
            PersonsBooks pb2 = new PersonsBooks();
            pb2.IdBook = 2;
            pb2.IdPerson = 2;
            PersonsBooks pb3 = new PersonsBooks();
            pb3.IdBook = 3;
            pb3.IdPerson = 3;

            using (LibraryEntity db = new LibraryEntity())
            {
                db.Authors.Add(author1);
                db.Authors.Add(author2);
                db.Authors.Add(author3);
                db.Books.Add(book1);
                db.Books.Add(book2);
                db.Books.Add(book3);
                db.BooksAuthors.Add(ba1);
                db.BooksAuthors.Add(ba2);
                db.BooksAuthors.Add(ba3);
                db.Person.Add(person1);
                db.Person.Add(person2);
                db.Person.Add(person3);
                db.PersonsBooks.Add(pb1);
                db.PersonsBooks.Add(pb2);
                db.PersonsBooks.Add(pb3);
                db.SaveChanges();
            }
        }
    }
}
