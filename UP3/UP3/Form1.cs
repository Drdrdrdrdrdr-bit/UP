namespace UP3
{
    public partial class Form1 : Form, ISettings
    {
        static float _speed = 4;

        public Color colorStart { get; set; } = Color.Red;
        public Color colorEnd { get; set; } = Color.Blue;

        public Form1()
        {
            InitializeComponent();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        public void SetSpeed(int speed) 
        { 
            _speed = speed;
        }

        private Color SetColor(float coeff) => Color.FromArgb(
                red: (int)(colorStart.R + (colorEnd.R - colorStart.R) * coeff),
                green: (int)(colorStart.G + (colorEnd.G - colorStart.G) * coeff),
                blue: (int)(colorStart.B + (colorEnd.B - colorStart.B) * coeff)
                );
    }
}
