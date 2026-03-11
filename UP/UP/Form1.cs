namespace UP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
    {
            try
            {
                double.Parse(textBox2.Text);
                if (double.Parse(textBox1.Text) > 0 && double.Parse(textBox1.Text) < 1)
                    button1.Enabled = true;

                else button1.Enabled = false;
            }
            catch
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            if (e.KeyChar == (char)Keys.Back && textBox2.Text != "")
                return;

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.KeyChar = '.';
                try
                {
                    double.Parse($"{textBox2.Text}{e.KeyChar}");
                    return;
                }
                catch { }
            }

            e.KeyChar = '\0';
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            if (e.KeyChar == (char)Keys.Back && textBox2.Text != "")
                return;

            if(e.KeyChar == '-' && textBox2.Text == "") 
                return;

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.KeyChar = '.';
                try
                {
                    double.Parse($"{textBox2.Text}{e.KeyChar}");
                    return;
                }
                catch { }
            }

            e.KeyChar = '\0';
        }
    }
}
