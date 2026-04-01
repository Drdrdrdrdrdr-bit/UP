namespace UP5
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
            textBox3 = new TextBox();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохрРезультToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            заданиеToolStripMenuItem = new ToolStripMenuItem();
            лавинштейнToolStripMenuItem = new ToolStripMenuItem();
            задачаToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Top;
            textBox3.Location = new Point(0, 0);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(688, 27);
            textBox3.TabIndex = 2;
            textBox3.TextChanged += Label2_TextChanged;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(10, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 28);
            button1.TabIndex = 3;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem, заданиеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохрРезультToolStripMenuItem, загрузитьToolStripMenuItem });
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(59, 24);
            сохранитьToolStripMenuItem.Text = "Файл";
            // 
            // сохрРезультToolStripMenuItem
            // 
            сохрРезультToolStripMenuItem.Name = "сохрРезультToolStripMenuItem";
            сохрРезультToolStripMenuItem.Size = new Size(189, 26);
            сохрРезультToolStripMenuItem.Text = "Сохр. результ.";
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(189, 26);
            загрузитьToolStripMenuItem.Text = "Загрузить";
            // 
            // заданиеToolStripMenuItem
            // 
            заданиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { лавинштейнToolStripMenuItem, задачаToolStripMenuItem });
            заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            заданиеToolStripMenuItem.Size = new Size(85, 24);
            заданиеToolStripMenuItem.Text = "Задание ";
            // 
            // лавинштейнToolStripMenuItem
            // 
            лавинштейнToolStripMenuItem.Checked = true;
            лавинштейнToolStripMenuItem.CheckOnClick = true;
            лавинштейнToolStripMenuItem.CheckState = CheckState.Checked;
            лавинштейнToolStripMenuItem.Name = "лавинштейнToolStripMenuItem";
            лавинштейнToolStripMenuItem.Size = new Size(180, 26);
            лавинштейнToolStripMenuItem.Text = "Лавинштейн";
            лавинштейнToolStripMenuItem.Click += лавинштейнToolStripMenuItem_Click;
            // 
            // задачаToolStripMenuItem
            // 
            задачаToolStripMenuItem.CheckOnClick = true;
            задачаToolStripMenuItem.Name = "задачаToolStripMenuItem";
            задачаToolStripMenuItem.Size = new Size(180, 26);
            задачаToolStripMenuItem.Text = "Задача";
            задачаToolStripMenuItem.Click += задачаToolStripMenuItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Dock = DockStyle.Right;
            groupBox2.Location = new Point(688, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(112, 284);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(12, 12);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 6;
            button6.Text = "Найти";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(10, 81);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 5;
            button5.Text = "Удалить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(10, 46);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Вставить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 30);
            label1.TabIndex = 9;
            label1.Text = "Путь к ф. сохр. :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 10;
            label2.TextChanged += Label2_TextChanged;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 28);
            label3.TabIndex = 11;
            label3.Text = "Путь загр. ф. :";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 12;
            label4.TextChanged += Label2_TextChanged;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Right;
            button3.Location = new Point(660, 0);
            button3.Name = "button3";
            button3.Size = new Size(28, 28);
            button3.TabIndex = 0;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Right;
            button4.Location = new Point(660, 0);
            button4.Name = "button4";
            button4.Size = new Size(28, 30);
            button4.TabIndex = 0;
            button4.Text = "...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(textBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(688, 284);
            panel1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Bottom;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(0, 264);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 15;
            label5.Text = "label5";
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 55);
            panel3.Name = "panel3";
            panel3.Size = new Size(688, 30);
            panel3.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(688, 28);
            panel2.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 312);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
        private ToolStripMenuItem сохрРезультToolStripMenuItem;
        private ToolStripMenuItem загрузитьToolStripMenuItem;
        private GroupBox groupBox2;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ToolStripMenuItem заданиеToolStripMenuItem;
        private ToolStripMenuItem лавинштейнToolStripMenuItem;
        private ToolStripMenuItem задачаToolStripMenuItem;
        private Button button6;
        private Button button5;
        private Label label5;
    }
}
