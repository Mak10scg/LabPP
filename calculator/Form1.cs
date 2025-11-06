using System.Drawing.Text;
using System.Linq.Expressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double a = 0;
        private double b = 0;
        private string action = "";
        private void btn_num_click(object sender, EventArgs e)
        {
            try { textBox1.Text += ((Button)sender).Text; }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void btn_action_click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text); // Запоминаем число
                action = ((Button)sender).Text; // Запоминаем знак
                textBox1.Clear();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void btn_result_click(object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToDouble(textBox1.Text); // Запоминаем второе число
                switch (action)
                {
                    case "+":
                        textBox1.Text = (a + b).ToString();
                        break;
                    case "-":
                        textBox1.Text = (a - b).ToString();
                        break;
                    case "/":
                        if (b != 0)
                            textBox1.Text = (a / b).ToString();
                        else MessageBox.Show("Ошибка!");
                        break;
                    case "x":
                        textBox1.Text = (a * b).ToString();
                        break;
                    case "x√":
                        if (a < 0 || b < 0)
                            MessageBox.Show("Ошибка!");
                        else textBox1.Text = Math.Pow(Math.Abs(a), 1 / b).ToString();
                        break;
                    case "^x":
                        textBox1.Text = Math.Pow(a, b).ToString();
                        break;
                    case "logx":
                        textBox1.Text = Math.Log(a, b).ToString();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }



        private void btn_text_delall(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btn_dot_click(object sender, EventArgs e)
        {
            bool DotStr = textBox1.Text.Contains(",");
            if (DotStr)
                MessageBox.Show("Число уже дробное");
            else textBox1.Text += ((Button)sender).Text;
        }

        private void btn_del_last(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            else textBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
