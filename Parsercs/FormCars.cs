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
    public partial class FormCars : Form
    {
        private int _userId;
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        // Добавляем FlowLayoutPanel в код
        private FlowLayoutPanel flowLayoutPanelCars;

        // Коллекция для хранения информации о машинах
        private List<CarInfo> carInfoList = new List<CarInfo>();

        public FormCars(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Инициализация FlowLayoutPanel
            flowLayoutPanelCars = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,  // Заполняем всю форму
                AutoScroll = true,      // Возможность прокрутки
                Padding = new Padding(10)  // Отступы
            };

            // Добавляем FlowLayoutPanel на форму
            Controls.Add(flowLayoutPanelCars);
        }

        private void FormCars_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            // Загружаем данные о машинах в FlowLayoutPanel
            LoadCars();
        }

        private void LoadCars()
        {
            // SQL запрос для получения всех машин и информации о владельце
            string query = "SELECT Aut.ID, Aut.City, Aut.Mark, Aut.Model, Aut.Price, Aut.Description, " +
                           "Aut.YearOfIssue, Aut.Mileage, Aut.Color, Users.Username, Users.Email, Users.PhoneNumber " +
                           "FROM Aut " +
                           "JOIN Users ON Aut.UserId = Users.ID";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Для каждой машины создаем панель
            while (reader.Read())
            {
                // Создание панели для каждой машины
                Panel carPanel = new Panel
                {
                    Width = 300,            // Ширина панели
                    Height = 250,           // Высота панели
                    BorderStyle = BorderStyle.FixedSingle,  // Рамка вокруг карточки
                    Margin = new Padding(10)  // Отступы для панели
                };

                // Создаем метку для отображения информации о машине
                Label carInfoLabel = new Label
                {
                    Text = $"{reader["Mark"]} {reader["Model"]}\n" +
                           $"Цена: {reader["Price"]}\n" +
                           $"Год выпуска: {reader["YearOfIssue"]}\n" +
                           $"Пробег: {reader["Mileage"]}\n" +
                           $"Цвет: {reader["Color"]}\n" +
                           $"Описание: {reader["Description"]}",
                    AutoSize = true,   // Автоматическая ширина метки в зависимости от содержимого
                    Padding = new Padding(20)
                };
                
                // Создаем метку для владельца машины
                Label ownerInfoLabel = new Label
                {
                    Text = $"Владелец: {reader["Username"]}\n" +
                           $"Email: {reader["Email"]}\n" +
                           $"Телефон: {reader["PhoneNumber"]}",
                    AutoSize = true,
                    Padding = new Padding(5)
                };

                // Добавляем метки на панель
                carPanel.Controls.Add(carInfoLabel);
                carPanel.Controls.Add(ownerInfoLabel);

                // Сохраняем информацию о машине в список
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
                    OwnerPhone = reader["PhoneNumber"].ToString()
                };

                carInfoList.Add(carInfo);

                // Добавляем обработчик события для клика по панели
                carPanel.Click += (sender, e) =>
                {
                    // Получаем информацию о машине из списка
                    CarInfo selectedCar = carInfoList.FirstOrDefault(c => c.CarId == carInfo.CarId);
                    if (selectedCar != null)
                    {
                        // Передаем объект CarInfo в FormCarDetails
                        //FormCarDetails formCarDetails = new FormCarDetails(selectedCar);
                        //formCarDetails.Show();
                    }
                };


                // Добавляем панель на FlowLayoutPanel
                flowLayoutPanelCars.Controls.Add(carPanel);
            }

            reader.Close();
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
    }
}





