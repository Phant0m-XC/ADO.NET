using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department() {Id =1, Country = "Ukraine", City =  "Donetsk"},
                new Department() {Id =2, Country = "Ukraine", City = "Kyiv" },
                new Department() {Id =3, Country = "France", City = "Paris" },
                new Department() {Id =4, Country = "Russia", City = "Moscow" },
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() {Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() {Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() {Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() {Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() {Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee() {Id = 7, FirstName = "Nikita", LastName = "Kotov", Age = 27, DepId = 4 },
            };

            //1
            Console.WriteLine("Имена сотрудинков из Украины, но не из Донецка:");
            var result1 = from c in departments
                          where c.Country == "Ukraine" && c.City != "Donetsk"
                          select c;
            foreach (var item1 in result1)
                foreach (var item2 in employees)
                    if (item1.Id == item2.DepId)
                        Console.WriteLine(item2.FirstName + " " + item2.LastName);

            //2
            Console.WriteLine("\nСтраны: ");
            var result2 = departments.GroupBy(c => c.Country).Select(g => new { g.Key });
            foreach (var item in result2)
                Console.WriteLine(item.Key);

            //3
            Console.WriteLine("\n3 сотрудника старше 25 лет: ");
            var result3 = (from c in employees
                          where c.Age > 25
                          select c).Take(3);
            foreach(var item in result3)
                Console.WriteLine(item.FirstName + " " + item.LastName);

            //4
            Console.WriteLine("\nСотрудника старше 23 лет из Киева: ");
            var result4 = from c in employees
                          join t in departments on c.DepId equals t.Id
                          where t.City == "Kyiv"
                          select c;
            foreach (var item in result4)
                Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.Age);
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
