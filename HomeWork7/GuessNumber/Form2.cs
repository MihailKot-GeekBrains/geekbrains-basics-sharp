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
     * 
     * */
    public partial class Form2 : Form
    {
        Form1 formochka;
        public Form2(Form1 formochka)
        {
            InitializeComponent();

            this.formochka = formochka;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formochka.CheckNumber(Convert.ToInt32(textBox1.Text)))
                this.Close();
        }
    }
}
