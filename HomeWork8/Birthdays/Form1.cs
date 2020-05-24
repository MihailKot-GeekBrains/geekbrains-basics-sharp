using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birthdays
{
    /*
     * Котков Михаил
     * 
     * */
    public partial class Form1 : Form
    {
        /*
         * Задание 4
         * *Используя полученные знания и класс TrueFalse в качестве шаблона, разработать собственную утилиту хранения данных 
         * (Например: Дни рождения, Траты, Напоминалка, Английские слова и другие).
         * 
         * */

        DataBase database;

        public Form1()
        {
            InitializeComponent();
        }

        //---------ВЕРХНЕЕ МЕНЮ---------
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new DataBase(sfd.FileName);
                database.Save();
            };
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new DataBase(ofd.FileName);
                database.Load();
            }
            RefreshList();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Кнопка добавить
        private void button1_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Внимание!");
                return;
            }
            FormBirthday fBirthday = new FormBirthday();
            fBirthday.ShowDialog();
            if (fBirthday.isExit)
            {
                database.Add(fBirthday.FIO, fBirthday.date);
                RefreshList();
            }
        }

        //Кнопка редактировать
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите дату рождения!", "Внимание!");
                return;
            }
            FormBirthday fBirthday = new FormBirthday(database[listBox1.SelectedIndex].FIO, database[listBox1.SelectedIndex].Date);
            fBirthday.ShowDialog();
            if (fBirthday.isExit)
            {
                database[listBox1.SelectedIndex].FIO = fBirthday.FIO;
                database[listBox1.SelectedIndex].Date = fBirthday.date;
                RefreshList();
            }
        }

        //Кнопка удалить
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что желаете удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                database.Remove(listBox1.SelectedIndex);
                RefreshList();
            }
        }

        private void RefreshList()
        {
            listBox1.Items.Clear();
            foreach (Birthday br in database)
            {
                listBox1.Items.Add(br.FIO + " " + br.Date);
            }
        }
    }
}
