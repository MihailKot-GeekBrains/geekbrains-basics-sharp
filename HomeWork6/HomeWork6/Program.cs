using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace HomeWork6
{
    /*
     * Котков Михаил
     * 
     * */

    //Делегат для задания 1
    public delegate double Fun(double x, double a);
    //Делегат для задания 2
    public delegate double Fun2(double x);

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Задание 1
             * Изменить программу вывода таблицы функции так, 
             * чтобы можно было передавать функции типа double (double, double). 
             * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
             * 
             * */
            Console.WriteLine("Задание 1");
            Console.WriteLine("Таблица функции a*x^2:");
            Table(MyFunc1, -2, 2);
            Console.WriteLine("Таблица функции a*sin(x):");
            Table(MyFunc2, -2, 2);

            /*
             * Задание 2
             * Модифицировать программу нахождения минимума функции так, 
             * чтобы можно было передавать функцию в виде делегата. 
             *  а) Сделать меню с различными функциями и представить пользователю выбор, 
             *      для какой функции и на каком отрезке находить минимум. 
             *      Использовать массив (или список) делегатов, в котором хранятся различные функции.
             *  б) *Переделать функцию Load, чтобы она возвращала массив 
             *      считанных значений. Пусть она возвращает минимум через 
             *      параметр (с использованием модификатора out).
             *      
             * */
            Console.WriteLine("\nЗадание 2");
            Fun2[] arrFunc = new Fun2[3] { Func1, Func2, Func3 };
            Console.WriteLine("Выберите функцию:\n1)x^2\n2)x+x-x^2\n3)(x+70)/x");
            int numberFunc = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите от какого значения пойдёт функция: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите до какого значения пойдёт функция (число должно быть больше предыдущего): ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите шаг: ");
            double step = Convert.ToDouble(Console.ReadLine());
            SaveFunc("data.bin", a, b, step, arrFunc[numberFunc-1]);
            Console.WriteLine("Значение найдены и сохранены в файл!");
            double minimum;
            double[] arrResult = Load("data.bin", out minimum);
            Console.WriteLine("Значение загружены:");
            for (int i = 0; i < arrResult.Length; i++)
                Console.Write(arrResult[i] + " ");
            Console.WriteLine("\nМинимальное значение: " + minimum);

            /*
             * Задание 3
             * Переделать программу Пример использования коллекций для решения следующих задач:
             * а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
             * б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
             * в) отсортировать список по возрасту студента;
             * г) *отсортировать список по курсу и возрасту студента;
             * 
             * */
            Console.WriteLine("\nЗадание 3");
            int bakalavr = 0;
            int magistr = 0;
            int ageCount = 0;
            Dictionary<int, string> ageList = new Dictionary<int, string>();
            ArrayList list = new ArrayList();
            List<Student> students = new List<Student>();
            StreamReader sr = new StreamReader("students_1.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(s[1] + " " + s[0]);
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                    if (int.Parse(s[5]) >= 18 && int.Parse(s[5]) <= 20) ageCount++;
                    if (ageList.ContainsKey(int.Parse(s[5])))
                        ageList[int.Parse(s[5])] = ageList[int.Parse(s[5])] + "," + s[6];
                    else
                        ageList.Add(int.Parse(s[5]), s[6]);
                    Student loadStudent = new Student();
                    loadStudent.secondName = s[0];
                    loadStudent.firstName = s[1];
                    loadStudent.age = int.Parse(s[5]);
                    loadStudent.course = int.Parse(s[6]);
                    students.Add(loadStudent);
                }
                catch { }
            }
            sr.Close();
            list.Sort();
            Console.WriteLine("Всего студентов:{0}", list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine("Список студентов:");
            foreach (var v in list) 
                Console.WriteLine(v);
            Console.WriteLine("Студентов на 5 и 6 крусах: {0}", magistr);
            Console.WriteLine("Студентов в возрасте от 18 до 20: {0}", ageCount);
            foreach(KeyValuePair<int,string> keyValue in ageList)
                if(keyValue.Key >= 18 && keyValue.Key <= 20)
                    Console.WriteLine("Студенты в возрасте {0} лет учатся на курсах {1}", keyValue.Key, keyValue.Value);
            Console.WriteLine("Список всех студентов:");
            foreach (Student student in students)
                Console.WriteLine(student.secondName + " " + student.firstName + " " + student.age + " " + student.course);
            AgeCompaer ac = new AgeCompaer();
            students.Sort(ac);
            Console.WriteLine("Список всех студентов по возрасту:");
            foreach (Student student in students)
                Console.WriteLine(student.secondName + " " + student.firstName + " " + student.age + " " + student.course);
            var orderStudents = students.OrderBy(x => x.course).ThenBy(x => x.age);
            Console.WriteLine("Список всех студентов по курсу, затем возрасту:");
            foreach (Student student in orderStudents)
                Console.WriteLine(student.secondName + " " + student.firstName + " " + student.age + " " + student.course);

            /*
             * Задание 4
             * **Считайте файл различными способами. Смотрите “Пример записи файла 
             *      различными способами”. Создайте методы, которые возвращают 
             *      массив byte (FileStream, BufferedStream), строку для 
             *      StreamReader и массив int для BinaryReader.
             *      
             * */
            Console.WriteLine("\nЗадание 4");

            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long gbyte = 1024 * mbyte;
            long size = mbyte;

            Console.WriteLine("--------- ЗАПИСЬ ---------");
            Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSample("bigdata0.bin", size));
            Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSample("bigdata1.bin", size));
            Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamWriterSample("bigdata2.bin", size));
            Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSample("bigdata3.bin", size));

            Console.WriteLine("--------- ЧТЕНИЕ ---------");
            Stopwatch stopwatch;
            byte[] fileArr = FileStreamReader("bigdata0.bin", out stopwatch);
            Console.WriteLine("FileStream. Milliseconds:{0}", stopwatch.ElapsedMilliseconds);
            int[] binArr = BinaryStreamReader("bigdata1.bin", out stopwatch);
            Console.WriteLine("BinaryReader. Milliseconds:{0}", stopwatch.ElapsedMilliseconds);
            string streamStr = StreamReader("bigdata2.bin", size, out stopwatch);
            Console.WriteLine("StreamReader. Milliseconds:{0}.\nВыходит быстрее, потому что читаю по другому, иначе слишком долго", stopwatch.ElapsedMilliseconds);
            byte[] buffArr = BufferedStreamReader("bigdata3.bin", size, out stopwatch);
            Console.WriteLine("BufferedStream. Milliseconds:{0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Конец программы!");
            Console.ReadKey();
        }

        #region Для задания 4
        //--------- ДЛЯ ЧТЕНИЯ ---------
        static byte[] FileStreamReader(string fileName, out Stopwatch stopwatch)
        {
            List<byte> byteList = new List<byte>();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int k = 0;
            while (k != -1)
            {
                k = fs.ReadByte();
                byteList.Add((byte)k);
            }
            fs.Close();
            stopwatch.Stop();
            return byteList.ToArray();
        }

        static int[] BinaryStreamReader(string fileBame, out Stopwatch stopwatch)
        {
            List<int> intList = new List<int>();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileBame, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int k = 0;
            while (k != -1)
            {
                k = br.Read();
                intList.Add(k);
            }
            fs.Close();
            stopwatch.Stop();
            return intList.ToArray();
        }

        static string StreamReader(string fileName, long size, out Stopwatch stopwatch)
        {
            string str = String.Empty;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //Если читать по символам, то выходит очень и очень долго
            //for (int i = 0; i < size; i++)
                //str += sr.Read();
            str += sr.ReadToEnd();
            fs.Close();
            stopwatch.Stop();
            return str;
        }

        static byte[] BufferedStreamReader(string fileName, long size, out Stopwatch stopwatch)
        {
            List<byte> byteArr = new List<byte>();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i = 0; i < countPart; i++)
            {
                bs.Read(buffer, i, (int)bufsize);
                byteArr.AddRange(buffer);
            }
            fs.Close();
            stopwatch.Stop();
            return byteArr.ToArray();
        }

        //--------- ДЛЯ ЗАПИСИ ---------
        static long FileStreamSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //FileStream fs = new FileStream("D:\\temp\\bigdata.bin", FileMode.CreateNew, FileAccess.Write);
            for (int i = 0; i < size; i++)
                fs.WriteByte(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long BinaryStreamSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
                bw.Write((byte)0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long StreamWriterSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
                sw.Write(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long BufferedStreamSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs,bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i=0;i<countPart;i++)
                bs.Write(buffer, 0, (int)bufsize);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        #endregion

        #region Для задания 3
        struct Student
        {
            public string secondName;
            public string firstName;
            public int age;
            public int course;
        }
	
        class AgeCompaer : IComparer<Student>
        {
            public int Compare(Student o1, Student o2)
            {
                if (o1.age > o2.age)
                {
                    return 1;
                }
                else if (o1.age < o2.age)
                {
                    return -1;
                }
 
                return 0;
            }
        }
        #endregion

        #region Для задания 2
        public static double Func1(double x)
        {
            return x * x;
        }

        public static double Func2(double x)
        {
            return x + x - x * x;
        }

        public static double Func3(double x)
        {
            return (x+70)/x;
        }

        public static void SaveFunc(string fileName, double a, double b, double h, Fun2 f)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double minimum)
        {
            List<double> listik = new List<double>();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            minimum = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                if (d < minimum) minimum = d;
                listik.Add(d);
            }
            bw.Close();
            fs.Close();
            return listik.ToArray();
        }
        #endregion

        #region Для задания 1
        public static void Table(Fun F, double x, double a)
        {
            Console.WriteLine("----- x -------- a -------- y -----");
            while (x <= a)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", x, a, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc1(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        public static double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }
        #endregion
    }
}
