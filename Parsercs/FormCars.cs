using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Parsercs
{
    public partial class FormCars : Form
    {
        private int _userId;
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        // Элементы интерфейса
        private FlowLayoutPanel flowLayoutPanelCars;
        private ComboBox comboBoxCities;

        // Коллекция для хранения информации о машинах
        private List<CarInfo> carInfoList = new List<CarInfo>();

        public FormCars(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Настройка интерфейса
            SetupUI();
        }

        private void SetupUI()
        {
            // Создаем ComboBox для фильтрации по городам
            comboBoxCities = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10),
                Height = 30
            };
            comboBoxCities.SelectedIndexChanged += ComboBoxCities_SelectedIndexChanged;

            // Создаем FlowLayoutPanel для отображения машин
            flowLayoutPanelCars = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            // Кнопка для возвращения в меню
            Button backButton = new Button
            {
                Text = "В меню",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Arial", 12),
                BackColor = Color.LightGray
            };
            backButton.Click += BackButton_Click;

            // Добавляем элементы на форму
            Controls.Add(flowLayoutPanelCars);
            Controls.Add(comboBoxCities);
            Controls.Add(backButton);  // Добавляем кнопку "В меню"
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // Открываем форму меню (например, Form3) и закрываем текущую форму
            Form3 menuForm = new Form3(_userId);
            menuForm.Show();
            this.Close();
        }

        private void FormCars_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            // Загружаем данные о машинах и список городов
            LoadCars();
            LoadCities();
        }

        private void LoadCars(string cityFilter = null)
        {
            // Очищаем FlowLayoutPanel и список машин
            flowLayoutPanelCars.Controls.Clear();
            carInfoList.Clear();

            // SQL запрос для получения машин
            string query = "SELECT Aut.ID, Aut.City, Aut.Mark, Aut.Model, Aut.Price, Aut.Description, " +
                           "Aut.YearOfIssue, Aut.Mileage, Aut.Color, Aut.ImagePath, " + // Добавлено поле ImagePath
                           "Users.Username, Users.Email, Users.PhoneNumber " +
                           "FROM Aut " +
                           "JOIN Users ON Aut.UserId = Users.ID";

            if (!string.IsNullOrEmpty(cityFilter))
            {
                query += " WHERE Aut.City = @City";
            }

            SqlCommand command = new SqlCommand(query, connection);
            if (!string.IsNullOrEmpty(cityFilter))
            {
                command.Parameters.AddWithValue("@City", cityFilter);
            }

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var carInfo = new CarInfo
                {
                    CarId = Convert.ToInt32(reader["ID"]),
                    Mark = reader["Mark"].ToString(),
                    Model = reader["Model"].ToString(),
                    Price = reader["Price"].ToString(),
                    YearOfIssue = reader["YearOfIssue"].ToString(),
                    Mileage = reader["Mileage"].ToString(),
                    Color = reader["Color"].ToString(),
                    Description = reader["Description"].ToString(),
                    OwnerName = reader["Username"].ToString(),
                    OwnerEmail = reader["Email"].ToString(),
                    OwnerPhone = reader["PhoneNumber"].ToString(),
                    City = reader["City"].ToString(),
                    ImagePath = reader["ImagePath"].ToString() // Добавлено поле для пути изображения
                };

                carInfoList.Add(carInfo);

                // Создаем карточку машины
                var carPanel = CreateCarPanel(carInfo);
                flowLayoutPanelCars.Controls.Add(carPanel);
            }

            reader.Close();
        }

        private void LoadCities()
        {
            // SQL запрос для получения списка городов
            string query = "SELECT DISTINCT City FROM Aut";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Заполняем ComboBox
            comboBoxCities.Items.Clear();
            comboBoxCities.Items.Add("Все города");
            while (reader.Read())
            {
                comboBoxCities.Items.Add(reader["City"].ToString());
            }

            reader.Close();

            // Устанавливаем значение по умолчанию
            comboBoxCities.SelectedIndex = 0;
        }

        private void ComboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = comboBoxCities.SelectedItem.ToString();
            if (selectedCity == "Все города")
            {
                LoadCars(); // Загружаем все машины
            }
            else
            {
                LoadCars(selectedCity); // Фильтруем по выбранному городу
            }
        }

        private Panel CreateCarPanel(CarInfo carInfo)
        {
            var carPanel = new Panel
            {
                Width = 300,
                Height = 400, // Высота панели
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Используем TableLayoutPanel для более гибкого размещения
            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3, // Теперь 3 строки, одна для изображения, одна для информации и одна для кнопки
                ColumnCount = 1,
                RowStyles =
        {
            new RowStyle(SizeType.Percent, 40), // 40% для изображения
            new RowStyle(SizeType.Percent, 40), // 40% для информации
            new RowStyle(SizeType.Percent, 20)  // 20% для кнопки
        },
                AutoSize = true
            };

            // Панель для изображения
            var imagePanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 150 // Высота изображения
            };

            var carImage = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Загружаем изображение
            if (string.IsNullOrEmpty(carInfo.ImagePath))
            {
                carImage.Image = Image.FromFile("default_image_path.jpg"); // Путь к изображению по умолчанию
            }
            else
            {
                try
                {
                    carImage.Image = Image.FromFile(carInfo.ImagePath); // Попытка загрузить изображение из базы
                }
                catch (Exception)
                {
                    carImage.Image = Image.FromFile("default_image_path.jpg"); // Если ошибка, используем изображение по умолчанию
                }
            }

            imagePanel.Controls.Add(carImage);

            // Панель для текста
            var infoPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var carLabel = new Label
            {
                Text = $"{carInfo.Mark} {carInfo.Model}\n" +
                       $"Цена: {carInfo.Price} ₽\n" +
                       $"Год выпуска: {carInfo.YearOfIssue}\n" +
                       $"Пробег: {carInfo.Mileage} км\n" +
                       $"Цвет: {carInfo.Color}\n" +
                       $"Город: {carInfo.City}",
                AutoSize = true,
                Padding = new Padding(10)
            };

            infoPanel.Controls.Add(carLabel);

            // Создаем кнопку для перехода на подробности автомобиля
            var detailsButton = new Button
            {
                Text = "Подробнее",
                Dock = DockStyle.Fill, // Кнопка будет занимать всю оставшуюся высоту
                Height = 40,
                Font = new Font("Arial", 10)
            };

            // Обработчик клика на кнопке
            detailsButton.Click += (sender, e) =>
            {
                try
                {
                    FormCarDetails formCarDetails = new FormCarDetails(carInfo.CarId);
                    formCarDetails.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии формы: " + ex.Message);
                }
            };

            // Добавляем панели в TableLayoutPanel
            tableLayout.Controls.Add(imagePanel, 0, 0); // Изображение в первой строке
            tableLayout.Controls.Add(infoPanel, 0, 1);  // Информация во второй строке
            tableLayout.Controls.Add(detailsButton, 0, 2); // Кнопка в третьей строке

            // Добавляем TableLayoutPanel в carPanel
            carPanel.Controls.Add(tableLayout);

            return carPanel;
        }

        private void FormCars_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }

    // Класс для хранения информации о машине
    public class CarInfo
    {
        public int CarId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string YearOfIssue { get; set; }
        public string Mileage { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        public string City { get; set; }
        public string ImagePath { get; set; } // Путь к изображению
    }
}
