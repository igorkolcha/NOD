using System.Windows.Forms;

namespace NOD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_ШЧ_ПоискПоФамилии_TextChanged(object sender, EventArgs e)
        {
            /*string searchText = textBox_ШЧ_ПоискПоФамилии.Text.Trim();

            if (textBox_ШЧ_ПоискПоФамилии.Text.ToString() != "")
            {
                string queryString = "SELECT fio as ФИО, position as Должность, mobile as Мобильный, phone as [Рабочий телефон], workshop as Цех " +
                    "FROM shch WHERE fio COLLATE NOCASE LIKE '" + textBox_ШЧ_ПоискПоФамилии.Text.ToString() + "%'";

                Connection.ConnectionDataBase(dataGridView1, queryString);
            }*/

            string searchText = textBox_ШЧ_ПоискПоФамилии.Text.Trim();

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
            FROM shch14 
            WHERE fio LIKE @search 
            COLLATE NOCASE";

            // Передаём параметр: searchText + "%"
            DatabaseHelper.ExecuteQueryWithParams(dataGridView1, query, ("@search", searchText + "%"));
        }
    }
}
