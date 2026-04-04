namespace UP8
{
    partial class ResultForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblR = new Label();
            lblG = new Label();
            nudR = new NumericUpDown();
            nudG = new NumericUpDown();
            btnOk = new Button();

            ((System.ComponentModel.ISupportInitialize)nudR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudG).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.Text = "Время вышло! Введите ваши подсчёты:";
            lblTitle.Font = new Font("Arial", 11, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Size = new Size(310, 40);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblR
            lblR.Text = "Сколько красных 🔴 яблок съели?";
            lblR.Location = new Point(15, 70);
            lblR.Size = new Size(230, 25);

            // nudR
            nudR.Location = new Point(255, 68);
            nudR.Width = 65;
            nudR.Minimum = 0;
            nudR.Maximum = 999;
            nudR.Value = 0;

            // lblG
            lblG.Text = "Сколько зелёных 🟢 яблок съели?";
            lblG.Location = new Point(15, 110);
            lblG.Size = new Size(230, 25);

            // nudG
            nudG.Location = new Point(255, 108);
            nudG.Width = 65;
            nudG.Minimum = 0;
            nudG.Maximum = 999;
            nudG.Value = 0;

            // btnOk
            btnOk.Text = "Подтвердить";
            btnOk.Location = new Point(110, 155);
            btnOk.Size = new Size(110, 35);
            btnOk.Click += btnOk_Click;

            // Form
            AcceptButton = btnOk;
            ClientSize = new Size(340, 210);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Итоги игры";

            Controls.AddRange(new Control[]
                { lblTitle, lblR, nudR, lblG, nudG, btnOk });

            ((System.ComponentModel.ISupportInitialize)nudR).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudG).EndInit();
            ResumeLayout(false);
        }

        private Label lblTitle, lblR, lblG;
        private NumericUpDown nudR, nudG;
        private Button btnOk;
    }
}