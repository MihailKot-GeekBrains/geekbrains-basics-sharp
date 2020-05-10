using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
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
             * Дан  целочисленный  массив  из 20 элементов.  
             * Элементы  массива  могут принимать  целые  значения  от –10 000 
             * до 10 000 включительно. Заполнить случайными числами.  
             * Написать программу, позволяющую найти и вывести количество пар 
             * элементов массива, в которых только одно число делится на 3. 
             * В данной задаче под парой подразумевается два подряд идущих элемента массива. 
             * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
             * 
             * */
            Console.WriteLine("Задание 1");
            Random rand = new Random();
            int[] array = new int[5]{6,2,9,-3,6};
            //Заполнение массива
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(-10000, 10001);

            //Находим
            int count = 0;
            for(int i = 0; i < array.Length - 1; i++)
                if(array[i] % 3 == 0 && array[i+1] % 3 != 0 || array[i] % 3 != 0 && array[i+1] % 3 == 0)
                    count++;
            //Выводим массив
            for(int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine("\nОтвет: " + count);

            /*
             * Задание 2
             * Реализуйте задачу 1 в виде статического класса StaticClass;
             * а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
             * б) *Добавьте статический метод для считывания массива из текстового файла. 
             *      Метод должен возвращать массив целых чисел;
             * в)**Добавьте обработку ситуации отсутствия файла на диске.
             * P.S. Файлик содержит массив в формате: 1;2;3;4;5;-10
             * */
            Console.WriteLine("\nЗадание 2");
            count = StaticClass.CompleteFirstQuestion(array);
            Console.WriteLine("Решение задания 1 через статичный метод: " + count);
            array = StaticClass.ReadArrayFromFile();
            if (array != null)
            {
                count = StaticClass.CompleteFirstQuestion(array);
                Console.WriteLine("Решение задания 1 через статичный метод из файла: " + count);
            }
            /*
             * Задание 3
             * а) Дописать класс для работы с одномерным массивом. 
             *      Реализовать конструктор, создающий массив определенного размера и 
             *      заполняющий массив числами от начального значения с заданным шагом. 
             *      Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, 
             *      возвращающий новый массив с измененными знаками у всех элементов массива 
             *      (старый массив, остается без изменений),  метод Multi, умножающий каждый 
             *      элемент массива на определённое число, свойство MaxCount, возвращающее 
             *      количество максимальных элементов. 
             * б)** Создать библиотеку содержащую класс для работы с массивом. 
             *      Продемонстрировать работу библиотеки
             * е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
             * 
             * */
            Console.WriteLine("\nЗадание 3");
            Console.WriteLine("Создаём массив из 10 элементов, начиная с 3, шаг 7:");
            ClassLibrary.CoolArray array3 = new ClassLibrary.CoolArray(10, 3, 7);
            array3.Print();
            Console.WriteLine("\nСумма элементов: " + array3.Sum);
            Console.WriteLine("Переворачиваем знаки: ");
            ClassLibrary.CoolArray array4 = array3.Inverse();
            array4.Print();
            int number = 4;
            Console.WriteLine("\nУмножаем каждый элемент на {0}: ",number);
            array4.Multi(number);
            array4.Print();
            Console.WriteLine("\nКоличество максимальных элементов: " + array4.MaxCount);
            Dictionary<int, int> dict = array4.CountOccurrences();
            foreach (KeyValuePair<int, int> keyVal in dict)
            {
                Console.WriteLine("Элемент: " + keyVal.Key + " Кол-во: " + keyVal.Value);
            }

            /*
             * Задание 4
             * Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
             * Создайте структуру Account, содержащую Login и Password.
             * P.S. Формат файлика: login,password;login2,password2
             * */
            Console.WriteLine("\nЗадание 4");
            List<Account> accounts = new List<Account>();
            Console.WriteLine("Получение информации о аккаунтах!");
            string path = "accounts.txt";
            if (File.Exists(path))
            {
                using (FileStream fileStream = File.OpenRead(path))
                {
                    byte[] arrayByte = new byte[fileStream.Length];
                    fileStream.Read(arrayByte, 0, arrayByte.Length);
                    string allText = Encoding.Default.GetString(arrayByte);

                    string[] loginAndPassword = allText.Split(';');
                    for (int i = 0; i < loginAndPassword.Length; i++)
                    {
                        string[] pr = loginAndPassword[i].Split(',');
                        Account acc = new Account();
                        acc.Login = pr[0];
                        acc.Password = pr[1];
                        accounts.Add(acc);
                    }
                }
                Console.Write("Введите Ваш логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите Ваш пароль: ");
                string password = Console.ReadLine();
                bool flag = false;
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].Login == login && accounts[i].Password == password)
                    {
                        Console.WriteLine("Поздравляю Вы вошли!");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    Console.WriteLine("Такая комбинация логина и пароля не найдена!");
            }
            else
                Console.WriteLine("Не найден файл с аккаунтами!");

            /*
             * Задание 5
             * *а) Реализовать библиотеку с классом для работы с двумерным массивом. 
             * Реализовать конструктор, заполняющий массив случайными числами. 
             * Создать методы, которые возвращают сумму всех элементов массива, 
             * сумму всех элементов массива больше заданного, свойство, возвращающее 
             * минимальный элемент массива, свойство, возвращающее максимальный элемент 
             * массива, метод, возвращающий номер максимального элемента массива 
             * (через параметры, используя модификатор ref или out).
             * **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
             * **в) Обработать возможные исключительные ситуации при работе с файлами.
             * P.S. Формат файлика:
             *      1 2 3 4
             *      7 8 9 -20
             *      5 1 2 6
             * */
            Console.WriteLine("\nЗадание 5");
            ClassLibrary.TwoDimensionalArray twoDimensionArr = new ClassLibrary.TwoDimensionalArray(4, 7);
            twoDimensionArr.Print();
            Console.WriteLine("Сумма всех элементов: " + twoDimensionArr.SummAllElements());
            number = 27;
            Console.WriteLine("Сумма всех элементов больше {0}: {1}", number, twoDimensionArr.SummAllElements(number));
            Console.WriteLine("Минимальное значение: " + twoDimensionArr.Minimum);
            Console.WriteLine("Максимальное значение: " + twoDimensionArr.Maximum);
            int index;
            twoDimensionArr.IndexMaximum(out index);
            Console.WriteLine("Номер максимального значения: " + index);
            Console.WriteLine("Выкачиваем из файлика массив");
            twoDimensionArr = new ClassLibrary.TwoDimensionalArray("arrayTwo.txt");
            twoDimensionArr.Print();
            Console.WriteLine("Сохранение в файлик");
            twoDimensionArr.SaveArrayInFile("arrayTwo2.txt");

            //Ожидаем нажатие клавиши до завершения работы программы
            Console.ReadKey();
        }
    }
}
