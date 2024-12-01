using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormLogin : Form
    {
        private SqlConnection connection;
        private string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        // Метод для хэширования пароля
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }

        // Обработчик кнопки "Логин"
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // Проверка на пустой ввод
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            // Хэширование пароля
            string hashedPassword = HashPassword(password);

            // Запрос для получения ID и роли пользователя
            string query = "SELECT ID, Role FROM Users WHERE Username = @username AND Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["ID"]);
                                string userRole = reader["Role"].ToString();

                                MessageBox.Show("Авторизация успешна!");

                                // Переход в главное меню с передачей ID и роли
                                this.Hide();
                                Form3 mainForm = new Form3(userId, userRole);
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}");
                }
            }
        }

        // Обработчик кнопки "Регистрация"
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
        }
    }
}
