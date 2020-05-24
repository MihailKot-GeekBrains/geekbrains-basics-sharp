using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Birthdays
{
    class DataBase : IEnumerable
    {
        private string fileName;
        private List<Birthday> list;

        public string FileName
        {
            set { fileName = value; }
        }

        public DataBase(string fileName)
        {
            this.fileName = fileName;
            list = new List<Birthday>();
        }

        public void Add(string FIO, string date)
        {
            list.Add(new Birthday(FIO, date));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        // Индексатор - свойство для доступа к закрытому объекту
        public Birthday this[int index]
        {
            get { return list[index]; }
        }

        public void Save()
        {
            try {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Birthday>));
                Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, list);
                fStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка, при сохранении файла!\n" + ex.Message);
            }
        }

        public void Load()
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Birthday>));
                Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                list = (List<Birthday>)xmlFormat.Deserialize(fStream);
                fStream.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка, при открытии файла!\n" + ex.Message);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new BirthdayEnum(list.ToArray());
        }
    }
}
