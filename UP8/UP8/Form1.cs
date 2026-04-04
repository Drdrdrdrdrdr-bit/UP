namespace UP8
{
    public partial class Form1 : Form, ISnake
    {
        private Snake _snake;
        private int _gameSeconds = 0; 
        private int _tickCount = 0;
        private bool _gameRunning = false;

        private const int TICKS_PER_SEC = 50;

        public Form1()
        {
            InitializeComponent();
            _snake = new Snake(this);

            KeyDown += Form1_KeyDown;
            KeyPreview = true;
            button1.Click += button1_Click;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            timer1.Enabled = false;
            UpdateTimerLabel();
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            _snake = new Snake(this);
            _tickCount = 0;
            _gameRunning = true;

            pictureBox1.Location = new Point(100, 100);
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            UpdateTimerLabel();

            timer1.Enabled = true;
            button1.Visible = false;
            pictureBox1.Focus();
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            if (!_gameRunning) return;

            _snake.Step(this.ClientSize.Height, this.ClientSize.Width);
            pictureBox1.Location = new Point((int)_snake.local.X, (int)_snake.local.Y);

            _tickCount++;
            if (_tickCount % TICKS_PER_SEC == 0)
            {
                _gameSeconds--;
                UpdateTimerLabel();

                if (_gameSeconds <= 0)
                    EndGame();
            }
        }
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!_gameRunning) return;

            switch (e.KeyCode)
            {
                case Keys.Right: _snake.SetDirectionRight(pictureBox1); break;
                case Keys.Left: _snake.SetDirectionLeft(pictureBox1); break;
                case Keys.Down: _snake.SetDirectionDown(pictureBox1); break;
                case Keys.Up: _snake.SetDirectionUp(pictureBox1); break;
            }
            e.Handled = true;
        }
        private void UpdateTimerLabel()
        {
            labelTimer.Text = $"{_gameSeconds} сек";
        }

        private void EndGame()
        {
            _gameRunning = false;
            timer1.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;

            var actual = _snake.Eaten;
            var dialog = new ResultForm();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                int guessR = dialog.GuessR;
                int guessG = dialog.GuessG;

                bool correctR = guessR == actual.R;
                bool correctG = guessG == actual.G;
                bool win = correctR && correctG
                                && (actual.R + actual.G) >= 5;

                string result = win ? "Победа!" : "Проигрыш.";

                MessageBox.Show(
                    $"{result}\n\n" +
                    $"Красных: реально {actual.R}, вы сказали {guessR}\n" +
                    $"Зелёных: реально {actual.G}, вы сказали {guessG}",
                    "Итог игры",
                    MessageBoxButtons.OK,
                    win ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                );
            }

            button1.Visible = true;
            _gameSeconds = 59;
            UpdateTimerLabel();
        }
        public void SetRApplePos(int x, int y) =>
            pictureBox2.Location = new Point(x, y);

        public void SetGApplePos(int x, int y) =>
            pictureBox3.Location = new Point(x, y);

        public void SetRAppleVisible(bool visible) =>
            pictureBox2.Visible = visible;

        public void SetGAppleVisible(bool visible) =>
            pictureBox3.Visible = visible;
    }
}