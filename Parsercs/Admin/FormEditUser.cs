using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormEditUser : Form
    {
        private int _userId;
        private string _connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        // Поля для редактирования пользователя
        private TextBox txtUsername;
        private ComboBox comboRole;
        private Button btnSave;
        private Button btnCancel;

        public FormEditUser(int userId, string username, string role)
        {
            InitializeComponent();
            _userId = userId;

            InitializeComponents();

            // Заполняем поля данными
            txtUsername.Text = username;
            comboRole.SelectedItem = role;
        }

        // Инициализация компонентов
        private void InitializeComponents()
        {
            this.Text = "Редактирование пользователя";
            this.Size = new System.Drawing.Size(400, 300);

            // Поле для ввода имени пользователя
            txtUsername = new TextBox
            {
                Location = new System.Drawing.Point(20, 30),
                Width = 200,
                Text = ""
            };
            this.Controls.Add(txtUsername);

            // Выпадающий список для выбора роли
            comboRole = new ComboBox
            {
                Location = new System.Drawing.Point(20, 80),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboRole.Items.AddRange(new string[] { "User", "Admin" }); // Роли
            this.Controls.Add(comboRole);

            // Кнопка "Сохранить"
            btnSave = new Button
            {
                Text = "Сохранить",
                Location = new System.Drawing.Point(20, 130),
                Width = 100
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Кнопка "Отмена"
            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(140, 130),
                Width = 100
            };
            btnCancel.Click += (sender, e) => this.Close();
            this.Controls.Add(btnCancel);
        }

        // Сохранение изменений
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string role = comboRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            string query = "UPDATE Users SET Username = @Username, Role = @Role WHERE ID = @UserId";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@UserId", _userId);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Данные пользователя обновлены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
    }
}
