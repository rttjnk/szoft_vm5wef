namespace Fibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Class1> Lista = new List<Class1>();
            
            for (int i = 0; i < 10; i++)
            {
                Button n�v = new Button();
                n�v.Text = Fibonacci(i).ToString();
                n�v.Top = i * 20;
                Controls.Add(n�v);
                Class1 �jsor = new Class1();
                �jsor.�rt�k = Fibonacci(i);
                �jsor.Sorsz�m = i;
                Lista.Add(�jsor);
            }

            dataGridView1.DataSource = Lista;
            
        }

        int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);

        }
    }
}