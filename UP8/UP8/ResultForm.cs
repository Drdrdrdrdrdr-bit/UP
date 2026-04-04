using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UP8
{
    public partial class ResultForm : Form
    {
        public int GuessR { get; private set; }
        public int GuessG { get; private set; }

        public ResultForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GuessR = (int)nudR.Value;
            GuessG = (int)nudG.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
