using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    /*
     * 
     * Котков Михаил
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
             * В результате вся информация выводится в одну строчку:
             *      а) используя  склеивание;
             *      б) используя форматированный вывод;
             *      в) используя вывод со знаком $.
             *      
             * */
            Console.WriteLine("---Задание 1---");
            Console.Write("Введите Ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите Вашу фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите Ваш возраст: ");
            double age = Convert.ToDouble(Console.ReadLine().Replace('.',','));
            Console.Write("Введите Ваш рост: ");
            double height = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите Ваш вес: ");
            double weight = Convert.ToDouble(Console.ReadLine().Replace('.', ','));

            Console.WriteLine("Вы только что заполнили анкету и мы получили следующие значения:\nВаше имя: {0}\nВаша фамилия:{1}", name, lastName);
            Console.WriteLine(String.Format("А ваш возраст составляет: {0} лет", age));
            Console.WriteLine("Ваш рост: " + height);
            Console.WriteLine($"И на последок, Ваш вес: {weight}");

            /*
             * Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по 
             * формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
             * */
            Console.WriteLine("---Задание 2---");
            Console.Write("Введите вес в килограммах: ");
            weight = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите рост в метрах: ");
            height = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            double l = weight / (height * height);
            Console.WriteLine("Индекс массы тела равен: " + l);

            /*
             * 
             * а) Написать программу, которая подсчитывает расстояние между 
             * точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
             * Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
             * б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
             * 
             * */
            Console.WriteLine("---Задание 3---");
            Console.Write("Введите точку x1: ");
            double x1 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите точку y1: ");
            double y1 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите точку x2: ");
            double x2 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите точку y2: ");
            double y2 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            double result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между точками: {0:0.00}", result);
            Path(x1, y1, x2, y2);

            /*
             * Написать программу обмена значениями двух переменных:
             *      а) с использованием третьей переменной;
             *      б) *без использования третьей переменной.
             *      
             * */
            Console.WriteLine("---Задание 4---");
            Console.Write("Введите число 1: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число 2: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы ввели a=  " + a + " b = " + b);
            int c = a;
            a = b;
            b = c;
            Console.WriteLine("Мы для Вас поменяли местами a=  " + a + " b = " + b);
            a ^= b;
            b ^= a;
            a ^= b;
            Console.WriteLine("Поменяли местами ещё разок, но без ещё одной переменной a=  " + a + " b = " + b);

            /*
             * а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
             * б) *Сделать задание, только вывод организовать в центре экрана.
             * в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
             * 
             * */
            Console.WriteLine("---Задание 5---");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Введите город: ");
            string city = Console.ReadLine();
            Console.WriteLine("Выводим информацию:\nВас зовут " + lastName + " " + name + "\nВы живёте в " + city);
            Console.WriteLine("Попытка вывести в центре экрана:");
            Console.WriteLine("Внимание! Сейчас консоль будет очищена");
            Console.ReadKey();
            Console.Clear();
            int bufWidth = Console.WindowWidth / 2;
            int bufHeight = Console.WindowHeight / 2;
            bufWidth -= 10;
            bufHeight -= 5;
            Console.SetCursorPosition(bufWidth, bufHeight++);
            Console.Write("Вас зовут: " + name);
            Console.SetCursorPosition(bufWidth, bufHeight++);
            Console.Write("Ваша фамилия: " + lastName);
            Console.SetCursorPosition(bufWidth, bufHeight++);
            Console.WriteLine("Вы живёте в: " + city + "\n\n\n\n\n\n");
            Console.WriteLine("Внимание! Сейчас консоль будет очищена");
            Console.ReadKey();
            Console.Clear();
            bufHeight -= 3;
            Print("Вас зовут: " + name, bufWidth, bufHeight++);
            Print("Ваша фамилия: " + lastName, bufWidth, bufHeight++);
            Print("Вы живёте в: " + city + "\n\n\n\n\n\n", bufWidth, bufHeight++);

            /*
             * *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
             * 
             * */
            Console.WriteLine("---Задание 6---");
            ClassHelp.Pause("Сейчас консоль будет очищена!");
            Console.Clear();
            ClassHelp.Print("Конец\n\n\n", bufWidth, bufHeight-3);
        }

        static void Path(double x1, double y1, double x2, double y2)
        {
            double result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между точками из метода: " + result);
        }

        static void Print(string ms, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ms);
        }
    }
}
