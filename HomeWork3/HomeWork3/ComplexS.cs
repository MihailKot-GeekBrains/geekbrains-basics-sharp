using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    struct ComplexS
    {
        public double im;   //Мнимая часть
        public double re;   //Действительная часть

        //Сложение
        public ComplexS Plus(ComplexS x)
        {
            ComplexS y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        //Вычитание
        public ComplexS Minus(ComplexS x)
        {
            ComplexS y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        //Умножение
        public ComplexS Multi(ComplexS x)
        {
            ComplexS y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        //Для преобразования в строку
        public string ToString()
        {
            if(im < 0)
                return re + "" +  im + "i";
            else
                return re + "+" + im + "i";
        }
    }
}
