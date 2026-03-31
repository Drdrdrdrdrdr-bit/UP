using System.Text.RegularExpressions;
using UP5Lib;
namespace UP5
{
    public partial class Form1 : Form, IWork
    {
        //private Regex _digits;
        public Form1()
        {
            InitializeComponent();
        }
        string PatchLoad { get; }
        string PatchSave { get; }

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

        private void задачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            лавинштейнToolStripMenuItem.Checked = false;
            button1.Visible = false;
            button6.Visible = true;
        }

        private void лавинштейнToolStripMenuItem_Click(object sender, EventArgs e)
        {
            задачаToolStripMenuItem.Checked = false;
            button6.Visible = false;
            button1.Visible = true;
        }

        private void Label2_TextChanged(object sender, EventArgs e)
        {
            if (label2.Text == "" && label4.Text == "")
            {
                //menuStrip1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                //menuStrip1.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; // фильтр расширений
                //openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label4.Text = openFileDialog.FileName;

                    // updateText(File.ReadAllText(filePath));
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; // фильтр расширений
                //openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label2.Text = openFileDialog.FileName;

                    // updateText(File.ReadAllText(filePath));
                }
            }
        }

        private void PrintMassage(string text)
        {
            label5.Text = text;
        }
    }
}
