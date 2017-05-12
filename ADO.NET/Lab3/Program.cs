using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            DataClasses1DataContext context = new DataClasses1DataContext();
            Console.Write("Товары тяжелее 1 кг. - ");
            var result1 = from c in context.Products
                          select c;
            Console.WriteLine(result1.Count<Product>(p => p.Weight > 1));


            //2
            Console.WriteLine("\nКатегории и количество товаров в каждой: ");
            var result2 = context.Products.GroupBy(c => c.Category, c => c.Title).Select(
                g => new { Category = g.Key, Count = g.Distinct().Count() });
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            //3
            Console.WriteLine("\nТовары на 'S' с длинной строки 5 символов: ");
            var result3 = from c in context.Products
                          where c.Title.StartsWith("S")
                          select c;
            foreach (var item in result3)
            {
                if (item.Title.Length == 5)
                    Console.WriteLine(item.Title);
            }

            //4
            Console.WriteLine("\nТовары в алфавитном порядке дешевле 400 грн: ");
            var result4 = from c in context.Products
                          where c.Price < 400 orderby c.Title ascending
                          select c;
            foreach (var item in result4)
            {
                Console.WriteLine(item.Title);
            }

            //5
            Console.WriteLine("\nКатегория с товаром с максимальной ценой: ");
            var result5 = from c in context.Products
                          where c.Price == context.Products.Max(p => p.Price)
                          select c;
            foreach (var item in result5)
                Console.WriteLine(item.Category);
        }
    }
}
