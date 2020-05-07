using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Complex
    {
        private double im;  //Мнимая часть
        private double re;  //Действительная часть

        //Свойство для доступа к мнимой части
        public double Im
        {
            get { return im; }
            set
            {
                im = value;
            }
        }

        //Конструкторы
        public Complex()
        {
            im = 0;
            re = 0;
        }

        public Complex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }

        //Метод сложения комплексных чисел
        public Complex Plus(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }

        //Метод вычитания комплексных чисел
        public Complex Minus(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = x2.im - im;
            x3.re = x2.re - re;
            return x3;
        }

        //Метод перемножения комплексных чисел
        public Complex Multi(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = re * x2.im + im * x2.re;
            x3.re = re * x2.re - im * x2.im;
            return x3;
        }

        public string ToString()
        {
            return re + "+" + im + "i";
        }
    }
}
