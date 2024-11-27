using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormEditCar : Form
    {
        private int _carId;
        private SqlConnection _connection;
        private string _connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";
        private string _imagePath; // Путь к изображению

        // Текстовые поля для ввода
        private TextBox txtMark;
        private TextBox txtModel;
        private TextBox txtYearOfIssue;
        private TextBox txtPrice;
        private TextBox txtMileage;  // Для пробега
        private ComboBox comboBoxColor;    // Для выбора цвета
        private TextBox txtDescription;  // Для описания
        private Button btnSave;
        private Button btnCancel;
        private PictureBox pictureBoxCarImage; // Для отображения изображения
        private Button btnChangeImage; // Кнопка для изменения изображения

        public FormEditCar(int carId)
        {
            InitializeComponent();
            _carId = carId;
            this.Text = "Редактировать машину";
            this.StartPosition = FormStartPosition.CenterScreen; // Центрируем форму
            InitializeComponents();  // Сначала инициализируем компоненты
            LoadCarDetails();       // Затем загружаем данные о машине
        }

        // Инициализация компонентов формы (текстовые поля и кнопки)
        private void InitializeComponents()
        {
            // Настройки формы
            this.BackColor = Color.WhiteSmoke;  // Фоновый цвет формы
            this.ClientSize = new Size(600, 600);

            // Настройка шрифта
            Font defaultFont = new Font("Segoe UI", 10);

            // Инициализация текстовых полей
            txtMark = new TextBox { Location = new System.Drawing.Point(100, 50), Width = 200, ReadOnly = true, Font = defaultFont };
            txtModel = new TextBox { Location = new System.Drawing.Point(100, 100), Width = 200, ReadOnly = true, Font = defaultFont };  // Сделаем поле модели недоступным для редактирования
            txtYearOfIssue = new TextBox { Location = new System.Drawing.Point(100, 150), Width = 200, Font = defaultFont };
            txtPrice = new TextBox { Location = new System.Drawing.Point(100, 200), Width = 200, Font = defaultFont };
            txtMileage = new TextBox { Location = new System.Drawing.Point(100, 250), Width = 200, Font = defaultFont };  // Пробег

            // Инициализация ComboBox для выбора цвета
            comboBoxColor = new ComboBox { Location = new System.Drawing.Point(100, 300), Width = 200, Font = defaultFont };
            comboBoxColor.Items.AddRange(new string[] { "Красный", "Синий", "Черный", "Белый", "Серый" });

            // Инициализация текстового поля для описания
            txtDescription = new TextBox { Location = new System.Drawing.Point(100, 350), Width = 200, Multiline = true, Height = 100, Font = defaultFont };  // Описание

            // Инициализация компонента для изображения
            pictureBoxCarImage = new PictureBox { Location = new System.Drawing.Point(350, 50), Width = 200, Height = 150, BorderStyle = BorderStyle.Fixed3D };

            // Кнопка для изменения изображения
            btnChangeImage = new Button { Text = "Изменить изображение", Location = new System.Drawing.Point(350, 210), Width = 200, Font = defaultFont };
            btnChangeImage.BackColor = Color.FromArgb(41, 128, 185); // Цвет кнопки
            btnChangeImage.ForeColor = Color.White; // Цвет текста на кнопке
            btnChangeImage.FlatStyle = FlatStyle.Flat;
            btnChangeImage.FlatAppearance.BorderSize = 0;
            btnChangeImage.Click += btnChangeImage_Click;

            // Инициализация кнопок
            btnSave = new Button { Text = "Сохранить", Location = new System.Drawing.Point(100, 470), Width = 100, Font = defaultFont };
            btnSave.BackColor = Color.SeaGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;

            btnCancel = new Button { Text = "Отменить", Location = new System.Drawing.Point(210, 470), Width = 100, Font = defaultFont };
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += btnCancel_Click;

            // Добавляем компоненты на форму
            this.Controls.Add(txtMark);
            this.Controls.Add(txtModel);
            this.Controls.Add(txtYearOfIssue);
            this.Controls.Add(txtPrice);
            this.Controls.Add(txtMileage);
            this.Controls.Add(comboBoxColor);  // Добавляем ComboBox для цвета
            this.Controls.Add(txtDescription);
            this.Controls.Add(pictureBoxCarImage); // Добавляем PictureBox
            this.Controls.Add(btnChangeImage);    // Добавляем кнопку изменения изображения
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        // Загружаем данные о машине для редактирования
        private void LoadCarDetails()
        {
            string query = "SELECT Mark, Model, YearOfIssue, Price, Mileage, Color, Description, ImagePath FROM Aut WHERE ID = @CarId";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@CarId", _carId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Загрузка данных в текстовые поля
                        txtMark.Text = reader["Mark"]?.ToString() ?? "Неизвестно";
                        txtModel.Text = reader["Model"]?.ToString() ?? "Неизвестно";
                        txtYearOfIssue.Text = reader["YearOfIssue"]?.ToString() ?? "Неизвестно";
                        txtPrice.Text = reader["Price"]?.ToString() ?? "Неизвестно";
                        txtMileage.Text = reader["Mileage"]?.ToString() ?? "Неизвестно";
                        comboBoxColor.SelectedItem = reader["Color"]?.ToString() ?? "Неизвестно";
                        txtDescription.Text = reader["Description"]?.ToString() ?? "Нет описания";

                        // Загружаем изображение
                        string imagePath = reader["ImagePath"]?.ToString();
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            pictureBoxCarImage.Image = Image.FromFile(imagePath);
                            _imagePath = imagePath;  // Сохраняем путь к изображению
                        }
                        else
                        {
                            pictureBoxCarImage.Image = null;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        // Сохраняем изменения
        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal price;
            int mileage;
            int yearOfIssue;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Введите правильную цену.");
                return;
            }

            if (!int.TryParse(txtMileage.Text, out mileage))
            {
                MessageBox.Show("Введите правильный пробег.");
                return;
            }

            if (!int.TryParse(txtYearOfIssue.Text, out yearOfIssue))
            {
                MessageBox.Show("Введите правильный год выпуска.");
                return;
            }

            if (comboBoxColor.SelectedItem == null)
            {
                MessageBox.Show("Выберите цвет автомобиля.");
                return;
            }

            // Если изображение изменено, сохраняем путь к новому изображению
            string imagePath = _imagePath;

            // SQL запрос для обновления данных
            string query = "UPDATE Aut SET Mileage = @Mileage, Color = @Color, Price = @Price, YearOfIssue = @YearOfIssue, Description = @Description, ImagePath = @ImagePath WHERE ID = @CarId";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@CarId", _carId);
                    command.Parameters.AddWithValue("@Mileage", mileage);
                    command.Parameters.AddWithValue("@Color", comboBoxColor.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@YearOfIssue", yearOfIssue);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);  // Сохраняем путь или null
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Информация о машине обновлена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        // Отмена редактирования
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Метод для выбора и отображения нового изображения
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                pictureBoxCarImage.Image = Image.FromFile(selectedImagePath);  // Отображаем выбранное изображение
                _imagePath = selectedImagePath;
            }
        }
    }
}
