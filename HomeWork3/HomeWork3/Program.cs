using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
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
             * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
             * Продемонстрировать работу структуры.
             * б) Дописать класс Complex, добавив методы вычитания и произведения чисел. 
             * Проверить работу класса.
             * в) Добавить диалог с использованием switch демонстрирующий работу класса.
             * P.S. Чтобы разместить структуру и класс в одном проекте, структуру назвал ComplexS
             * */
            Console.WriteLine("Задание 1");
            //Работа со структурой
            ComplexS complex1;
            complex1.re = 1;
            complex1.im = 3;

            ComplexS complex2;
            complex2.re = 4;
            complex2.im = -5;

            Console.WriteLine("Комлпексное число 1: " + complex1.ToString());
            Console.WriteLine("Комлпексное число 2: " + complex2.ToString());

            ComplexS result = complex1.Plus(complex2);
            Console.WriteLine("Результат сложения структур Complex: " + result.ToString());
            result = complex1.Minus(complex2);
            Console.WriteLine("Результат вычитания структур Complex: " + result.ToString());
            result = complex1.Multi(complex2);
            Console.WriteLine("Результат сложения структур Complex: " + result.ToString());

            //Работа с классом
            Complex complex3;
            complex3 = new Complex(1, 1);
            Complex complex4 = new Complex(2, 2);
            Complex result2;

            Console.WriteLine("Комплексное число 1: " + complex3.ToString());
            Console.WriteLine("Комплексное число 2: " + complex4.ToString());

            Console.WriteLine("Выберите действие, которое хотите совершить с числами:\n" +
                "--- 1) Сложить числа\n--- 2) Вычесть числа\n--- 3) Перемножить числа");
            Console.Write("Ваша команда: ");
            int command;
            bool isCheck = int.TryParse(Console.ReadLine(), out command);
            if (isCheck)
            {
                switch (command)
                {
                    case 1:
                        result2 = complex3.Plus(complex4);
                        Console.WriteLine(result2.ToString());
                        break;
                    case 2:
                        result2 = complex3.Minus(complex4);
                        Console.WriteLine(result2.ToString());
                        break;
                    case 3:
                        result2 = complex3.Multi(complex4);
                        Console.WriteLine(result2.ToString());
                        break;
                    default:
                        Console.WriteLine("Извините, но такой команды нет!");
                        break;
                }
            }
            else
                Console.WriteLine("Ошибка при преобразовании команды!");

            /*
             * Задание 2
             * а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
             * Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму 
             * вывести на экран, используя tryParse.
             * 
             * */
            Console.WriteLine("\nЗадание 2");
            string str = "";
            string arr = "";
            double summa = 0;
            do
            {
                Console.Write("Введите число (0 для выхода): ");
                str = Console.ReadLine();
                double k;
                isCheck = double.TryParse(str, out k);
                if (isCheck)
                {
                    if (k % 2 != 0 && k > 0)
                    {
                        arr += str + ",";
                        summa += k;
                    }
                }
            } while (str.Trim() != "0");
            Console.WriteLine("Вы сложили следующие числа:\n" + arr.TrimEnd(','));
            Console.WriteLine("Их сумма равна: " + summa);

            /*
             * Задание 3
             * *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
             * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
             * Написать программу, демонстрирующую все разработанные элементы класса.
             * * Добавить свойства типа int для доступа к числителю и знаменателю;
             * * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
             * ** Добавить проверку, чтобы знаменатель не равнялся 0. 
             *    Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
             * *** Добавить упрощение дробей.
             * 
             * */
            Console.WriteLine("\nЗадание 3");
            RationalNumber chislo1 = new RationalNumber(2, 3);
            RationalNumber chislo2 = new RationalNumber(5, 7);
            Console.WriteLine("Дробь 1: " + chislo1.ToString());
            Console.WriteLine("Дробь 2: " + chislo2.ToString());
            Console.WriteLine("Сложение дробей: " + chislo1.Plus(chislo2).ToString());
            Console.WriteLine("Вычитание дробей: " + chislo1.Minus(chislo2).ToString());
            Console.WriteLine("Умножение дробей: " + chislo1.Multiplication(chislo2).ToString());
            Console.WriteLine("Деление дробей: " + chislo1.Division(chislo2).ToString());
            chislo1.Numerator = 1;
            chislo1.Denominator = 8;
            Console.WriteLine("Дробь 1 изменена через свойство: " + chislo1.ToString());
            //chislo1.DecimalFraction = 10;   //Только для чтения
            Console.WriteLine("Десятичная дробь 1: " + chislo1.DecimalFraction.ToString());
            //Попытка ввести знаменатель 0
            try
            {
                RationalNumber chislo3 = new RationalNumber(4, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! " + ex.Message);
            }
            //Упрощение дробей
            RationalNumber chislo4 = new RationalNumber(9, 27);
            Console.WriteLine("Дробь 4: " + chislo4.ToString());
            chislo4.SimplifyingFractions();
            Console.WriteLine("Дробь 4 после упрощения: " + chislo4.ToString());
        }
    }
}
