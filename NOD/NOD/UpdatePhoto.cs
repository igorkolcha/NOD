using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace NOD
{
    public static class UpdatePhoto
    {
        static string connectionString = @"Data Source=NOD.db;Version=3;";

        public static void UpdatePhotos(string fio)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
                ofd.Title = "Выберите фотографию сотрудника";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Чтение файла в byte[]
                        byte[] photoBytes = File.ReadAllBytes(ofd.FileName);

                        // Проверка размера (опционально)
                        if (photoBytes.Length == 0)
                        {
                            MessageBox.Show("Выбранный файл пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Обновление фото в базе по ФИО
                        using (var conn = new SQLiteConnection(connectionString))
                        {
                            conn.Open();
                            // ⚠️ Используем UPDATE, а не INSERT!
                            string sql = "UPDATE [шч] SET [фото] = @Photo WHERE [фио] = @ФИО";

                            using (var cmd = new SQLiteCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Photo", photoBytes);
                                cmd.Parameters.AddWithValue("@ФИО", fio);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show($"Фото для «{fio}» успешно обновлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Обновляем отображение фото на форме (если нужно)
                                    //LoadPhotoIntoPictureBox(fio);
                                }
                                else
                                {
                                    MessageBox.Show($"Сотрудник с ФИО «{fio}» не найден в базе.", "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке фото:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
