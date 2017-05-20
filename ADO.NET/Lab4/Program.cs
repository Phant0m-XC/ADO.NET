using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LibraryEntities db = new LibraryEntities())
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
    }
}
