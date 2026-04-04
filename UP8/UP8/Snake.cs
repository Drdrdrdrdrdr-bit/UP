using System;

namespace UP8
{
    internal class Snake
    {
        public record struct Point(float X, float Y);
        public record struct Apples(int G, int R);

        ISnake _form;

        public Point local;
        Point _nextLocal, _gApple, _rApple;
        float _speed;
        public Apples Eaten; 

        const int DS = 35;
        const int DA = 20; 
        const int CATCH_DIST = DA + DS; 

        Random _random = new Random();

        private int _rAppleTimer = 0;  
        private int _gAppleTimer = 0;
        private int _rAppleDelay = 0;  
        private int _gAppleDelay = 0;

        public bool RAppleVisible { get; private set; } = false;
        public bool GAppleVisible { get; private set; } = false;

        public Point RApplePos => _rApple;
        public Point GApplePos => _gApple;

        public Snake(ISnake form)
        {
            _form = form;
            local = new Point(100, 100);
            _nextLocal = new Point(-7f, 0f);
            _speed = 7f;
        }

        public void SetDirectionRight(PictureBox pict) { _nextLocal = new Point(_speed, 0); pict.Image = Properties.Resources.Right; }
        public void SetDirectionLeft(PictureBox pict) { _nextLocal = new Point(-_speed, 0); pict.Image = Properties.Resources.Left; }
        public void SetDirectionDown(PictureBox pict) { _nextLocal = new Point(0, _speed); pict.Image = Properties.Resources.Bottom; }
        public void SetDirectionUp(PictureBox pict) { _nextLocal = new Point(0, -_speed); pict.Image = Properties.Resources.Top; }



        public void Step(float h, float w)
        {
            local = new Point(local.X + _nextLocal.X, local.Y + _nextLocal.Y);

            if (local.X > w) local = new Point(0, local.Y);
            if (local.X < -DS) local = new Point(w, local.Y);
            if (local.Y > h) local = new Point(local.X, 0);
            if (local.Y < -DS) local = new Point(local.X, h);

            UpdateAppleTimers(h, w);

            CheckEating();
        }

        private void UpdateAppleTimers(float h, float w)
        {
            if (RAppleVisible)
            {
                _rAppleTimer--;
                if (_rAppleTimer <= 0)
                {
                    RAppleVisible = false;
                    _rAppleDelay = _random.Next(30, 100); 
                    _form.SetRAppleVisible(false);
                }
            }
            else
            {
                _rAppleDelay--;
                if (_rAppleDelay <= 0)
                {
                    _rApple = RandomPos(h, w);
                    RAppleVisible = true;
                    _rAppleTimer = _random.Next(100, 250); 
                    _form.SetRApplePos((int)_rApple.X, (int)_rApple.Y);
                    _form.SetRAppleVisible(true);
                }
            }

            if (GAppleVisible)
            {
                _gAppleTimer--;
                if (_gAppleTimer <= 0)
                {
                    GAppleVisible = false;
                    _gAppleDelay = _random.Next(50, 120);
                    _form.SetGAppleVisible(false);
                }
            }
            else
            {
                _gAppleDelay--;
                if (_gAppleDelay <= 0)
                {
                    _gApple = RandomPos(h, w);
                    GAppleVisible = true;
                    _gAppleTimer = _random.Next(80, 200);
                    _form.SetGApplePos((int)_gApple.X, (int)_gApple.Y);
                    _form.SetGAppleVisible(true);
                }
            }
        }

        private void CheckEating()
        {
            if (RAppleVisible)
            {
                float dx = Math.Abs(_rApple.X - local.X);
                float dy = Math.Abs(_rApple.Y - local.Y);
                if (dx <= CATCH_DIST && dy <= CATCH_DIST)
                {
                    Eaten = new Apples(Eaten.G, Eaten.R + 1);
                    RAppleVisible = false;
                    _rAppleDelay = _random.Next(30, 80);
                    _form.SetRAppleVisible(false);
                }
            }

            if (GAppleVisible)
            {
                float dx = Math.Abs(_gApple.X - local.X);
                float dy = Math.Abs(_gApple.Y - local.Y);
                if (dx <= CATCH_DIST && dy <= CATCH_DIST)
                {
                    Eaten = new Apples(Eaten.G + 1, Eaten.R);
                    GAppleVisible = false;
                    _gAppleDelay = _random.Next(50, 100);
                    _form.SetGAppleVisible(false);
                }
            }
        }

        private Point RandomPos(float h, float w)
        {
            return new Point(
                _random.Next(DA, (int)w - DA),
                _random.Next(DA + 50, (int)h - DA) 
            );
        }
    }
}