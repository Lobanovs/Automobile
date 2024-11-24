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
        private int _userId;  // Хранение ID пользователя

        public Form3(int userId)
        {
            InitializeComponent();
            _userId = userId;  // Сохраняем ID пользователя
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // Пример использования _userId для загрузки данных пользователя
            MessageBox.Show($"Добро пожаловать, ваш ID: {_userId}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                this.Hide();

                // Открываем ленту машин
                FormCars formCars = new FormCars(_userId);
                formCars.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Создаем новый экземпляр формы 2
            Form1 form1 = new Form1(_userId);

            // Отображаем форму 2
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
