namespace NOD
{
    partial class AddEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_AddEmployee_Отчество = new Label();
            textBox_AddEmployee_Фамилия = new TextBox();
            textBox_AddEmployee_Имя = new TextBox();
            textBox_AddEmployee_Отчество = new TextBox();
            button_AddEmployee_Сохранить = new Button();
            label_AddEmployee_Фамилия = new Label();
            label_AddEmployee_Имя = new Label();
            SuspendLayout();
            // 
            // label_AddEmployee_Отчество
            // 
            label_AddEmployee_Отчество.AutoSize = true;
            label_AddEmployee_Отчество.Location = new Point(64, 245);
            label_AddEmployee_Отчество.Name = "label_AddEmployee_Отчество";
            label_AddEmployee_Отчество.Size = new Size(58, 15);
            label_AddEmployee_Отчество.TabIndex = 2;
            label_AddEmployee_Отчество.Text = "Отчество";
            // 
            // textBox_AddEmployee_Фамилия
            // 
            textBox_AddEmployee_Фамилия.Location = new Point(236, 72);
            textBox_AddEmployee_Фамилия.Name = "textBox_AddEmployee_Фамилия";
            textBox_AddEmployee_Фамилия.Size = new Size(166, 23);
            textBox_AddEmployee_Фамилия.TabIndex = 3;
            // 
            // textBox_AddEmployee_Имя
            // 
            textBox_AddEmployee_Имя.Location = new Point(236, 157);
            textBox_AddEmployee_Имя.Name = "textBox_AddEmployee_Имя";
            textBox_AddEmployee_Имя.Size = new Size(166, 23);
            textBox_AddEmployee_Имя.TabIndex = 4;
            // 
            // textBox_AddEmployee_Отчество
            // 
            textBox_AddEmployee_Отчество.Location = new Point(236, 242);
            textBox_AddEmployee_Отчество.Name = "textBox_AddEmployee_Отчество";
            textBox_AddEmployee_Отчество.Size = new Size(166, 23);
            textBox_AddEmployee_Отчество.TabIndex = 5;
            // 
            // button_AddEmployee_Сохранить
            // 
            button_AddEmployee_Сохранить.Location = new Point(198, 334);
            button_AddEmployee_Сохранить.Name = "button_AddEmployee_Сохранить";
            button_AddEmployee_Сохранить.Size = new Size(116, 51);
            button_AddEmployee_Сохранить.TabIndex = 6;
            button_AddEmployee_Сохранить.Text = "Сохранить";
            button_AddEmployee_Сохранить.UseVisualStyleBackColor = true;
            button_AddEmployee_Сохранить.Click += button_AddEmployee_Сохранить_Click;
            // 
            // label_AddEmployee_Фамилия
            // 
            label_AddEmployee_Фамилия.AutoSize = true;
            label_AddEmployee_Фамилия.Location = new Point(71, 69);
            label_AddEmployee_Фамилия.Name = "label_AddEmployee_Фамилия";
            label_AddEmployee_Фамилия.Size = new Size(58, 15);
            label_AddEmployee_Фамилия.TabIndex = 7;
            label_AddEmployee_Фамилия.Text = "Фамилия";
            // 
            // label_AddEmployee_Имя
            // 
            label_AddEmployee_Имя.AutoSize = true;
            label_AddEmployee_Имя.Location = new Point(72, 154);
            label_AddEmployee_Имя.Name = "label_AddEmployee_Имя";
            label_AddEmployee_Имя.Size = new Size(31, 15);
            label_AddEmployee_Имя.TabIndex = 8;
            label_AddEmployee_Имя.Text = "Имя";
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 450);
            Controls.Add(label_AddEmployee_Имя);
            Controls.Add(label_AddEmployee_Фамилия);
            Controls.Add(button_AddEmployee_Сохранить);
            Controls.Add(textBox_AddEmployee_Отчество);
            Controls.Add(textBox_AddEmployee_Имя);
            Controls.Add(textBox_AddEmployee_Фамилия);
            Controls.Add(label_AddEmployee_Отчество);
            Name = "AddEmployee";
            Text = "Добавить работника";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //private Label label1;
        //private Label label2;
        private Label label_AddEmployee_Отчество;
        private TextBox textBox_AddEmployee_Фамилия;
        private TextBox textBox_AddEmployee_Имя;
        private TextBox textBox_AddEmployee_Отчество;
        private Button button_AddEmployee_Сохранить;
        private Label label_AddEmployee_Фамилия;
        private Label label_AddEmployee_Имя;
    }
}