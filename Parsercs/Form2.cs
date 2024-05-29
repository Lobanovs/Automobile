using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Parsercs
{
    public partial class Form2 : Form
    {
        private MySqlConnection connection;
        private string connectionString = "Server=sql7.freesqldatabase.com;Port=3306;Database=sql7710165;Uid=sql7710165;Pwd=kpl4jFAWA6;Charset=utf8;";
        private DataTable dataTable; // Объявляем dataTable как поле класса

        Dictionary<string, List<string>> carModels = new Dictionary<string, List<string>>();

        public Form2()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;

            carModels.Add("BMW", new List<string> { "X5", "3 Series", "5 Series" });
            carModels.Add("Mercedes", new List<string> { "C-Class", "E-Class", "S-Class" });
            carModels.Add("Audi", new List<string> { "A4", "A6", "Q7" });

            foreach (string carBrand in carModels.Keys)
            {
                comboBox2.Items.Add(carBrand);
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очищаем второй ComboBox
            comboBox3.Items.Clear();

            // Получаем выбранную марку машины из первого ComboBox
            string selectedBrand = comboBox2.SelectedItem.ToString();

            // Если для выбранной марки есть модели, добавляем их во второй ComboBox
            if (carModels.ContainsKey(selectedBrand))
            {
                foreach (string model in carModels[selectedBrand])
                {
                    comboBox3.Items.Add(model);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Aut";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    dataTable = new DataTable(); // Инициализируем dataTable
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            // Фильтр по городу
            if (comboBox1.SelectedItem != null)
            {
                DataView dv = dataTable.DefaultView;
                string selectedCity = comboBox1.SelectedItem.ToString();
                dv.RowFilter = $"City = '{selectedCity}'";
                dataGridView1.DataSource = dv;
            }
            

            // Фильтр по марке и модели автомобиля
            if (comboBox3.SelectedItem != null)
            {
                DataView dv = dataTable.DefaultView;

                string selectedModel = comboBox3.SelectedItem.ToString();
                dv.RowFilter = $"Model = '{selectedModel}'";
                dataGridView1.DataSource = dv;
            }

            if (comboBox2.SelectedItem != null)
            {
                DataView dv = dataTable.DefaultView;
                string selectedMark = comboBox2.SelectedItem.ToString();
                dv.RowFilter = $"Mark = '{selectedMark}'";
                dataGridView1.DataSource = dv;
            }

            // Фильтр по году выпуска
            if (comboBox4.SelectedItem != null)
            {
                DataView dv = dataTable.DefaultView;
                string selectedYear = comboBox4.SelectedItem.ToString();
                dv.RowFilter = $"YearOfIssue = '{selectedYear}'";
                dataGridView1.DataSource = dv;
            }
           

            // Фильтр по цвету
            if (comboBox5.SelectedItem != null)
            {
                DataView dv = dataTable.DefaultView;
                string selectedColor = comboBox5.SelectedItem.ToString();
                dv.RowFilter = $"Color = '{selectedColor}'";
                dataGridView1.DataSource = dv;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Close();

                // Создаем новый экземпляр формы 2
                Form3 form3 = new Form3();

                // Отображаем форму 2
                form3.Show();
        }
    }
}
