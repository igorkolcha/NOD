namespace NOD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button_ШЧ_Добавить = new Button();
            textBox_ШЧ_ПоискПоФамилии = new TextBox();
            label_ШЧ_ПоискПоФамилии = new Label();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            label_ШЧ_ПоискПоУчасткам = new Label();
            comboBox_ШЧ_ПоискПоУчасткам = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(795, 140);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(comboBox_ШЧ_ПоискПоУчасткам);
            tabPage1.Controls.Add(label_ШЧ_ПоискПоУчасткам);
            tabPage1.Controls.Add(button_ШЧ_Добавить);
            tabPage1.Controls.Add(textBox_ШЧ_ПоискПоФамилии);
            tabPage1.Controls.Add(label_ШЧ_ПоискПоФамилии);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(787, 112);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "ШЧ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_ШЧ_Добавить
            // 
            button_ШЧ_Добавить.Location = new Point(588, 42);
            button_ШЧ_Добавить.Name = "button_ШЧ_Добавить";
            button_ШЧ_Добавить.Size = new Size(141, 31);
            button_ШЧ_Добавить.TabIndex = 2;
            button_ШЧ_Добавить.Text = "Добавить";
            button_ШЧ_Добавить.UseVisualStyleBackColor = true;
            button_ШЧ_Добавить.Click += button_ШЧ_Добавить_Click;
            // 
            // textBox_ШЧ_ПоискПоФамилии
            // 
            textBox_ШЧ_ПоискПоФамилии.Location = new Point(25, 50);
            textBox_ШЧ_ПоискПоФамилии.Name = "textBox_ШЧ_ПоискПоФамилии";
            textBox_ШЧ_ПоискПоФамилии.Size = new Size(169, 23);
            textBox_ШЧ_ПоискПоФамилии.TabIndex = 1;
            textBox_ШЧ_ПоискПоФамилии.TextChanged += textBox_ШЧ_ПоискПоФамилии_TextChanged;
            // 
            // label_ШЧ_ПоискПоФамилии
            // 
            label_ШЧ_ПоискПоФамилии.AutoSize = true;
            label_ШЧ_ПоискПоФамилии.Location = new Point(53, 22);
            label_ШЧ_ПоискПоФамилии.Name = "label_ШЧ_ПоискПоФамилии";
            label_ШЧ_ПоискПоФамилии.Size = new Size(114, 15);
            label_ШЧ_ПоискПоФамилии.TabIndex = 0;
            label_ШЧ_ПоискПоФамилии.Text = "Поиск по фамилии";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(787, 112);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(788, 150);
            dataGridView1.TabIndex = 1;
            // 
            // label_ШЧ_ПоискПоУчасткам
            // 
            label_ШЧ_ПоискПоУчасткам.AutoSize = true;
            label_ШЧ_ПоискПоУчасткам.Location = new Point(270, 18);
            label_ШЧ_ПоискПоУчасткам.Name = "label_ШЧ_ПоискПоУчасткам";
            label_ШЧ_ПоискПоУчасткам.Size = new Size(113, 15);
            label_ШЧ_ПоискПоУчасткам.TabIndex = 3;
            label_ШЧ_ПоискПоУчасткам.Text = "Поиск по участкам";
            label_ШЧ_ПоискПоУчасткам.Click += label_ШЧ_ПоискПоУчасткам_Click;
            // 
            // comboBox_ШЧ_ПоискПоУчасткам
            // 
            comboBox_ШЧ_ПоискПоУчасткам.FormattingEnabled = true;
            comboBox_ШЧ_ПоискПоУчасткам.Items.AddRange(new object[] { "Администрация", "ЛПУ СЦБ1", "ЛПУ СЦБ2", "ЛПУ систем автоматики", "ЛПУ радиосвязи,ГГО,АЛСН", "ЛПУ проводной связи", "Гараж", "РТУ" });
            comboBox_ШЧ_ПоискПоУчасткам.Location = new Point(249, 50);
            comboBox_ШЧ_ПоискПоУчасткам.Name = "comboBox_ШЧ_ПоискПоУчасткам";
            comboBox_ШЧ_ПоискПоУчасткам.Size = new Size(168, 23);
            comboBox_ШЧ_ПоискПоУчасткам.TabIndex = 4;
            comboBox_ШЧ_ПоискПоУчасткам.SelectedIndexChanged += comboBox_ШЧ_ПоискПоУчасткам_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "ШЧД";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox_ШЧ_ПоискПоФамилии;
        private Label label_ШЧ_ПоискПоФамилии;
        private DataGridView dataGridView1;
        private Button button_ШЧ_Добавить;
        private Label label_ШЧ_ПоискПоУчасткам;
        private ComboBox comboBox_ШЧ_ПоискПоУчасткам;
    }
}
