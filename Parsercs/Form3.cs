using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Скрываем текущую форму (форму 3)
                this.Hide();

                // Создаем новый экземпляр формы 2
                Form2 form2 = new Form2();

                // Отображаем форму 2
                form2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Создаем новый экземпляр формы 2
            Form1 form1 = new Form1();

            // Отображаем форму 2
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
