using System;

namespace Birthdays
{
    [Serializable]
    public class Birthday
    {
        public string FIO { get; set; }
        public string Date { get; set; }

        public Birthday() { }

        public Birthday(string FIO, string date)
        {
            this.FIO = FIO;
            this.Date = date;
        }
    }
}
