using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork5
{
    static class Message
    {
        //Метод для нахождения слов из сообщения длиной не более N
        public static string WordsLessThanN(string message, int n)
        {
            string result = "";
            string[] pr = message.Split(' ');
            foreach (string str in pr)
                if (str.Length <= n)
                    result += str + " ";
            return result.TrimEnd(' ');
        }

        //Метод для удаления слов окончивающихся на символ
        public static string WordsWithoutLetterAtTheEnd(string message, char symb)
        {
            string result = "";
            string[] pr = message.Split(' ');
            foreach (string str in pr)
                if (str[str.Length - 1] != symb)
                    result += str + " ";
            return result.TrimEnd(' ');
        }

        //Метод возвращает самое длинное слово
        public static string LongestWordInMessage(string message)
        {
            int index = 0;
            int maxLen = 0;
            string[] pr = message.Split(' ');
            for(int i = 0; i < pr.Length; i++)
                if (pr[i].Length > maxLen)
                {
                    maxLen = pr[i].Length;
                    index = i;
                }
            return pr[index];
        }

        //Билдер из самых длинных слов
        public static string BuilderFromLongestWorld(string message)
        {
            int maxLen = 0;
            string[] pr = message.Split(' ');
            for (int i = 0; i < pr.Length; i++)
                if (pr[i].Length > maxLen)
                    maxLen = pr[i].Length;
            StringBuilder builder = new StringBuilder("");
            foreach (string str in pr)
                if (str.Length == maxLen)
                    builder.Append(str + " ");
            builder.Insert(0, "Новая строка билдера: ");
            return builder.ToString();
        }

        //Частота слов в тексте
        public static Dictionary<string, int> FrequencyWords(string[] words, string message)
        {
            Regex regex = new Regex("[#.*?;!,]");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] pr = message.Split(' ');
            foreach (string word in words)
            {
                int count = 0;
                foreach (string str in pr)
                {
                    if (regex.Replace(str, "") == word)
                        count++;
                }
                dict.Add(word, count);
            }
            return dict;
        }
    }
}
