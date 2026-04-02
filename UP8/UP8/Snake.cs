using System;
using System.Collections.Generic;
using System.Text;

namespace UP8
{
    internal class Snake
    {
        public record struct Point(float X, float Y, int G, int R);

        Point _local;
        float _speed;

        public Snake()
        {
            _local.X = _local.Y = _local.G = _local.R = 0;
            _speed = .5f;
        }
    }
}
