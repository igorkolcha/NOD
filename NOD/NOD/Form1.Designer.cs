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
            tabPage2 = new TabPage();
            label_ШЧ_ПоискПоФамилии = new Label();
            textBox_ШЧ_ПоискПоФамилии = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
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
            // label_ШЧ_ПоискПоФамилии
            // 
            label_ШЧ_ПоискПоФамилии.AutoSize = true;
            label_ШЧ_ПоискПоФамилии.Location = new Point(53, 22);
            label_ШЧ_ПоискПоФамилии.Name = "label_ШЧ_ПоискПоФамилии";
            label_ШЧ_ПоискПоФамилии.Size = new Size(114, 15);
            label_ШЧ_ПоискПоФамилии.TabIndex = 0;
            label_ШЧ_ПоискПоФамилии.Text = "Поиск по фамилии";
            // 
            // textBox_ШЧ_ПоискПоФамилии
            // 
            textBox_ШЧ_ПоискПоФамилии.Location = new Point(25, 50);
            textBox_ШЧ_ПоискПоФамилии.Multiline = true;
            textBox_ШЧ_ПоискПоФамилии.Name = "textBox_ШЧ_ПоискПоФамилии";
            textBox_ШЧ_ПоискПоФамилии.Size = new Size(169, 30);
            textBox_ШЧ_ПоискПоФамилии.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "ШЧД";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox_ШЧ_ПоискПоФамилии;
        private Label label_ШЧ_ПоискПоФамилии;
    }
}
