using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Udvoitel
{
    /*
     * Котков Михаил
     * 
     * */
    class Udvoitel
    {
        private int number;
        private int countCommand;
        public int currentNumber { get; set; }

        private Stack<int> stackCommand = new Stack<int>();

        public int CountCommand
        {
            get
            {
                return countCommand;
            }
        }

        public string Start()
        {
            stackCommand.Clear();
            currentNumber = 0;
            countCommand = 0;
            number = new Random().Next(10, 100);
            return number.ToString();
        }

        public string Command1()
        {
            currentNumber++;
            countCommand++;
            stackCommand.Push(1);
            return currentNumber.ToString();
        }

        public string Command2()
        {
            currentNumber *= 2;
            countCommand++;
            stackCommand.Push(2);
            return currentNumber.ToString();
        }

        public string ReturnCommand()
        {
            if (stackCommand.Count > 0)
            {
                switch (stackCommand.Pop())
                {
                    case 1:
                        currentNumber--;
                        break;
                    case 2:
                        currentNumber /= 2;
                        break;
                }
                countCommand++;
            }
            return currentNumber.ToString();
        }

        public int CheckGame()
        {
            if (currentNumber == number)
                return 1;
            if (currentNumber > number)
                return 2;
            return 0;
        }
    }
}
