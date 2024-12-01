using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormRegister : Form
    {
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        public FormRegister()
        {
            InitializeComponent();
        }

        // Метод для хеширования пароля
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }

        // Обработчик нажатия кнопки Регистрация
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string email = textBoxEmail.Text;
            string phoneNumber = textBoxPhoneNumber.Text;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            // Проверка на совпадение паролей
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            // Хеширование пароля
            string hashedPassword = HashPassword(password);

            try
            {
                // Открытие соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, есть ли уже такой пользователь
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    int existingUserCount = (int)checkCommand.ExecuteScalar();

                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("Пользователь с таким именем уже существует.");
                        return;
                    }

                    // Запрос на добавление нового пользователя в базу данных
                    string insertQuery = "INSERT INTO Users (Username, Password, Email, PhoneNumber) VALUES (@Username, @Password, @Email, @PhoneNumber)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Username", username);
                    insertCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    // Выполнение запроса
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Регистрация прошла успешно!");
                        this.Hide();
                        FormLogin loginForm = new FormLogin();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при регистрации. Попробуйте снова.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }

        // Обработчик кнопки отмены (можно добавить если нужна кнопка для отмены)
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }
    }
}

