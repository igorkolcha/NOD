using System.Windows.Forms;
using System.Data.SQLite;

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
            string searchText = textBox_ШЧ_ПоискПоФамилии.Text.Trim();

            if (textBox_ШЧ_ПоискПоФамилии.Text.ToString() != "")
            {
                string queryString = "SELECT fio as ФИО, position as Должность, mobile as Мобильный, phone as [Рабочий телефон], workshop as Цех " +
                    "FROM shch WHERE fio COLLATE NOCASE LIKE '" + textBox_ШЧ_ПоискПоФамилии.Text.ToString() + "%'";

                Connection.ConnectionDataBase(dataGridView1, queryString);
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

        private void button_ШЧ_Добавить_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }

        private void label_ШЧ_ПоискПоУчасткам_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_ШЧ_ПоискПоУчасткам_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string?)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "Администрация")
            {
                //textBox1_ШЧ_ФИО.Text = "";
                //comboBox1_ШЧ_Цеха.SelectedIndex = -1;

                string queryString = "SELECT fio, position, mobile, phone FROM shch WHERE position  = " +
                    "'" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string?)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "ЛПУ СЦБ1")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный,Цех FROM  ШЧ14 WHERE ([Должность] = " +
                    "'" + "ШЧУ" + "' OR [Должность] = '" + "ШНС" + "' OR [Должность] = '" + "ШН" +
                    "'OR [Должность] = '" + "ШНД" + "') " +
                    "AND [Участок]  = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "ЛПУ СЦБ2")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный,Цех FROM  ШЧ14 WHERE ([Должность] = " +
                    "'" + "ШН" + "' OR [Должность] = '" + "ШЧУ" + "' OR [Должность] = '" + "ШНС" +
                    "'OR [Должность] = '" + "ШНД" + "')  " +
                    "AND [Участок]  = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "ЛПУ систем автоматики")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный,Цех FROM  ШЧ14 WHERE [Участок] = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "ЛПУ проводной связи")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный,Цех FROM  ШЧ14 WHERE [Участок] = '" +
                    comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "ЛПУ радиосвязи,ГГО,АЛСН")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный,Цех FROM  ШЧ14 WHERE [Участок] = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "Гараж")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный FROM  ШЧ14 WHERE [Участок] = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }

            if ((string)comboBox_ШЧ_ПоискПоУчасткам.SelectedItem == "РТУ")
            {
                //textBox1_ШЧ_ФИО.Text = "";

                string queryString = "SELECT ФИО,Должность,Мобильный,Цех FROM  ШЧ14 WHERE [Участок] = '" + comboBox_ШЧ_ПоискПоУчасткам.SelectedItem + "'";
                Connection.ConnectionDataBase(dataGridView1, queryString);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label_GroupBox_ШЧ_Редактировать.Text = dataGridView1.CurrentCell.Value.ToString();
        }
    }
}
