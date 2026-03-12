namespace UP
{
    public partial class Form1 : Form
    {
        private double arcsin_iterator(double x, double acc)
        {
            // int iter = 1;
            // double res1, res2 = 0;
            // double factor = 0; // 3 * 5 * 7 * 9 * ...
            // long dividend1 = 1;
            // long dividend2 = 1;
            // long dividend3;
            // long divisor = 1;//:(

            double s = x;
            double step = x; 
            int n = 1;

	    do
            {
                double multiplier = (Math.Pow(2 * n - 1, 2) * x * x) / ((2 * n) * (2 * n + 1)); 
                step *= multiplier;

                s += step;

                n++;

            }while (Math.Abs(step) < acc && n > 1000);
            return s;


		// Плохой и не эффективный вариант
            //do
            //{
            //    res1 = res2;

            //    dividend1 *= (2 * iter - 1); // числитель произведение перед
            //    divisor *= (2 * iter); // перед предпоследних произведение знаменатель (новый)
            //    dividend3 = (2 * iter + 1);  // перед последний знаменатель (новый) + степень

            //    factor += Math.Pow(x, dividend3) * (double)dividend1 * (double)dividend1; // Сумма x не делённых

            //    res2 = (factor / (double)divisor / (double)dividend3 / (double)dividend1); // деление на все предпоследние и гридущий

            //    iter++;

            //    factor *= (double)((2 * iter) * (double)(2 * iter + 1)); // подготовка x ов

            //} while (Math.Abs(res1 - res2) > acc);
            //return x + res2;
        }
        public Form1()
        {
            InitializeComponent();
            label4.Text = arcsin_iterator(0.5, 1e-17).ToString();
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
