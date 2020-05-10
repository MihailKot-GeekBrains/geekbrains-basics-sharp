using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class TwoDimensionalArray
    {
        //Поля
        private int[,] array;
        Random rnd = new Random();

        //Свойства
        public int Minimum
        {
            get
            {
                int minimum = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (minimum > array[i, j])
                            minimum = array[i, j];
                return minimum;
            }
        }

        public int Maximum
        {
            get
            {
                int maximum = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (maximum < array[i, j])
                            maximum = array[i, j];
                return maximum;
            }
        }

        //Конструкторы
        public TwoDimensionalArray(int oneLength, int twoLength)
        {
            array = new int[oneLength, twoLength];
            for (int i = 0; i < oneLength; i++)
                for (int j = 0; j < twoLength; j++)
                    array[i, j] = rnd.Next(7, 327);
        }

        public TwoDimensionalArray(string path = "arrayTwo.txt")
        {
            ReadArrayFromFile(path);
        }

        //Методы
        //Метод для нахождения суммы всех элементов
        public int SummAllElements()
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    count += array[i, j];
            return count;
        }

        //Метод для нахождения суммы всех элементов больше числа
        public int SummAllElements(int minimum)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] > minimum)
                        count += array[i, j];
            return count;
        }

        //Метод возвращающий номер максимального значения
        public void IndexMaximum(out int index)
        {
            index = 1;
            int prMaximum = index;
            int maximum = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (maximum < array[i, j])
                    {
                        maximum = array[i, j];
                        index = prMaximum;
                    }
                    prMaximum++;
                }
            }
        }

        //Метод для загрузки из файла
        public void ReadArrayFromFile(string path = "arrayTwo.txt")
        {
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream fileStream = File.OpenRead(path))
                    {
                        byte[] arrayByte = new byte[fileStream.Length];
                        fileStream.Read(arrayByte, 0, arrayByte.Length);
                        string allText = Encoding.Default.GetString(arrayByte);

                        string[] lines = allText.Split('\n');
                        string[] prLine = lines[0].Split(' ');
                        array = new int[lines.Length, prLine.Length];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] line = lines[i].Split(' ');
                            for (int j = 0; j < line.Length; j++)
                            {
                                array[i, j] = Convert.ToInt32(line[j]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при работе с файлом!\n" + ex.Message);
                }
            }
            else
                Console.WriteLine("Файл с двумерным массивом не найден!");
        }

        //Метод для сохранения в файл
        public void SaveArrayInFile(string path = "arrayTwo2.txt")
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] arrayByte = System.Text.Encoding.Default.GetBytes(this.ToString());
                    fileStream.Write(arrayByte, 0, arrayByte.Length);
                    Console.WriteLine("Массив записан в файл");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении в файл!\n" + ex.Message);
            }
        }

        //Метод для преобразования в строку
        public string ToString()
        {
            string str = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    str += array[i, j] + " ";
                str += "\n";
            }
            return str;
        }

        //Метод для принта
        public void Print()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
