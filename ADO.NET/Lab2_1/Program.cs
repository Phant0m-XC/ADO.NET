using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new { Name = "item1", justValue = 5 };
            var item2 = new { value1 = 15, valueBool = true };
            Console.WriteLine(item1.Equals(item2));
            Console.WriteLine("HashCode Item1: " + item1.GetHashCode());
            Console.WriteLine("HashCode Item2: " + item2.GetHashCode());

            var item3 = new { Name = "item1", justValue = 5 };
            Console.WriteLine(item3.Equals(item1));
            Console.WriteLine("HashCode Item1: " + item1.GetHashCode());
            Console.WriteLine("HashCode Item3: " + item3.GetHashCode());
            /*
            Вывод: компилятор, при создании двух анонимных типов, инициализированных одинаковыми
            значениями, применяет оптимизацию и по существу у нас под именами item1 и item2 находиться
            один и тот же объект
            */
        }
    }
}
