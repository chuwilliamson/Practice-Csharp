using System;
using System.Collections.Generic;

namespace Practice_csharp
{
    delegate string fizzBuzz(int index);

    class Program
    {
        static void Main(string[] args)
        {
            var fizzbuzz1 = FizzBuzz(15, impl_1);
            var fizzbuzz2 = FizzBuzz(15, impl_2);
            System.Console.WriteLine("==========test 0============= \n \n");
            fizzbuzz1.ForEach(f => Console.WriteLine(f));
            System.Console.WriteLine("==========test 0============= \n \n");
            fizzbuzz2.ForEach(f => Console.WriteLine(f));
            Console.WriteLine(fizzbuzz1 == fizzbuzz2);


        }
        public static string impl_2(int i)
        {
            var result = "";
            var fizz = i % 3 == 0;
            var buzz = i % 5 == 0;
            result = fizz && buzz ? "fizzbuzz" : fizz ? "fizz" : buzz ? "buzz" : i.ToString();
            return result;
        }
        public static string impl_1(int i)
        {
            var result = string.Empty;
            result = (i % 3 == 0) ? "fizz" : string.Empty;
            result = (i % 5 == 0) ? result + "buzz" : result;
            result = result == string.Empty ? i.ToString() : result;
            return result;
        }

        public static List<string> FizzBuzz(int n, fizzBuzz fb)
        {
            var results = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                results.Add(fb(i));
            }

            return results;
        }
    }
}
