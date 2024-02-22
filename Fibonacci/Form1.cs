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
                Button név = new Button();
                név.Text = Fibonacci(i).ToString();
                név.Top = i * 20;
                Controls.Add(név);
                Class1 újsor = new Class1();
                újsor.Érték = Fibonacci(i);
                újsor.Sorszám = i;
                Lista.Add(újsor);
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