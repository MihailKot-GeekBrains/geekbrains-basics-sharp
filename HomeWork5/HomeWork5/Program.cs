using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork5
{
    /*
     * Котков Михаил
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            /*
             * Задание 1
             * Создать программу, которая будет проверять корректность ввода логина. 
             * Корректным логином будет строка от 2 до 10 символов, содержащая только 
             * буквы латинского алфавита или цифры, при этом цифра не может быть первой:
             * а) без использования регулярных выражений;
             * б) **с использованием регулярных выражений.
             * 
             * */
            Console.WriteLine("Задание 1");
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            bool isCheck = false;
            if (login.Length >= 2 && login.Length <= 10)
            {
                if (!char.IsDigit(login[0]))
                {
                    isCheck = true;
                    for (int i = 0; i < login.Length; i++)
                    {
                        int k = 'z';
                        int d = 'a';
                        if(!(char.IsDigit(login[i]) || (login[i] >= 'a' && login[i] <= 'z') || (login[i] >= 'A' && login[i] <= 'Z')))
                        {
                            isCheck = false;
                        }
                    }
                }
            }
            if (isCheck)
                Console.WriteLine("Ваш логин валиден!");
            else
                Console.WriteLine("Логин не прошел проверку!");
            Console.WriteLine("Через регулярку:");

            string pattern = @"\b([a-z]{1}[0-9a-z]{1,9})$";
            if (Regex.IsMatch(login, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Введён верный логин!");
            }
            else
                Console.WriteLine("Ошибка в вводе логина!");
            #endregion

            #region Task 2
            /*
             * Задание 2
             * Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
             * а) Вывести только те слова сообщения,  которые содержат не более n букв.
             * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
             * в) Найти самое длинное слово сообщения.
             * г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
             * д) ***Создать метод, который производит частотный анализ текста. 
             *      В качестве параметра в него передается массив слов и текст, в качестве 
             *      результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
             *      Здесь требуется использовать класс Dictionary.
             *      
             * */
            Console.WriteLine("\nЗадание 2");
            string message = "Это текст с разными словами! Есть длинные слова, а есть коротенькие! Тут есть слова, которые повторяются! Это ведь слова, слова, слова! Ух и коротенькие!";
            Console.WriteLine("Сообщение: \n" + message);
            int len = 4;
            Console.WriteLine("Слова из сообщения длиной не более {0} символов: \n{1}", len, Message.WordsLessThanN(message, len));
            char symb = 'ь';
            Console.WriteLine("Удаляю слова, которые заканчиваются на {0}: \n{1}", symb, Message.WordsWithoutLetterAtTheEnd(message, symb));
            Console.WriteLine("Самое длинное слово: \n" + Message.LongestWordInMessage(message));
            Console.WriteLine("Строка из самых длинных слов: \n" + Message.BuilderFromLongestWorld(message));
            Dictionary<string, int> dict = Message.FrequencyWords(new string[]{"Есть", "не", "с", "слова"}, message);
            foreach (KeyValuePair<string, int> keyVal in dict)
            {
                Console.WriteLine("Слово: \"" + keyVal.Key + "\" встречается " + keyVal.Value);
            }
            #endregion
            #region Task 3
            /*
             * Задание 3
             * *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
             *      Например:
             *      badc являются перестановкой abcd.
             * 
             * */
            Console.WriteLine("\nЗадание 3");
            Console.Write("Введите слово 1: ");
            string firstWord = Console.ReadLine();
            Console.Write("Введите слово 2: ");
            string secondWord = Console.ReadLine();
            if (PermutationLettersInWord(firstWord, secondWord))
                Console.WriteLine("Введённые слова являются перестановкой!");
            else
                Console.WriteLine("Не являются перестановкой!");
            #endregion
            #region Task 4
            /*
             * Задание 4
             * 
             * *Задача ЕГЭ.
             * 
             * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов 
             * некоторой средней школы. В первой строке сообщается количество учеников N, 
             * которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
             * 
             * <Фамилия> <Имя> <оценки>,
             * 
             * где <Фамилия> — строка, состоящая не более чем из 20 символов, 
             * <Имя> — строка, состоящая не более чем из 15 символов, 
             * <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
             * <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. 
             * Пример входной строки:
             * 
             * Иванов Петр 4 5 3
             * 
             * Требуется написать как можно более эффективную программу, 
             * которая будет выводить на экран фамилии и имена трёх худших 
             * по среднему баллу учеников. Если среди остальных есть ученики, 
             * набравшие тот же средний балл, что и один из трёх худших, 
             * следует вывести и их фамилии и имена.
             * 
             * */
            Console.WriteLine("\nЗадание 4");
            Console.Write("Введите количество учеников: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<double> estimations = new List<double>();        //Тут будут оценки трёх худших
            List<string> schoolchildrens = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string schoolchildren = Console.ReadLine();
                string[] pr = schoolchildren.Split(' ');
                double estimation = (Convert.ToDouble(pr[2]) + Convert.ToDouble(pr[3]) + Convert.ToDouble(pr[4])) / 3;
                //Вычисляем три худших средних оценки
                if (estimations.Count >= 3)
                {
                    //Оценки заменяем не все подряд, а только лучшую!
                    int indexMax = 0;
                    for (int j = 0; j < estimations.Count; j++)
                        if (estimations[j] > estimations[indexMax])
                            indexMax = j;
                    if (estimations[indexMax] > estimation)
                        estimations[indexMax] = estimation;
                }
                else
                    estimations.Add(estimation);
                schoolchildrens.Add(schoolchildren);
            }
            //Теперь проходим по всем ученикам, вычисляем их средний бал и берём тех, кто попал в диапазон худших
            string result = "";
            foreach(string schoolchildren in schoolchildrens)
            {
                string[] pr = schoolchildren.Split(' ');
                double estimation = (Convert.ToDouble(pr[2]) + Convert.ToDouble(pr[3]) + Convert.ToDouble(pr[4])) / 3;
                if (estimations.Contains(estimation))
                    result += pr[0] + " " + pr[1] + "\n";
            }
            Console.WriteLine("Худшие из учеников: \n{0}", result);
            #endregion
        }

        //Проверка на перестановку слов
        static bool PermutationLettersInWord(string firstWord, string secondWord)
        {
            if (firstWord.Length != secondWord.Length)
                return false;
            List<int> indexes = new List<int>();
            foreach(char ch in firstWord)
            {
                bool isCheck = false;
                for (int i = 0; i < secondWord.Length; i++)
                {
                    if(ch == secondWord[i] && !indexes.Contains(i))
                    {
                        isCheck = true;
                        indexes.Add(i);
                        break;
                    }
                }
                if (!isCheck)
                    return false;
            }
            return true;
        }
    }
}
