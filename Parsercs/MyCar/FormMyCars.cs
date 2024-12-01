using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormMyCars : Form
    {
        private int _userId;
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        // Элементы интерфейса
        private FlowLayoutPanel flowLayoutPanelCars;

        // Коллекция для хранения информации о машинах
        private List<CarInfo> carInfoList = new List<CarInfo>();

        public FormMyCars(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Настройка интерфейса
            SetupUI();
        }

        private void SetupUI()
        {
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
            Controls.Add(backButton);  // Добавляем кнопку "В меню"
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // Получаем роль пользователя из базы данных
            string userRole = GetUserRole(_userId);  // Получаем роль пользователя
            Form3 menuForm = new Form3(_userId, userRole);  // Передаем userId и userRole
            menuForm.Show();
            this.Close();
        }

        private void FormMyCars_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            // Загружаем данные о машинах
            LoadCars();
        }

        private void LoadCars()
        {
            // Очищаем FlowLayoutPanel и список машин
            flowLayoutPanelCars.Controls.Clear();
            carInfoList.Clear();

            // SQL запрос для получения машин пользователя
            string query = "SELECT Aut.ID, Aut.Mark, Aut.Model, Aut.Price, Aut.YearOfIssue, Aut.Mileage, Aut.Color, " +
                           "Aut.Description, Aut.ImagePath " +
                           "FROM Aut WHERE Aut.UserId = @UserId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", _userId);

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
                    ImagePath = reader["ImagePath"].ToString() // Путь к изображению
                };

                carInfoList.Add(carInfo);

                // Создаем карточку машины
                var carPanel = CreateCarPanel(carInfo);
                flowLayoutPanelCars.Controls.Add(carPanel);
            }

            reader.Close();
        }

        private Panel CreateCarPanel(CarInfo carInfo)
        {
            var carPanel = new Panel
            {
                Width = 300,
                Height = 400,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Используем TableLayoutPanel для более гибкого размещения
            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3, // 3 строки: одна для изображения, одна для информации и одна для кнопок
                ColumnCount = 1,
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 40), // 40% для изображения
                    new RowStyle(SizeType.Percent, 40), // 40% для информации
                    new RowStyle(SizeType.Percent, 20)  // 20% для кнопок
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
                       $"Цвет: {carInfo.Color}",
                AutoSize = true,
                Padding = new Padding(10)
            };

            infoPanel.Controls.Add(carLabel);

            // Панель для кнопок
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var btnDelete = new Button
            {
                Text = "Удалить",
                Dock = DockStyle.Left, // Кнопка будет занимать левую половину
                Width = 120,
                Height = 40,
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            btnDelete.Click += (sender, e) => DeleteCar(carInfo.CarId); // Обработчик для удаления машины

            var btnEdit = new Button
            {
                Text = "Изменить",
                Dock = DockStyle.Right, // Кнопка будет занимать правую половину
                Width = 120,
                Height = 40,
                BackColor = Color.Blue,
                ForeColor = Color.White
            };
            btnEdit.Click += (sender, e) => EditCar(carInfo.CarId); // Обработчик для редактирования машины

            buttonPanel.Controls.Add(btnDelete);
            buttonPanel.Controls.Add(btnEdit);

            // Добавляем панели в TableLayoutPanel
            tableLayout.Controls.Add(imagePanel, 0, 0); // Изображение в первой строке
            tableLayout.Controls.Add(infoPanel, 0, 1);  // Информация во второй строке
            tableLayout.Controls.Add(buttonPanel, 0, 2); // Кнопки в третьей строке

            // Добавляем TableLayoutPanel в carPanel
            carPanel.Controls.Add(tableLayout);

            return carPanel;
        }

        private void DeleteCar(int carId)
        {
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить эту машину?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Aut WHERE ID = @CarId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Машина удалена.");
                LoadCars(); // Перезагружаем список машин
            }
        }

        private void EditCar(int carId)
        {
            FormEditCar formEditCar = new FormEditCar(carId);
            formEditCar.Show();
        }

        private void FormMyCars_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        // Метод для получения роли пользователя
        private string GetUserRole(int userId)
        {
            string userRole = "user";  // Дефолтное значение
            string query = "SELECT Role FROM Users WHERE ID = @UserId";  // Пример запроса для получения роли
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                userRole = reader["Role"].ToString();  // Получаем роль из базы данных
            }
            reader.Close();

            return userRole;
        }
    }
}
