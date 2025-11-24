using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace NOD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.groupBox_ШЧ_Редактировать.Visible = false;
        }

        static string connectionString = @"Data Source=NOD.db;Version=3;";

        #region UpdateData
        void UpdateData(string connectionString)
        {
            // Параметризованный SQL-запрос (без конкатенации!)
            const string query = @"
        UPDATE [шч] 
        SET 
            [должность] = @Должность,
            [станции] = @Станции,
            [мобильный] = @Мобильный,
            [телефон] = @ТелефонРабочий,
            [участок] = @Участок,
            [цех] = @Цех,
            [перегон] = @Перегон,
            [адрес] = @Адрес,
            [рождение] = @ДеньРождения
        WHERE [фио] = @ФИО";

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Добавляем параметры (имена совпадают с именами в запросе через @)
                        command.Parameters.AddWithValue("@Должность", comboBox_GroupBox_ШЧ_РедактироватьДолжность.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Станции", comboBox_GroupBox_ШЧ_РедактироватьСтанция.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Мобильный", maskedTextBox_GroupBox_ШЧ_РедактироватьМобильный.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ТелефонРабочий", maskedTextBox_GroupBox_ШЧ_РедактироватьРабочий.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Участок", comboBox_GroupBox_ШЧ_РедактироватьУчасток.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Цех", comboBox_GroupBox_ШЧ_РедактироватьЦех.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Перегон", textBox_GroupBox_ШЧ_РедактироватьПерегон.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Адрес", textBox_GroupBox_ШЧ_РедактироватьДомАдрес.Text ?? (object)DBNull.Value);
                        //command.Parameters.AddWithValue("@ТелефонДомашний", maskedTextBox1_ТелДом_Ред.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ДеньРождения", maskedTextBox_GroupBox_ШЧ_РедактироватьДеньРождения.Text ?? (object)(object)DBNull.Value);

                        // Безопасный парсинг даты
                        /*if (DateTime.TryParse(maskedTextBox_GroupBox_ШЧ_РедактироватьДеньРождения.Text, out DateTime birthDate))
                        {
                            command.Parameters.AddWithValue("@ДеньРождения", birthDate);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ДеньРождения", DBNull.Value);
                        }*/

                        command.Parameters.AddWithValue("@ФИО", label_GroupBox_ШЧ_Редактировать.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show(
                            $"Изменено записей: {rowsAffected}",
                            "Успешно",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "Сотрудник с указанным ФИО не найден.",
                                "Внимание",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(
                    $"Ошибка SQLite:\n{ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Неизвестная ошибка:\n{ex.Message}",
                    "Критическая ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        #endregion

        #region ConnectionShow
        void ConnectionShow(DataGridView dataGridView)
        {
            // Проверяем, что ФИО задано
            string fio = label_GroupBox_ШЧ_Редактировать.Text.Trim();
            if (string.IsNullOrEmpty(fio))
            {
                MessageBox.Show("ФИО не указано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectDataQuery = @"
        SELECT 
            фио, должность, станции, мобильный, участок, цех, перегон, 
            адрес, телефон, рождение 
        FROM [шч] 
        WHERE [фио] = @ФИО";

            string selectPhotoQuery = "SELECT [фото] FROM [шч] WHERE [фио] = @ФИО";

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // 1. Загрузка данных в DataGridView и поля формы
                    using (var cmd = new SQLiteCommand(selectDataQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ФИО", fio);

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables[0].Rows.Count == 0)
                            {
                                MessageBox.Show($"Сотрудник с ФИО '{fio}' не найден.", "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFormFields(); // Опционально: очистить поля
                                return;
                            }

                            // Привязка к DataGridView
                            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            dataGridView.DataSource = dataSet.Tables[0];

                            // Заполнение полей формы из первой строки
                            var row = dataSet.Tables[0].Rows[0];
                            SetControlText(comboBox_GroupBox_ШЧ_РедактироватьДолжность, row["Должность"]);
                            SetControlText(comboBox_GroupBox_ШЧ_РедактироватьСтанция, row["Станции"]);
                            SetControlText(maskedTextBox_GroupBox_ШЧ_РедактироватьМобильный, row["Мобильный"]);
                            SetControlText(comboBox_GroupBox_ШЧ_РедактироватьУчасток, row["Участок"]);
                            SetControlText(comboBox_GroupBox_ШЧ_РедактироватьЦех, row["Цех"]);
                            SetControlText(textBox_GroupBox_ШЧ_РедактироватьПерегон, row["Перегон"]);
                            SetControlText(textBox_GroupBox_ШЧ_РедактироватьДомАдрес, row["Адрес"]);
                            //SetControlText(maskedTextBox1_ТелДом_Ред, row["Телефон домашний"]);
                            SetControlText(maskedTextBox_GroupBox_ШЧ_РедактироватьРабочий, row["Телефон"]);
                            SetControlText(maskedTextBox_GroupBox_ШЧ_РедактироватьДеньРождения, row["Рождение"]);
                        }
                    }

                    // 2. Загрузка фото (отдельный запрос, т.к. BLOB)
                    using (var cmd = new SQLiteCommand(selectPhotoQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ФИО", fio);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(0))
                            {
                                byte[] photoBytes = (byte[])reader["Фото"];

                                try
                                {
                                    // Если фото хранится как OLE-объект (как в Access), можно использовать ваш метод
                                    // Иначе — если фото просто JPEG/PNG — используем напрямую
                                    byte[] cleanImageBytes;
                                    if (IsLikelyOLEObject(photoBytes))
                                    {
                                        // Ваш существующий метод для извлечения из OLE-поля
                                        cleanImageBytes = InsertPhoto.GetImageBytesFromOLEField(photoBytes);
                                    }
                                    else
                                    {
                                        cleanImageBytes = photoBytes;
                                    }

                                    using (var ms = new MemoryStream(cleanImageBytes))
                                    {
                                        pictureBox_GroupBox_ШЧ_Редактировать.Image?.Dispose(); // освобождаем старое изображение
                                        pictureBox_GroupBox_ШЧ_Редактировать.Image = new Bitmap(ms);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка загрузки изображения:\n{ex.Message}", "Ошибка фото", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    LoadDefaultPhoto();
                                }
                            }
                            else
                            {
                                LoadDefaultPhoto();
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Ошибка базы данных:\n{ex.Message}", "SQLite Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательные методы:

        private void SetControlText(Control control, object value)
        {
            string text = value?.ToString() ?? "";
            if (control is TextBoxBase tb)
                tb.Text = text;
            else if (control is ComboBox cb)
                cb.Text = text;
            // Можно расширить для других типов
        }

        private void ClearFormFields()
        {
            comboBox_GroupBox_ШЧ_РедактироватьДолжность.Text = "";
            comboBox_GroupBox_ШЧ_РедактироватьСтанция.Text = "";
            maskedTextBox_GroupBox_ШЧ_РедактироватьМобильный.Text = "";
            comboBox_GroupBox_ШЧ_РедактироватьУчасток.Text = "";
            comboBox_GroupBox_ШЧ_РедактироватьЦех.Text = "";
            textBox_GroupBox_ШЧ_РедактироватьПерегон.Text = "";
            textBox_GroupBox_ШЧ_РедактироватьДомАдрес.Text = "";
            //maskedTextBox1_ТелДом_Ред.Text = "";
            maskedTextBox_GroupBox_ШЧ_РедактироватьРабочий.Text = "";
            maskedTextBox_GroupBox_ШЧ_РедактироватьДеньРождения.Text = "";
            LoadDefaultPhoto();
        }

        private void LoadDefaultPhoto()
        {
            string defaultImagePath = @"Нет фото.bmp";
            try
            {
                if (File.Exists(defaultImagePath))
                {
                    pictureBox_GroupBox_ШЧ_Редактировать.Image?.Dispose();
                    pictureBox_GroupBox_ШЧ_Редактировать.Image = new Bitmap(defaultImagePath);
                }
                else
                {
                    pictureBox_GroupBox_ШЧ_Редактировать.Image = null;
                    pictureBox_GroupBox_ШЧ_Редактировать.BackColor = Color.LightGray; // визуальный индикатор отсутствия фото
                }
            }
            catch
            {
                pictureBox_GroupBox_ШЧ_Редактировать.Image = null;
                pictureBox_GroupBox_ШЧ_Редактировать.BackColor = Color.LightGray;
            }
        }

        // Простая эвристика: если первые 2 байта — 0x01 0x00 (OLE header), считаем OLE-объектом
        private bool IsLikelyOLEObject(byte[] data)
        {
            if (data == null || data.Length < 2) return false;
            return data[0] == 0x01 && data[1] == 0x00;
        }
        #endregion

        #region
        #endregion


        #region TextBox
        private void textBox_ШЧ_ПоискПоФамилии_TextChanged(object sender, EventArgs e)
        {
            groupBox_ШЧ_Редактировать.Visible = false;
            string searchText = textBox_ШЧ_ПоискПоФамилии.Text.Trim();

            if (textBox_ШЧ_ПоискПоФамилии.Text.ToString() != "")
            {
                string queryString = "SELECT фио as ФИО, должность as Должность, мобильный as Мобильный, телефон as [Рабочий телефон], цех as Цех " +
                    "FROM шч WHERE фио COLLATE NOCASE LIKE '" + textBox_ШЧ_ПоискПоФамилии.Text.ToString() + "%'";

                //Connection.ConnectionDataBase(dataGridView1, queryString);
                Connection.FillTable(dataGridView1, connectionString, queryString);
            }

            /*string searchText = textBox_ШЧ_ПоискПоФамилии.Text.Trim();

            // Очистка таблицы при пустом запросе (опционально)
            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                return;
            }

            // Безопасный параметризованный запрос
            string query = @"
            SELECT 
            fio AS [ФИО]
            FROM shch 
            WHERE fio LIKE @search 
            COLLATE NOCASE";

            // Передаём параметр: searchText + "%"
            DatabaseHelper.ExecuteQueryWithParams(dataGridView1, query, ("@search", searchText + "%"));*/
        }
        #endregion

        #region Button
        private void button_ШЧ_Добавить_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }

        private void button_GoupBox_ШЧ_РедактироватьСохранить_Click(object sender, EventArgs e)
        {
            UpdateData(connectionString);
            groupBox_ШЧ_Редактировать.Visible = false;
        }

        private void button_GroupBox_ШЧ_ДобавитьФото_Click(object sender, EventArgs e)
        {
            string fio = label_GroupBox_ШЧ_Редактировать.Text.Trim();

            if (string.IsNullOrEmpty(fio))
            {
                MessageBox.Show("Сначала выберите сотрудника (ФИО должно быть указано).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdatePhoto.UpdatePhotos(fio);
        }
        #endregion

        #region ComboBox
        private void comboBox_ШЧ_ПоискПоУчасткам_SelectedIndexChanged(object sender, EventArgs e)
        {
                // 1. Общая очистка состояния (Вынесено из if)
                groupBox_ШЧ_Редактировать.Visible = false;
                //dataGridView_РабочиеТелефоны.Visible = false;
                //textBox1_ШЧ_ФИО.Text = "";
                //comboBox1_ШЧ_Цеха.SelectedIndex = -1; // Если это нужно делать всегда

                string? selectedUchastok = comboBox_ШЧ_ПоискПоУчасткам.SelectedItem as string;

            // Переменные для динамического формирования запроса
            string selectFields = "фио as ФИО, должность as Должность, мобильный as Мобильный, телефон as [Рабочий телефон], цех as Цех";
            //string whereCondition = "";

                // 2. Использование switch для определения специфических условий (Вместо if/if/if...)
                switch (selectedUchastok)
                {
                    case "Администрация":
                    case "Гараж":
                        // Для "Гараж" выбираем меньше полей
                        if (selectedUchastok == "Гараж")
                            selectFields = "фио, должность, мобильный";
                        // whereCondition остается пустым, так как фильтрация только по участку
                        break;

                    case "ЛПУ СЦБ1":
                    case "ЛПУ СЦБ2":
                        // Используем условие WHERE IN для списка должностей
                        //string dolzhnosti = "'ШЧУ', 'ШНС', 'ШН', 'ШНД'";
                        //whereCondition = $" AND [должность] IN ({dolzhnosti})";
                        break;

                    default:
                        // Для всех остальных (ЛПУ систем автоматики, РТУ и т.д.)
                         // whereCondition остается пустым
                        break;
                }

            // 3. Формирование финального, параметризованного запроса (Устранение SQL-инъекций)
            // *** ПРИМЕЧАНИЕ: Здесь показан принцип, метод ConnectionDataBase должен быть изменен
            // для приема параметров, а не только строки SQL.
            //string queryString = $"SELECT {selectFields} FROM шч WHERE [участок] = {selectedUchastok}";

            string queryString =  $"SELECT {selectFields} FROM шч WHERE участок = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";

            // 4. Выполнение запроса (Предполагая, что ConnectionDataBase принимает параметры)
            // Connection.ConnectionDataBase(dataGridView1, queryString, new { Uchastok = selectedUchastok });
            //Connection.ConnectionDataBase(dataGridView1, queryString);
              Connection.FillTable(dataGridView1, connectionString, queryString);
        }
        #endregion

        #region DataGridWiew
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label_GroupBox_ШЧ_Редактировать.Text = dataGridView1.CurrentCell?.Value?.ToString();
            groupBox_ШЧ_Редактировать.Visible = true;
            
            ConnectionShow(dataGridView1);
            HideEmptyColumns.HideDataGridEmptyColumns(dataGridView1);
        }
        #endregion
    }
}
