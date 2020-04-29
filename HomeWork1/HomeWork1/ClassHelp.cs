using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    static class ClassHelp
    {
        public static void Print(string ms, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ms);
        }

        public static void Pause(string ms = "")
        {
            Console.WriteLine(ms);
            Console.ReadKey();
        }
    }
}
