namespace UP3
{
    public partial class Form1 : Form, ISettings
    {
        private float _posY;
        private float _size = 40;
        private float _sizeDir = 0.5f;
        private bool _goingDown = true;
        private int _time = DateTime.Now.Millisecond;

        public int speed { get; set; } = 2;
        public Color colorStart { get; set; } = Color.Red;
        public Color colorEnd { get; set; } = Color.Blue;

        public Form1()
        {
            InitializeComponent();
            _posY = Height / 2;
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        public void SetSpeed(int speed)
        {
            speed = speed;
        }

        private Color SetColor() => Color.FromArgb(
                red: (int)(colorStart.R + (colorEnd.R - colorStart.R) * (Math.Sin(_time) * 0.5 + 0.5)),
                green: (int)(colorStart.G + (colorEnd.G - colorStart.G) * (Math.Sin(_time) * 0.5 + 0.5)),
                blue: (int)(colorStart.B + (colorEnd.B - colorStart.B) * (Math.Sin(_time) * 0.5 + 0.5))
                );

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_goingDown)
            {
                _posY += speed;
                if (_posY >= ClientSize.Height - 30) _goingDown = false; // достигли низа
            }
            else
            {
                _posY -= speed;
                if (_posY <= 0 + 30) _goingDown = true; // достигли верха
            }

            // Пульсация размера
            _size += _sizeDir * speed;
            if (_size >= 100 || _size <= 20) _sizeDir = -_sizeDir;

            _time = DateTime.Now.Millisecond;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int cx = Width / 2;

            g.FillEllipse(
                new SolidBrush(SetColor()),
                cx - _size, _posY - 30,
                _size * 2, 30
            );
        }
    }
}
