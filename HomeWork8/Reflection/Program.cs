using System;
using System.Reflection;

namespace Reflection
{
    /*
     * Котков Михаил
     * 
     * */

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Задание 1 
             * С помощью рефлексии выведите все свойства структуры DateTime
             * 
             * */
            Console.WriteLine("Задание 1");
            Type typeDateTime = typeof(DateTime);
            foreach (PropertyInfo property in typeDateTime.GetProperties())
                Console.WriteLine(property.Name);
            Console.ReadKey();
        }
    }
}
