using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Parsercs
{
    public partial class FormManageUsers : Form
    {
        private SqlConnection _connection;
        private string _connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

        public FormManageUsers()
        {
            InitializeComponent();
            InitializeComponents(); // Инициализация элементов интерфейса
            LoadUsers();            // Загрузка пользователей из базы данных
        }

        private DataGridView dgvUsers; // Таблица для отображения пользователей
        private Button btnDeleteUser; // Кнопка для удаления пользователя
        private Button btnEditUser;   // Кнопка для редактирования пользователя

        // Инициализация компонентов формы
        private void InitializeComponents()
        {
            this.Text = "Управление пользователями";
            this.Size = new System.Drawing.Size(600, 400);

            // DataGridView для отображения пользователей
            dgvUsers = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 250),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvUsers);

            // Кнопка "Удалить пользователя"
            btnDeleteUser = new Button
            {
                Text = "Удалить пользователя",
                Location = new System.Drawing.Point(20, 290),
                Width = 200
            };
            btnDeleteUser.Click += BtnDeleteUser_Click;
            this.Controls.Add(btnDeleteUser);

            // Кнопка "Редактировать пользователя"
            btnEditUser = new Button
            {
                Text = "Редактировать пользователя",
                Location = new System.Drawing.Point(240, 290),
                Width = 200
            };
            btnEditUser.Click += BtnEditUser_Click;
            this.Controls.Add(btnEditUser);
        }

        // Загрузка списка пользователей из базы данных
        private void LoadUsers()
        {
            string query = "SELECT ID, Username, Role FROM Users"; // Получаем ID, логин и роль

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
                    DataTable usersTable = new DataTable();
                    adapter.Fill(usersTable);

                    // Привязываем таблицу к DataGridView
                    dgvUsers.DataSource = usersTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователей: {ex.Message}");
            }
        }

        // Обработчик кнопки "Удалить пользователя"
        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для удаления.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);

            string query = "DELETE FROM Users WHERE ID = @UserId";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Пользователь удален!");
                    LoadUsers(); // Обновляем список пользователей
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}");
            }
        }

        // Обработчик кнопки "Редактировать пользователя"
        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для редактирования.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();
            string role = dgvUsers.SelectedRows[0].Cells["Role"].Value.ToString();

            // Переход к форме редактирования пользователя
            FormEditUser formEditUser = new FormEditUser(userId, username, role);
            formEditUser.ShowDialog();

            LoadUsers(); // Обновляем список пользователей после редактирования
        }
    }
}
