using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSVINXML
{
    /*
     * Котков Михаил
     * 
     * */
    public class Program
    {
        /*
         * Задание 5
         * **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
         * 
         * */
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 5");
            string fileName = "students_1.csv";
            Console.WriteLine("Начинаем выгружать файл " + fileName);
            ArrayList list = new ArrayList();
            List<Student> students = new List<Student>();
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(s[1] + " " + s[0]);
                    Student loadStudent = new Student();
                    loadStudent.secondName = s[0];
                    loadStudent.firstName = s[1];
                    loadStudent.univer = s[2];
                    loadStudent.fakult = s[3];
                    loadStudent.department = s[4];
                    loadStudent.age = int.Parse(s[5]);
                    loadStudent.course = int.Parse(s[6]);
                    loadStudent.group = int.Parse(s[7]);
                    loadStudent.city = s[4];
                    students.Add(loadStudent);
                }
                catch(Exception ex) {
                    Console.WriteLine("Ошибка при открытии файла!\n" + ex.Message);
                    sr.Close();
                    Console.ReadKey();
                    return;
                }
            }
            sr.Close();
            string fileName2 = "students_1.xml";
            Console.WriteLine("Студенты выкачены!\nНачинаем сохранение в XML файл " + fileName2);
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                Stream fStream = new FileStream(fileName2, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, students);
                fStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка, при сохранении файла!\n" + ex.Message);
            }
            Console.WriteLine("Всё готово!");
            Console.ReadKey();
        }

        [Serializable]
        public class Student
        {
            public string secondName;
            public string firstName;
            public string univer;
            public string fakult;
            public string department;
            public int age;
            public int course;
            public int group;
            public string city;

            public Student() { }
        }
    }
}
