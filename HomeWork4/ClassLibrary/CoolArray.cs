using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class CoolArray
    {
        //Поля
        private int[] a;
        Random rnd = new Random();

        //Свойства
        public int Sum
        {
            get
            {
                return a.Sum();
            }
        }

        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = a.Max();
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max)
                        count++;
                return count;
            }
        }

        //Конструкторы
        public CoolArray(int n)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(1, 101);
        }

        public CoolArray(string filename)
        {
            //Если файл существует
            if (File.Exists(filename))
            {
                //Считываем все строки в файл 
                string[] ss = File.ReadAllLines(filename);
                a = new int[ss.Length];
                //Переводим данные из строкового формата в числовой
                for (int i = 0; i < ss.Length; i++)
                    a[i] = int.Parse(ss[i]);
            }
            else Console.WriteLine("Error load file");
        }

        public CoolArray(int length, int beginValue, int step)
        {
            a = new int[length];
            for (int i = 0; i < a.Length; i++, beginValue += step)
                a[i] = beginValue;
        }

        public int Max
        {
            get
            {
                return a.Max();
            }
        }

        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        //Меняем знак не противоположный и возвращаем новый массив
        public CoolArray Inverse()
        {
            CoolArray pr = new CoolArray(a.Length);
            for (int i = 0; i < a.Length; i++)
                pr[i] = -a[i];
            return pr;
        }

        //Умножаем каждый элемент массива на число
        public void Multi(int number)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= number;
        }

        //Подсчёт количества вхождений каждого элементам в массив
        public Dictionary<int, int> CountOccurrences()
        {
            //Находим уникальные значений в массиве
            var pr = a.Distinct();
            //Создаём словарь, где ключ - значение массива, значение - количество вхождений в массив
            Dictionary<int, int> dict = new Dictionary<int, int>(pr.Count());
            foreach (var k in pr)
                dict.Add(k, a.Count(x => x.Equals(k)));
            return dict;
        }

        //Вывод на экран
        public void Print()
        {
            foreach (int el in a)
                Console.Write("{0,4}", el);
        }
    }
}
