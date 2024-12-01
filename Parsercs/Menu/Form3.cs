using System;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class Form3 : Form
    {
        private int _userId;         // Хранение ID пользователя
        private string _userRole;   // Хранение роли пользователя

        public Form3(int userId, string userRole)
        {
            InitializeComponent();
            _userId = userId;
            _userRole = userRole;   // Сохраняем роль пользователя
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Проверяем роль пользователя и, если он администратор, показываем кнопку "Управление пользователями"
            if (_userRole == "Admin")
            {
                Button btnManageUsers = new Button
                {
                    Text = "Управление пользователями",
                    Location = new System.Drawing.Point(20, 200), // Устанавливаем позицию кнопки
                    Width = 200
                };
                btnManageUsers.Click += BtnManageUsers_Click;
                this.Controls.Add(btnManageUsers);
            }
        }

        // Переход на форму управления пользователями
        private void BtnManageUsers_Click(object sender, EventArgs e)
        {
            FormManageUsers formManageUsers = new FormManageUsers();
            formManageUsers.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Открываем ленту машин
            FormCars formCars = new FormCars(_userId, _userRole);
            formCars.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Открываем другую форму (Form1)
            Form1 form1 = new Form1(_userId, _userRole);
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Открываем форму с машинами пользователя
            FormMyCars formMyCars = new FormMyCars(_userId);
            formMyCars.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
