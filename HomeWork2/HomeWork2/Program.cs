using System;
using System.Data;

namespace HomeWork2
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
             * Задание 1
             * Написать метод, возвращающий минимальное из трёх чисел.
             * 
             * */
            Console.WriteLine("Задание 1");
            Console.Write("Введите число 1: ");
            double chislo1 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите число 2: ");
            double chislo2 = double.Parse(Console.ReadLine().Replace('.', ','));
            Console.Write("Введите число 3: ");
            double chislo3;
            bool proverka = double.TryParse(Console.ReadLine().Replace('.', ','), out chislo3);
            if (!proverka)
                Console.WriteLine("При преобразовании числа 3, произошла ошибка!");
            double result = MinOfThreeNumbers(chislo1, chislo2, chislo3);
            Console.WriteLine("Минимальное значение: " + result);

            /*
             * Задание 2
             * Написать метод подсчета количества цифр числа.
             * 
             * */
            Console.WriteLine("\nЗадание 2");
            Console.Write("Введите целое число: ");
            int chislo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Количество цифр в числе метод 1: " + CountOfDigits1(chislo));
            Console.WriteLine("Количество цифр в числе метод 2: " + CountOfDigits2(chislo));

            /*
             * Задание 3
             * С клавиатуры вводятся числа, пока не будет введен 0. 
             * Подсчитать сумму всех нечетных положительных чисел.
             * 
             * */
            Console.WriteLine("\nЗадание 3");
            double input = 0;
            result = 0;
            do
            {
                Console.Write("Введите число: ");
                input = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
                if (input > 0 && input % 2 != 0)
                {
                    result += input;
                }
            } while (input != 0);
            Console.WriteLine("Сумма равна: " + result);

            /*
             * Задание 4
             * Реализовать метод проверки логина и пароля. 
             * На вход метода подается логин и пароль. 
             * На выходе истина, если прошел авторизацию, и ложь, если не прошел 
             * (Логин: root, Password: GeekBrains). 
             * Используя метод проверки логина и пароля, 
             * написать программу: пользователь вводит логин и пароль, 
             * программа пропускает его дальше или не пропускает. 
             * С помощью цикла do while ограничить ввод пароля тремя попытками.
             * 
             * */
            Console.WriteLine("\nЗадание 4");
            int inputAttempts = 3;
            do
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                if (CheckLogin(login, password))
                {
                    Console.WriteLine("Поздравляею! Вы вошли!");
                    break;
                }
                else
                {
                    if (inputAttempts - 1 != 0)
                        Console.WriteLine("Данная комбинация логина и пароля не найдена!\nПовторите попытку!");
                    else
                    {
                        Console.WriteLine("Увы, для вас закрыт доступ!");
                        Console.ReadKey();
                        return;
                    }
                }
                inputAttempts--;
            } while (inputAttempts != 0);

            /*
             * Задание 5
             * а) Написать программу, которая запрашивает массу и рост человека, 
             * вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
             * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
             * 
             * */
            Console.WriteLine("\nЗадание 5");
            Console.Write("Введите свою массу в кг: ");
            double weight = Convert.ToDouble(Console.ReadLine().Replace('.',','));
            Console.Write("Введите свой рост в метрах: ");
            double height = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            result = weight / (height * height);
            if (result <= 16)
                Console.WriteLine("У Вас дефицит массы!");
            else if (result > 16 && result <= 18.5)
                Console.WriteLine("Недостаточная масса тела!");
            else if (result > 18.5 && result <= 25)
                Console.WriteLine("Всё в норме!");
            else if (result > 25 && result <= 30)
                Console.WriteLine("Избыточная масса тела!");
            else if (result > 30 && result <= 35)
                Console.WriteLine("Ожирение первой степени!");
            else if (result > 35 && result <= 40)
                Console.WriteLine("Ожирение второй степени!");
            else if (result > 40)
                Console.WriteLine("Ожирение третьей степени!");

            double needWeight = 21 * (height * height);
            double resultWeight = needWeight - weight;
            if (resultWeight > 0)
                Console.WriteLine("Вам необходимо набрать " + resultWeight + " кг");
            else
                Console.WriteLine("Вам необходимо похудеть на " + Math.Abs(resultWeight) + " кг");

            /*
             * 
             * Задание 6
             * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
             * «Хорошим» называется число, которое делится на сумму своих цифр. 
             * Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
             * 
             * */
            Console.WriteLine("\nЗадание 6");
            Console.WriteLine("Происходит расчёт!");
            int count = 0;
            DateTime startTime = DateTime.Now;
            for (int i = 1; i < 1000000000; i++)
            {
                if (i % SummaNumber(i) == 0)
                    count++;
                Console.Write("Посчитано для числа: " + i + "\r");
            }
            TimeSpan stop = DateTime.Now - startTime;
            Console.WriteLine("Количество \"Хороших\" чисел: " + count);
            Console.WriteLine("Время выполнения: " + stop.TotalMilliseconds.ToString());

            /*
             * Задание 7
             * a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
             * б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
             * 
             * */
            Console.WriteLine("\nЗадание 7");
            Console.Write("Введите число a: ");
            int chisloA = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число b: ");
            int chisloB = Convert.ToInt32(Console.ReadLine());
            RecursionPrint(chisloA, chisloB);
            Console.WriteLine();
            int summa = RecursionSumma(chisloA, chisloB);
            Console.WriteLine("Сумма между числами равна: " + summa);
            Console.ReadKey();
        }

        //Функция для суммирования чисел в диапазоне через рекурсию
        static int RecursionSumma(int chisloA, int chisloB)
        {
            int summa = chisloA;
            if (chisloA < chisloB)
                summa += RecursionSumma(++chisloA, chisloB);
            return summa;
        }

        //Функция выводит числа в диапазоне через рекурсию
        static void RecursionPrint(int chisloA, int chisloB)
        {
            Console.Write("Число: " + chisloA + " ");
            if (chisloA < chisloB)
                RecursionPrint(++chisloA, chisloB);
        }

        //Находит сумму цифр числа
        static int SummaNumber(int chislo)
        {
            int summa = 0;
            string str = Convert.ToString(chislo);
            for (int i = 0; i < str.Length; i++)
                summa += Convert.ToInt32(str[i].ToString());
            return summa;
        }

        //Проверяет на правильность ввода логина и пароля
        static bool CheckLogin(string login, string password)
        {
            string correctLogin = "root";
            string correctPassword = "GeekBrains";
            if (login == correctLogin && password == correctPassword)
                return true;
            return false;
        }

        //Подсчитывает количество цифр в числе
        static int CountOfDigits1(int chislo)
        {
            string str = Convert.ToString(chislo);
            if (chislo < 0)
                return str.Length - 1;
            else
                return str.Length;
        }

        //Подсчитывает количество цифр в числе
        //Но работает только с числами > 0
        static int CountOfDigits2(int chislo)
        {
            int count = 0;
            while (chislo > 0)
            {
                chislo /= 10;
                count++;
            }
            return count;
        }

        //Функция для нахождения минимума среди трёх чисел
        static double MinOfThreeNumbers(double a, double b, double c)
        {
            double minimum = a;
            if (b < minimum)
                minimum = b;
            if (c < minimum)
                minimum = c;
            return minimum;

        }
    }
}
