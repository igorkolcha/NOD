using System;
using System.Collections.Generic;
using System.Text;

namespace NOD
{
    internal class HideEmptyColumns
    {
        //скрывает столбцы в datagrid которые содержат пустые значения
        public static void HideDataGridEmptyColumns(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                bool allEmpty = true;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow) // пропускаем пустую строку для добавления
                    {
                        var cellValue = row.Cells[col.Index].Value;
                        if (cellValue != null &&
                            cellValue != DBNull.Value &&
                            !string.IsNullOrWhiteSpace(cellValue.ToString()))
                        {
                            allEmpty = false;
                            break;
                        }
                    }
                }

                col.Visible = !allEmpty;
            }
        }
    }
}
