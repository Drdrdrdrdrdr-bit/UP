namespace UP3
{
    partial class Form2
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
            trackBar2 = new TrackBar();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(45, 76);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(312, 56);
            trackBar2.TabIndex = 11;
            trackBar2.TickStyle = TickStyle.TopLeft;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(177, 160);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 10;
            label4.Text = "Цвет";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 26);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 9;
            label3.Text = "Скорость";
            // 
            // label2
            // 
            label2.BackColor = Color.Red;
            label2.Location = new Point(238, 183);
            label2.Name = "label2";
            label2.Size = new Size(62, 55);
            label2.TabIndex = 8;
            label2.Text = " ";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(128, 128, 255);
            label1.Location = new Point(94, 183);
            label1.Name = "label1";
            label1.Size = new Size(62, 55);
            label1.TabIndex = 7;
            label1.Text = " ";
            label1.Click += label1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 282);
            Controls.Add(trackBar2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}