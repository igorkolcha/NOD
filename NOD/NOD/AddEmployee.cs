using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NOD
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        // Ваша строка подключения для SQLite
        static string connectionString = @"Data Source=NOD.db;Version=3;";

        void InsertTables(string connectionString, string Фамилия, string Имя, string Отчество)
        {
            // Используем SQLiteConnection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Попытка открытия соединения
                    connection.Open();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Нет подключения к базе данных SQLite: {ex.Message}");
                    return; // Выходим в случае ошибки подключения
                }

                // 1. Используем SQLiteCommand для выполнения не-SELECT запроса
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    try
                    {
                        // Формируем полное ФИО
                        string fullFIO = $"{Фамилия} {Имя} {Отчество}";

                        // 2. Используем параметризованный запрос! 
                        // Это очень важно для безопасности и корректной работы с данными.
                        command.CommandText = "INSERT INTO шч (фио) VALUES (@FIO)";

                        // 3. Добавляем параметр
                        command.Parameters.AddWithValue("@FIO", fullFIO);

                        // 4. Выполняем команду, которая не возвращает набор данных
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Добавлен работник: {Фамилия} {Имя}");
                        }
                        else
                        {
                            MessageBox.Show("Запись не была добавлена.");
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show($"Ошибка при выполнении INSERT-запроса: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла общая ошибка: {ex.Message}");
                    }
                    // Соединение закроется автоматически благодаря using для SQLiteConnection
                }
            }
        }

        private void button_AddEmployee_Сохранить_Click(object sender, EventArgs e)
        {
            if (textBox_AddEmployee_Фамилия.Text == "")
            {
                MessageBox.Show("Введите фамилию");
            }
            else if (textBox_AddEmployee_Имя.Text == "")
            {
                {
                    MessageBox.Show("Введите имя");
                }
            }
            else if (textBox_AddEmployee_Отчество.Text == "")
            {
                MessageBox.Show("Введите фамилию");
            }
            else
            { InsertTables(connectionString, 
                textBox_AddEmployee_Фамилия.Text, 
                textBox_AddEmployee_Имя.Text,
                textBox_AddEmployee_Отчество.Text); 
            }
            this.Visible = false;
        }
    }
}
