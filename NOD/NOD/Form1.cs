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
            //string searchText = textBox_ШЧ_ПоискПоФамилии.Text.Trim();

            if (textBox_ШЧ_ПоискПоФамилии.Text.ToString() != "")
            {
                string queryString = "SELECT fio as ФИО, position as Должность, mobile as Мобильный, phone as [Рабочий телефон], workshop as Цех " +
                    "FROM shch WHERE fio LIKE '" + textBox_ШЧ_ПоискПоФамилии.Text.ToString() + "%'";

                Connection.ConnectionDataBase(dataGridView1, queryString);
            }
        }
    }
}
