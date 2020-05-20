using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    /*
     * Котков Михаил
     * Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, 
     * а человек пытается его угадать за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.  
     * a) Для ввода данных от человека используется элемент TextBox;
     * б) **Реализовать отдельную форму c TextBox для ввода числа.
     * 
     * */
    public partial class Form1 : Form
    {
        private int number;
        private int countNumber = 0;

        public Form1()
        {
            InitializeComponent();

            label1.Text = string.Empty;

            Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void Start()
        {
            Random rand = new Random();
            number = rand.Next(1, 101);
            countNumber = 0;
        }

        public bool CheckNumber(int nextNumber)
        {
            countNumber++;
            if (nextNumber == number)
            {
                label1.Text = "Победа!\nЧисло попыток: " + countNumber;
                Start();
                return true;
            }
            if(nextNumber > number)
                label1.Text = "Меньше!";
            if (nextNumber < number)
                label1.Text = "Больше!";
            return false;
        }
    }
}
