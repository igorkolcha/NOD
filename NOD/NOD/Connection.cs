using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SQLite; // Вам нужно установить NuGet-пакет System.Data.SQLite.Core

namespace NOD
{
    public static class Connection
    {
        // Строка подключения для SQLite.
        // Если файл базы данных находится в папке DataDirectory (как у вас было),
        // то строка может выглядеть так:
        static string connectionString = @"Data Source=NOD.db;Version=3;";
        // Замените .mdb на .db или другое расширение, используемое для SQLite.

       
        /// <summary>
        /// Подключается к базе данных SQLite, выполняет запрос и заполняет DataGridView.
        /// </summary>
        /// <param name="dataGridView">DataGridView для отображения данных.</param>
        /// <param name="stringQuery">SQL-запрос SELECT.</param>
        public static void ConnectionDataBase(DataGridView dataGridView, string stringQuery)
        {
            // Используем SQLiteConnection вместо OleDbConnection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Попытка открытия соединения
                    connection.Open();
                }
                catch (SQLiteException ex)
                {
                    // Обработка ошибок подключения, специфичных для SQLite
                    MessageBox.Show($"Ошибка подключения к базе данных SQLite: {ex.Message}");
                    return; // Выходим из метода, если нет подключения
                }

                // Используем SQLiteDataAdapter вместо OleDbDataAdapter
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(stringQuery, connection))
                {
                    try
                    {
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                        // Настройка DataGridView
                        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        dataGridView.DataSource = dataSet.Tables[0];
                        dataGridView.RowHeadersVisible = false;
                        //dataGridView.Visible = true;
                    }
                    catch (SQLiteException ex)
                    {
                        // Обработка ошибок при выполнении запроса
                        MessageBox.Show($"Ошибка выполнения запроса SQLite: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Общая обработка других ошибок
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                    finally
                    {
                        // Соединение будет закрыто автоматически благодаря using,
                        // но явный вызов connection.Close() внутри finally, как у вас было,
                        // не нужен, но и не повредит, если вы решите убрать using.
                        // В данном случае 'using' гарантирует вызов Dispose(), который закроет соединение.
                        // connection.Close(); // Необязательно при использовании `using` для connection
                    }
                } // dataAdapter.Dispose() и connection.Close() вызываются здесь
            } // connection.Dispose() вызывается здесь
        }
    }
}
