using System;
using System.Collections.Generic;
using System.Text;

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
        Apples _apples;
        const int MINAPPLES = 10, DS = 35, DA = 20;
        Random _random = new Random();

        public Snake(ISnake form)
        {
            _form = form;
            _nextLocal.Y = local.X = local.Y = _apples.G = _apples.R = 0;
            _speed = 7f;
            SetDirectionLeft();
        }

        public void SetDirectionRight()
        {
            _nextLocal.X = _speed;
        }

        public void SetDirectionLeft()
        {
            _nextLocal.X = -_speed;
        }

        public void SetDirectionTop()
        {
            _nextLocal.Y = _speed;
        }

        public void SetDirectionBottom()
        {
            _nextLocal.Y = -_speed;
        }

        public void SetPositionRApple(float h, float w)
        {
            _rApple.X = _random.Next() % (w + 2 * DA);
            _rApple.Y = _random.Next() % (h + 2 * DA);
        }

        public void SetPositionGApple(float h, float w)
        {
            _gApple.X = _random.Next() % (w + 2 * DA);
            _gApple.Y = _random.Next() % (h + 2 * DA);
        }

        public void Step(float h, float w)
        {
            local.Y += _nextLocal.Y;
            local.X += _nextLocal.X;

            float rx = Math.Abs((_rApple.X - local.X));
            float ry = Math.Abs((_rApple.Y - local.Y));
            float gx = Math.Abs((_gApple.X - local.X));
            float gy = Math.Abs((_gApple.Y - local.Y));

            if ((rx >= 0 && rx <= (DA + DS)) || (rx >= 0 && rx <= (DA + DS)))
            {
                _form.EatRApple();
                _apples.R++;
            }
            if ((gx >= 0 && gx <= (DA + DS)) || (gx >= 0 && gx <= (DA + DS)))
            {
                _form.EatGApple();
                _apples.G++;
            }
            if (local.X > w) local.X = 0; 
            if (local.X < 0 - DS) local.X = w; 
            if (local.Y > h) local.X = 0; 
            if (local.Y < 0 - DS) local.X = h; 
            //if (_nextLocal.X != 0)
            //{
            //    if (_nextLocal.X > 0)
            //    {
            //        float x = (_rApple.X - DA - DS - _local.X) * (_rApple.X - DA - DS - _local.X);
            //        if (x >= 0 && x <= 0.5)
            //    }
            //    else
            //    {

            //    }
            //}
            //if (_nextLocal.Y != 0)
            //{
            //    if (_nextLocal.Y > 0)
            //    {

            //    }
            //    else
            //    {

            //    }
            //}
        }
    }
}
