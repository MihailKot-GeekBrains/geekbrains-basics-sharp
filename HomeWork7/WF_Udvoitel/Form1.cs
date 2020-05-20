using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    /*
     * Котков Михаил
     * а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
     * б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
     *      Игрок должен получить это число за минимальное количество ходов.
     * в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
     * Вся логика игры должна быть реализована в классе с удвоителем.
     * 
     * */
    public partial class Form1 : Form
    {
        Udvoitel game;

        public Form1()
        {
            InitializeComponent();

            game = new Udvoitel();
        }

        //Главное меню
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            lblNumber.Visible = true;
            btnCommand1.Visible = true;
            btnCommand2.Visible = true;
            btnReset.Visible = true;
            button3.Visible = true;
            MessageBox.Show("Загаданое число: " + game.Start());
            lblNumber.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Меню игры
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = game.Command1();
            MessageGame(game.CheckGame());
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = game.Command2();
            MessageGame(game.CheckGame());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Загаданое число: " + game.Start());
            lblNumber.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblNumber.Text = game.ReturnCommand();
        }

        private void MessageGame(int status)
        {
            switch (status)
            {
                case 1:
                    MessageBox.Show("Поздравляю! Вы победили!\nЧисло ходов: " + game.CountCommand);
                    break;
                case 2:
                    MessageBox.Show("Увы, но Вы проиграли!");
                    break;
                default: break;
            }
        }
    }
}
