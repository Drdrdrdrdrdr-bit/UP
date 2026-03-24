using System;
using System.Collections.Generic;
using System.Text;

namespace UP2
{
    internal class Segment
    {
        public record struct Point(double X, double Y);

        public Point A { get; set; }, B;


        public Segment(double x1, double y1, double x2, double y2)
        {
            A.X = x1;
            A.Y = y1;
            B.X = x2;
            B.Y = y2;
        }

        static int GetQuadrant(Point p)
        {
            if (p.X == 0 || p.Y == 0) return 0; // На пересечении осей

            return (p.X > 0, p.Y > 0) switch
            {
                (true, true) => 1, 
                (false, true) => 2, 
                (false, false) => 3, 
                (true, false) => 4, 
            };
        }


    }
}
