using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork4
{
    static class StaticClass
    {
        public static int CompleteFirstQuestion(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] % 3 == 0 && array[i + 1] % 3 != 0 || array[i] % 3 != 0 && array[i + 1] % 3 == 0)
                    count++;
            return count;
        }

        public static int[] ReadArrayFromFile(string path="array.txt")
        {
            int[] array = null;
            try
            {
                //Обработка ситуации отсутствия файла на диске
                if (File.Exists(path))
                {
                    using (FileStream fileStream = File.OpenRead(path))
                    {
                        byte[] arrayByte = new byte[fileStream.Length];
                        fileStream.Read(arrayByte, 0, arrayByte.Length);
                        string allText = Encoding.Default.GetString(arrayByte);

                        array = Array.ConvertAll(allText.Split(';'), int.Parse);
                    }
                }
                else
                    Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при извлечении массива из файла!\n" + ex.Message);
            }
            return array;
        }
    }
}
