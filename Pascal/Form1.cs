namespace Pascal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int m = 40;
            
            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop < sor+1; oszlop++)
                {
                    
                    Button gomb = new Button();
                    
                    gomb.Width = m;
                    gomb.Height=m;
                    gomb.Top = sor * m;
                    gomb.Left = oszlop * m;

                    int p = Faktorialis(sor) / (Faktorialis(oszlop) * Faktorialis(sor - oszlop));

                    gomb.Text = p.ToString();
                    
                    Controls.Add(gomb);
                }
            }
        }
        int Faktorialis(int n)
        { 
            int i = 0;
            if (n == 0) return 1;
            return n*Faktorialis(n-1);
        }
    }

}