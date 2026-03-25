namespace UP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 100) numericUpDown1.Value = 100;
            if (numericUpDown2.Value > 100) numericUpDown2.Value = 100;
            if (numericUpDown3.Value > 100) numericUpDown3.Value = 100;
            if (numericUpDown4.Value > 100) numericUpDown4.Value = 100;
        }
    }
}
