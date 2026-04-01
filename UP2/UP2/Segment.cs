using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace UP2
{
    public class Segment
    {
        public record struct Point(float X, float Y);

        public Point A, B;
        private ISegment _form;

        public Segment(ISegment form, float x1, float y1, float x2, float y2)
        {
            _form = form;
            UpdatePoint(x1, y1, x2, y2);
        }
        public void UpdatePoint(float x1, float y1, float x2, float y2)
        {
            A.X = x1;
            A.Y = y1;
            B.X = x2;
            B.Y = y2;
        }
        public void GetQuadrant()
        {
            //if (p.X == 0 || p.Y == 0) return 0; // На пересечении осей

            //return (p.X > 0, p.Y > 0) switch
            //{
            //    (true, true) => 1, 
            //    (false, true) => 2, 
            //    (false, false) => 3, 
            //    (true, false) => 4, 
            //};
            float dX = B.X - A.X, dY = B.Y - A.Y;
            //float A.X = (float)(Math.Abs(numericUpDown1.Value) + Math.Abs(numericUpDown2.Value));
            //float A.Y = (float)(Math.Abs(numericUpDown4.Value) + Math.Abs(numericUpDown3.Value));
            //float y = (A.Y / A.X * (float)numericUpDown2.Value) + (float)numericUpDown3.Value;
            //float x = (A.X / A.Y * (float)numericUpDown4.Value) + (float)numericUpDown1.Value;

            //label5.Text = "";
            //if (x == 0 && y == 0 || (x + y) == 0) label5.Text = "Отрезок пересикает центр системы координат";
            //else
            //{
            //    byte d1 = 0;
            //    byte d2 = 0;
            //    //if (numericUpDown2.Value == 0 || (int)numericUpDown3.Value == 0) d1 += 1; 
            //    //if (numericUpDown1.Value == 0 || (int)numericUpDown4.Value == 0) d2 += 1; 

            //    d1 = (numericUpDown2.Value > 0, numericUpDown3.Value > 0) switch
            //    {
            //        (true, true) => d1 = 2,
            //        (false, true) => d1 = 4,
            //        (false, false) => d1 = 8,
            //        (true, false) => d1 = 16,
            //    };

            //    d2 = (numericUpDown1.Value > 0, numericUpDown4.Value > 0) switch
            //    {
            //        (true, true) => 1,
            //        (false, true) => 2,
            //        (false, false) => 3,
            //        (true, false) => 4,
            //    };

            //label5.Text = $"{(x)} {y} {A.X} {A.Y} {d1} {d2} ";
            //if (A.X * B.X > 0)
            float f = A.X + (-A.Y / (B.Y - A.Y)) * (B.X - A.X);
            //label5.Text = $"{f} | {-A.Y / (B.Y - A.Y)} | {B.X - A.X} {B.Y - A.Y} {Math.Abs(dX) / Math.Abs(dY) * B.Y + B.X} " +
            //                                  $"{Math.Abs(dY) / Math.Abs(dX) * B.X + B.Y} " +
            //                                  $"{Math.Abs(dX) / Math.Abs(dY) * A.Y + A.X} " +
            //                                  $"{Math.Abs(dY) / Math.Abs(dX) * A.X + A.Y}";
            byte c = 0;

            if (B.X != 0 && B.Y != 0)
                c |= (B.X > 0, B.Y > 0) switch
                {
                    (true, true) => 2,
                    (false, true) => 4,
                    (false, false) => 8,
                    (true, false) => 16,
                };

            if (A.X != 0 && A.Y != 0)
                c |= (A.X > 0, A.Y > 0) switch
                {
                    (true, true) => 2,
                    (false, true) => 4,
                    (false, false) => 8,
                    (true, false) => 16,
                };

            if (dY != 0)
            {
                float t = -A.Y / dY;
                float crossX = A.X + t * dX;
                if (t > 0 && t < 1)
                {
                    if (crossX > 0) c |= 18;
                    if (crossX < 0) c |= 12;
                }
            }

            if (dX != 0)
            {
                float t = -A.X / dX;
                float crossY = A.Y + t * dY;
                if (t > 0 && t < 1)
                {
                    if (crossY > 0) c |= 6;
                    if (crossY < 0) c |= 24;
                }
            }
            string mass = "Отрезок пересикает ";
            if ((c & 2) != 0) mass += "1ч. ";
            if ((c & 4) != 0) mass += "2ч. ";
            if ((c & 8) != 0) mass += "3ч. ";
            if ((c & 16) != 0) mass += "4ч. ";
            _form.PrintQuadrant(mass);   
        }


    }
}
