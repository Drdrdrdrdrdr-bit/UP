using System.Text.RegularExpressions;

namespace UP5
{
    public partial class Form1 : Form
    {
        //private Regex _digits;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var matches = _digits.Matches(textBox1.Text);
            //textBox2.Text = string.Join(", ", matches.Select(m => m.Value));
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if (e.KeyChar == ' ' || e.KeyChar <= '\n' || e.KeyChar <= '\t' || (e.KeyChar >= '0' && e.KeyChar <= '9'))
                e.KeyChar = '\0';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "") // !!!!
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            //_digits = new Regex(@"\b\w*[{textBox3.Text}]\w*\b", RegexOptions.Compiled);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "") menuStrip1.Enabled = false;
            else menuStrip1.Enabled = true;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
