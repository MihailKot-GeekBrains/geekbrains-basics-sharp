using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class RationalNumber
    {
        private int numerator;      //Числитель
        private int denominator;    //Знаменатель

        //Свойства
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value != 0)
                    denominator = value;
                else
                    throw new ArgumentException("Знаменатель не может быть равен 0");
            }
        }

        //Свойство только для чтения
        public double DecimalFraction
        {
            get
            {
                return Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
            }
        }

        //Конструкторы
        public RationalNumber() { }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        //Сложение дробей
        public RationalNumber Plus(RationalNumber y)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = this.Numerator * y.Denominator + y.Numerator * this.Denominator;
            result.Denominator = this.Denominator * y.Denominator;
            return result;
        }

        //Вычитание дробей
        public RationalNumber Minus(RationalNumber y)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = this.Numerator * y.Denominator - y.Numerator * this.Denominator;
            result.Denominator = this.Denominator * y.Denominator;
            return result;
        }

        //Умножение дробей
        public RationalNumber Multiplication(RationalNumber y)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = this.Numerator * y.Numerator;
            result.Denominator = this.Denominator * y.Denominator;
            return result;
        }

        //Деление дробей
        public RationalNumber Division(RationalNumber y)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = this.Numerator * y.Denominator;
            result.Denominator = this.Denominator * y.Numerator;
            return result;
        }

        //Упрощение дробей
        public void SimplifyingFractions()
        {
            for (int i = 2; i < 10; i++)
                while (Numerator % i == 0 && Denominator % i == 0)
                {
                    Numerator /= i;
                    Denominator /= i;
                }
        }

        //Для вывода
        public string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }
}
