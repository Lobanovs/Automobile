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
        private int _carId; // ID машины

        public FormCarDetails(int carId)
        {
            InitializeComponent();
            _carId = carId; // Сохраняем ID машины


        }

        private void FormCarDetails_Load(object sender, EventArgs e)
        {
            // Строка подключения к базе данных
            string connectionString = @"Server=HOME-PC;Database=Automobile;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Запрос на получение данных о машине
                string query = "SELECT Aut.City, Aut.Mark, Aut.Model, Aut.Price, Aut.Description, " +
                               "Aut.YearOfIssue, Aut.Mileage, Aut.Color, Users.Username, Users.Email " +
                               "FROM Aut " +
                               "JOIN Users ON Aut.UserId = Users.ID " +
                               "WHERE Aut.ID = @CarId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CarId", _carId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Заполняем элементы управления данными о машине
                    LabelMark.Text = reader["Mark"].ToString();
                    LabelModel.Text = reader["Model"].ToString();
                    LabelPrice.Text = reader["Price"].ToString();
                    LabelDescription.Text = reader["Description"].ToString();
                    LabelYearOfIssue.Text = reader["YearOfIssue"].ToString();
                    LabelMileage.Text = reader["Mileage"].ToString();
                    LabelColor.Text = reader["Color"].ToString();

                    // Заполняем информацию о владельце
                    LabelUsername.Text = reader["Username"].ToString();
                    LabelEmail.Text = reader["Email"].ToString();
                }

                reader.Close();
            }
        }
    }

}
