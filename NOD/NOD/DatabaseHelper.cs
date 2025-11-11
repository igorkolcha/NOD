using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace NOD
{
    internal class DatabaseHelper
    {
        private static readonly string connectionString =
        $@"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SHCH.db")};Version=3;";

        public static void ExecuteQueryWithParams(DataGridView dgv, string query, params (string name, object value)[] parameters)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Добавляем параметры
                        foreach (var (name, value) in parameters)
                        {
                            command.Parameters.AddWithValue(name, value ?? DBNull.Value);
                        }

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            var table = new DataTable();
                            adapter.Fill(table);

                            dgv.DataSource = table;
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            dgv.RowHeadersVisible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выполнения запроса",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
