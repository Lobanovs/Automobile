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

        // Хешируем пароль перед проверкой в базе данных
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }

        // Обработчик для кнопки Логин
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim(); // Логин
            string password = textBoxPassword.Text.Trim(); // Пароль

            // Проверка ввода
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            // Хэширование пароля, если используется (опционально)
            string hashedPassword = HashPassword(password);

            // SQL-запрос для получения ID пользователя
            string query = "SELECT ID FROM Users WHERE Username = @username AND Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword); // Если используется хэширование

                        object result = command.ExecuteScalar(); // Получаем ID пользователя

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result); // Преобразуем результат в int
                            MessageBox.Show("Авторизация успешна!");

                            this.Hide();

                            // Передаем userId в следующую форму
                            Form3 mainForm = new Form3(userId);
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}");
                }
            }
        }



        // Переход на форму регистрации
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
        }
    }
}
