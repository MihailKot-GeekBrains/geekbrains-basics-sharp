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
    public partial class FormBirthday : Form
    {
        public bool isExit = false;
        public string FIO = "";
        public string date = "";

        public FormBirthday(string FIO = "", string date = "")
        {
            InitializeComponent();
            textBox1.Text = FIO;
            textBox2.Text = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                isExit = true;
                FIO = textBox1.Text;
                date = textBox2.Text;
                this.Close();
            }
        }
    }
}
