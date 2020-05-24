using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthdays
{
    class BirthdayEnum : IEnumerator
    {
        public Birthday[] birthdays;

        int position = -1;

        public BirthdayEnum(Birthday[] list)
        {
            birthdays = list;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Birthday Current
        {
            get
            {
                try
                {
                    return birthdays[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < birthdays.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
