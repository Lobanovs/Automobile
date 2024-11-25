using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormCarDetails : Form
    {
        private int carId;
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        public FormCarDetails(int carId)
        {
            InitializeComponent();
            this.carId = carId;

            // Настраиваем форму
            this.Text = "Информация о машине";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Вызываем метод для построения интерфейса
            SetupUI();
        }

        private void SetupUI()
        {
            // Создаем основную панель для отображения информации
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            this.Controls.Add(mainPanel);

            // Панель для изображения автомобиля
            Panel imagePanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200, // Высота панели для изображения
                Margin = new Padding(0, 0, 0, 10),
                Padding = new Padding(10)
            };

            PictureBox carImage = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Добавляем PictureBox в панель изображения
            imagePanel.Controls.Add(carImage);

            // Панель для информации о машине
            Panel carInfoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 300,
                BackColor = Color.LightGray,
                Margin = new Padding(0, 0, 0, 10),
                Padding = new Padding(10)
            };

            // Панель для информации о владельце
            Panel ownerInfoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150,
                BackColor = Color.LightBlue,
                Margin = new Padding(0, 0, 0, 10),
                Padding = new Padding(10)
            };

            // Заглушки для меток (пока без текста)
            Label carDetailsLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 12),
                ForeColor = Color.DarkSlateGray
            };

            Label ownerDetailsLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 12),
                ForeColor = Color.DarkSlateGray
            };

            // Добавляем метки на панели
            carInfoPanel.Controls.Add(carDetailsLabel);
            ownerInfoPanel.Controls.Add(ownerDetailsLabel);

            // Добавляем панели на основную панель
            mainPanel.Controls.Add(ownerInfoPanel);
            mainPanel.Controls.Add(carInfoPanel);
            mainPanel.Controls.Add(imagePanel); // Добавляем панель изображения в основную панель

            // Загружаем данные о машине и владельце
            LoadCarDetails(carDetailsLabel, ownerDetailsLabel, carImage);
        }

        private void LoadCarDetails(Label carDetailsLabel, Label ownerDetailsLabel, PictureBox carImage)
        {
            string query = "SELECT Aut.ID, Aut.City, Aut.Mark, Aut.Model, Aut.Price, Aut.Description, " +
                           "Aut.YearOfIssue, Aut.Mileage, Aut.Color, Aut.ImagePath, Users.Username, Users.Email, Users.PhoneNumber " +
                           "FROM Aut " +
                           "JOIN Users ON Aut.UserId = Users.ID " +
                           "WHERE Aut.ID = @CarId";

            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarId", carId);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Заполняем текстовые метки
                carDetailsLabel.Text =
                    $"Марка: {reader["Mark"]} {reader["Model"]}\n" +
                    $"Год выпуска: {reader["YearOfIssue"]}\n" +
                    $"Пробег: {reader["Mileage"]} км\n" +
                    $"Цвет: {reader["Color"]}\n" +
                    $"Город продажи: {reader["City"]}\n" + // Добавлено отображение города
                    $"Цена: {reader["Price"]} ₽\n\n" +
                    $"Описание:\n{reader["Description"]}";

                ownerDetailsLabel.Text =
                    $"Владелец: {reader["Username"]}\n" +
                    $"Email: {reader["Email"]}\n" +
                    $"Телефон: {reader["PhoneNumber"]}";

                // Загружаем изображение
                string imagePath = reader["ImagePath"].ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        carImage.Image = Image.FromFile(imagePath); // Пытаемся загрузить изображение
                    }
                    catch (Exception)
                    {
                        carImage.Image = null; // Если ошибка, показываем пустое изображение
                    }
                }
                else
                {
                    carImage.Image = null; // Если изображения нет, показываем пустое изображение
                }
            }

            reader.Close();
        }

        private void FormCarDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}









