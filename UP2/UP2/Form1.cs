using System.Data.SqlTypes;
using System.Security.Cryptography.Xml;
using System.Windows.Forms.DataVisualization.Charting;
namespace UP2
{
    public partial class Form1 : Form
    {
        private Chart _chart;

        //private Segment _segment = new Segment();
        public Form1()
        {
            InitializeComponent();
            InitChart();
            DrawSegment();
        }

        private void InitChart()
        {
            
            _chart = new Chart { Dock = DockStyle.Fill };

            var area = new ChartArea("Main");


            // Ось X 
            area.AxisX.Minimum = -10;
            area.AxisX.Maximum = 10;
            area.AxisX.Interval = 1;
            area.AxisX.Crossing = 0;
            area.AxisX.Title = "X";
            area.AxisX.TitleAlignment = StringAlignment.Far;
            area.AxisX.LineColor = Color.Black;
            area.AxisX.LineWidth = 2;
            area.AxisX.MajorTickMark.Enabled = true;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            // Ось Y 
            area.AxisY.Minimum = -10;
            area.AxisY.Maximum = 10;
            area.AxisY.Interval = 1;
            area.AxisY.Crossing = 0;
            area.AxisY.Title = "Y";
            area.AxisY.TitleAlignment = StringAlignment.Far;
            area.AxisY.LineColor = Color.Black;
            area.AxisY.LineWidth = 2;
            area.AxisY.MajorTickMark.Enabled = true;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            area.BackColor = Color.White;

            _chart.ChartAreas.Add(area);
            Controls.Add(_chart);

        }

        private void DrawSegment()
        {
            _chart.Series.Clear();

            var segment = new Series()
            {
                ChartType = SeriesChartType.Line,  
                Color = Color.Red,
                BorderWidth = 2,
                ChartArea = "Main",

                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerColor = Color.Black,

            };

            segment.Points.AddXY(numericUpDown1.Value, numericUpDown4.Value);
            segment.Points.AddXY(numericUpDown2.Value, numericUpDown3.Value);

            segment.Points[0].Label = $"A";
            segment.Points[1].Label = $"B";
            segment.Points[1].ToolTip = "X = #VALX, Y = #VALY";
            segment.Points[0].ToolTip = "X = #VALX, Y = #VALY";
            segment.Points[0].LabelForeColor = Color.Red;
            segment.Points[1].LabelForeColor = Color.Red;

            _chart.Series.Add(segment);


            var origin = new Series()
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5,
                MarkerColor = Color.Black,
                IsVisibleInLegend = false
            };
            origin.Points.AddXY(0, 0);
            _chart.Series.Add(origin);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 10) numericUpDown1.Value = 10;
            if (numericUpDown2.Value > 10) numericUpDown2.Value = 10;
            if (numericUpDown3.Value > 10) numericUpDown3.Value = 10;
            if (numericUpDown4.Value > 10) numericUpDown4.Value = 10;

            if (numericUpDown1.Value < -10) numericUpDown1.Value = -10;
            if (numericUpDown2.Value < -10) numericUpDown2.Value = -10;
            if (numericUpDown3.Value < -10) numericUpDown3.Value = -10;
            if (numericUpDown4.Value < -10) numericUpDown4.Value = -10;

            DrawSegment();

            float aX = (int)numericUpDown1.Value, aY = (int)numericUpDown4.Value, bX = (int)numericUpDown2.Value, bY = (int)numericUpDown3.Value;

            float dX = bX - aX, dY = bY - aY;
            //float aX = (float)(Math.Abs(numericUpDown1.Value) + Math.Abs(numericUpDown2.Value));
            //float aY = (float)(Math.Abs(numericUpDown4.Value) + Math.Abs(numericUpDown3.Value));
            //float y = (aY / aX * (float)numericUpDown2.Value) + (float)numericUpDown3.Value;
            //float x = (aX / aY * (float)numericUpDown4.Value) + (float)numericUpDown1.Value;

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

            //label5.Text = $"{(x)} {y} {aX} {aY} {d1} {d2} ";
            //if (aX * bX > 0)
            float f = aX + (-aY / (bY - aY)) * (bX - aX);
            label5.Text = $"{f} | {-aY / (bY - aY)} | {bX - aX} {bY - aY} {Math.Abs(dX) / Math.Abs(dY) * bY + bX} " +
                                              $"{Math.Abs(dY) / Math.Abs(dX) * bX + bY} " +
                                              $"{Math.Abs(dX) / Math.Abs(dY) * aY + aX} " +
                                              $"{Math.Abs(dY) / Math.Abs(dX) * aX + aY}";
            byte c = 0;

            if (bX != 0 && bY != 0)
                c |= (bX > 0, bY > 0) switch
                {
                    (true, true) => 2,
                    (false, true) => 4,
                    (false, false) => 8,
                    (true, false) => 16,
                };

            if (aX != 0 && aY != 0)
                c |= (aX > 0, aY > 0) switch
                {
                    (true, true) => 2,
                    (false, true) => 4,
                    (false, false) => 8,
                    (true, false) => 16,
                };

            if (dY != 0)
            {
                float t = -aY / dY;
                double crossX = aX + t * dX;
                if (t > 0 && t < 1)
                {
                    if (crossX > 0) c |= 18;
                    if (crossX < 0) c |= 12;
                }
            }

            if (dX != 0)
            {
                float t = -aX / dX;
                double crossY = aY + t * dY;
                if (t > 0 && t < 1)
                {
                    if (crossY > 0) c |= 6;
                    if (crossY < 0) c |= 24;
                }
            }
            label5.Text = "Отрезок пересикает ";
            if ((c & 2) != 0) label5.Text += "1ч. ";
            if ((c & 4) != 0) label5.Text += "2ч. ";
            if ((c & 8) != 0) label5.Text += "3ч. ";
            if ((c & 16) != 0) label5.Text += "4ч. ";
        }
    }
}
