using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string email;
            do
            {
                Console.Write("Введите e-mail: ");
                email = Console.ReadLine();
                if (email.CheckEmail(email))
                    Console.WriteLine("Верный");
                else
                    Console.WriteLine("Не верный");
            } while (email != "");
            Console.WriteLine("Программа завершена!");
        }
    }

    public static class StringExtension
    {
        public static bool CheckEmail(this string str, string email)
        {
            Regex reg = new Regex(@"(.+)(@)(.+)\.(.+)$");
            Match match = reg.Match(email);
            return match.Success;
        }
    }
}
