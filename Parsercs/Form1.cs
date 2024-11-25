using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Parsercs
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        private Dictionary<string, List<string>> carModels = new Dictionary<string, List<string>>();
        public int CurrentUserId { get; set; }

        private string selectedImagePath;
        private PictureBox pictureBoxPreview;
        private ComboBox comboBox1, comboBox2, comboBox3, comboBox4, comboBox5;
        private TextBox textBox1, textBox2, textBox3;
        private Button button1, btnSelectImage, buttonBackToMenu;
        private Label label1, label2, label3, label4, label5, label6, label7, label8, label9;

        public Form1(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;

            // Добавляем модели машин для марок
            carModels.Add("BMW", new List<string> { "X5", "3 Series", "5 Series" });
            carModels.Add("Mercedes", new List<string> { "C-Class", "E-Class", "S-Class" });
            carModels.Add("Audi", new List<string> { "A4", "A6", "Q7" });

            // Инициализация элементов управления
            InitializeControls();

            // Инициализация подключения к базе данных
            connection = new SqlConnection(connectionString);
        }

        private void InitializeControls()
        {
            // Общие параметры для элементов управления
            Font font = new Font("Segoe UI", 10);

            // Устанавливаем общие стили для формы
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 550);
            this.Text = "Добавление автомобиля";

            // Метка для выбора города
            label1 = new Label { Text = "Выберите город:", Location = new Point(10, 10), Font = font };
            comboBox1 = new ComboBox { Location = new Point(10, 40), Width = 220, Font = font };
            comboBox1.Items.AddRange(new string[] { "Новосибирск", "Москва", "Санкт-Петербург", "Казань", "Лондон" });

            // Метка для выбора марки автомобиля
            label2 = new Label { Text = "Выберите марку:", Location = new Point(10, 80), Font = font };
            comboBox2 = new ComboBox { Location = new Point(10, 110), Width = 220, Font = font };
            foreach (var carBrand in carModels.Keys)
            {
                comboBox2.Items.Add(carBrand);
            }

            // Метка для выбора модели автомобиля
            label3 = new Label { Text = "Выберите модель:", Location = new Point(10, 150), Font = font };
            comboBox3 = new ComboBox { Location = new Point(10, 180), Width = 220, Font = font };

            // Метка для выбора года выпуска
            label4 = new Label { Text = "Год выпуска:", Location = new Point(10, 220), Font = font };
            comboBox4 = new ComboBox { Location = new Point(10, 250), Width = 220, Font = font };
            comboBox4.Items.AddRange(new string[] { "2020", "2021", "2022", "2023", "2024" });

            // Метка для выбора цвета автомобиля
            label5 = new Label { Text = "Цвет автомобиля:", Location = new Point(10, 290), Font = font };
            comboBox5 = new ComboBox { Location = new Point(10, 320), Width = 220, Font = font };
            comboBox5.Items.AddRange(new string[] { "Красный", "Синий", "Черный", "Белый", "Серый" });

            // Метка для ввода цены автомобиля
            label6 = new Label { Text = "Цена автомобиля:", Location = new Point(10, 360), Font = font };
            textBox1 = new TextBox { Location = new Point(10, 390), Width = 220, Font = font };

            // Метка для ввода описания автомобиля
            label7 = new Label { Text = "Описание автомобиля:", Location = new Point(10, 430), Font = font };
            textBox2 = new TextBox { Location = new Point(10, 460), Width = 220, Font = font };

            // Метка для ввода пробега автомобиля
            label8 = new Label { Text = "Пробег автомобиля:", Location = new Point(10, 500), Font = font };
            textBox3 = new TextBox { Location = new Point(10, 530), Width = 220, Font = font };

            // Кнопка для добавления автомобиля в базу данных
            button1 = new Button
            {
                Text = "Добавить машину",
                Location = new Point(250, 80),
                Font = new Font("Segoe UI", 12),
                BackColor = Color.LightSkyBlue,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 40
            };

            // Кнопка для выбора изображения автомобиля
            btnSelectImage = new Button
            {
                Text = "Выбрать изображение",
                Location = new Point(250, 130),
                Font = font,
                BackColor = Color.LightSkyBlue,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 40
            };

            // Кнопка для возврата в меню
            buttonBackToMenu = new Button
            {
                Text = "Назад в меню",
                Location = new Point(250, 180),
                Font = font,
                BackColor = Color.IndianRed,
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 40
            };
            buttonBackToMenu.Click += BtnBackToMenu_Click;

            // Метка для отображения изображения
            label9 = new Label { Text = "Изображение автомобиля:", Location = new Point(250, 220), Font = font };
            pictureBoxPreview = new PictureBox
            {
                Width = 150,
                Height = 150,
                Location = new Point(250, 250),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Подписка на события
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            btnSelectImage.Click += BtnSelectImage_Click;
            button1.Click += Button1_Click;

            // Добавляем элементы на форму
            this.Controls.Add(label1);
            this.Controls.Add(comboBox1);
            this.Controls.Add(label2);
            this.Controls.Add(comboBox2);
            this.Controls.Add(label3);
            this.Controls.Add(comboBox3);
            this.Controls.Add(label4);
            this.Controls.Add(comboBox4);
            this.Controls.Add(label5);
            this.Controls.Add(comboBox5);
            this.Controls.Add(label6);
            this.Controls.Add(textBox1);
            this.Controls.Add(label7);
            this.Controls.Add(textBox2);
            this.Controls.Add(label8);
            this.Controls.Add(textBox3);
            this.Controls.Add(button1);
            this.Controls.Add(btnSelectImage);
            this.Controls.Add(label9);
            this.Controls.Add(pictureBoxPreview);
            this.Controls.Add(buttonBackToMenu);
        }

        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            Form3 menuForm = new Form3(CurrentUserId);
            menuForm.Show();
            this.Close();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string selectedBrand = comboBox2.SelectedItem.ToString();
            if (carModels.ContainsKey(selectedBrand))
            {
                foreach (string model in carModels[selectedBrand])
                {
                    comboBox3.Items.Add(model);
                }
            }
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    pictureBoxPreview.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (comboBox1.SelectedItem == null) { MessageBox.Show("Сначала выберите Город!"); isValid = false; }
            if (comboBox2.SelectedItem == null || comboBox3.SelectedItem == null) { MessageBox.Show("Сначала выберите Марку и модель"); isValid = false; }
            if (textBox1.Text == "") { MessageBox.Show("Введите цену автомобиля"); isValid = false; }
            if (selectedImagePath == "") { MessageBox.Show("Выберите изображение автомобиля!"); isValid = false; }

            if (isValid)
            {
                string query = "INSERT INTO Aut (City, Mark, Model, Price, Description, YearOfIssue, Mileage, Color, UserId, ImagePath) " +
                               "VALUES (@City, @Mark, @Model, @Price, @Description, @YearOfIssue, @Mileage, @Color, @UserId, @ImagePath)";

                SqlCommand command = new SqlCommand(query, connection);

                // Привязка значений к параметрам
                command.Parameters.AddWithValue("@City", comboBox1.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Mark", comboBox2.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Model", comboBox3.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Price", textBox1.Text);
                command.Parameters.AddWithValue("@Description", textBox2.Text);
                command.Parameters.AddWithValue("@YearOfIssue", comboBox4.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Mileage", textBox3.Text);
                command.Parameters.AddWithValue("@Color", comboBox5.SelectedItem.ToString());
                command.Parameters.AddWithValue("@UserId", CurrentUserId); // Используем ID текущего пользователя
                command.Parameters.AddWithValue("@ImagePath", selectedImagePath); // Путь к изображению

                // Открытие подключения и выполнение запроса
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Машина добавлена!");

            }
        }
    }
}
