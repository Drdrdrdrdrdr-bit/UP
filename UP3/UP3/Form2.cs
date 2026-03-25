using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UP3
{
    public partial class Form2 : Form
    {
        ISettings _param;
        public Form2(ISettings param)
        {
            InitializeComponent();
            _param = param;
            label1.BackColor = _param.colorStart;
            label2.BackColor = _param.colorEnd;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                label1.BackColor = cd.Color;
                _param.colorStart = cd.Color;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                label2.BackColor = cd.Color;
                _param.colorEnd = cd.Color;
            }
        }
    }
}
