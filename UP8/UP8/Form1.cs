namespace UP8
{
    public partial class Form1 : Form, ISnake
    {
        private Snake _snake;
        public Form1()
        {
            InitializeComponent();
            _snake = new Snake(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _snake.Step(this.Height, this.Width);
            pictureBox1.Location = new Point((int)_snake.local.X, (int)_snake.local.Y);
        }

        public void EatRApple()
        {
            pictureBox2.Visible = false;
            _snake.SetPositionRApple(this.Height, this.Width);
            pictureBox2.Visible = true;
        }

        public void EatGApple()
        {
            pictureBox3.Visible = false;
            _snake.SetPositionGApple(this.Height, this.Width);
            pictureBox3.Visible = true;
        }
    }
}
