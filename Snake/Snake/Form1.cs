namespace Snake
{
    public partial class Form1 : Form
    {
        int fej_x = 100;
        int fej_y = 100;
        int ir�ny_x = 1;
        int ir�ny_y = 0;
        int l�p�ssz�m = 0;
        int hossz = 3;

        int alma_x;
        int alma_y;
        List<Kigy�Elem> k�gy� = new List<Kigy�Elem>();
        Random rnd = new Random();
        Alma alma = new Alma();



        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           

            l�p�ssz�m++;
            
            fej_x += ir�ny_x * Kigy�Elem.m�ret;
            fej_y += ir�ny_y * Kigy�Elem.m�ret;

            foreach (object item in Controls)
            {
                if (item is Kigy�Elem)
                {
                    Kigy�Elem k = (Kigy�Elem)item;

                    if (k.Top == fej_y && k.Left == fej_x)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            Kigy�Elem ke = new Kigy�Elem();
            ke.Top = fej_y;
            ke.Left = fej_x;

            k�gy�.Add(ke);
            Controls.Add(ke); 
            
            if(k�gy�.Count > hossz)
            {
                Kigy�Elem lev�gand� = k�gy�[0];
                k�gy�.RemoveAt(0);
                Controls.Remove(lev�gand�);
            }
            if (l�p�ssz�m % 2 ==0)
            {
                ke.BackColor = Color.Yellow;
            }

            foreach (object item in Controls)
            {
                if (item is Alma)
                {
                    Alma a = (Alma)item;

                    if (a.Top == fej_y && a.Left == fej_x)
                    {
                        hossz++;
                        Controls.Remove(a);
                    }
                }
            }

;

            if (l�p�ssz�m % 5 == 0)
            {
                alma_x = rnd.Next(1, ClientRectangle.Width / Kigy�Elem.m�ret) * Kigy�Elem.m�ret;
                alma_y = rnd.Next(1, ClientRectangle.Height / Kigy�Elem.m�ret) * Kigy�Elem.m�ret;

                Alma alma= new Alma();
                alma.Top = alma_y;
                alma.Left = alma_x;
                Controls.Add(alma);
            }


        }

        private void Form1_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) 
            {
                ir�ny_x = 0;
                ir�ny_y = -1;
            }
            if (e.KeyCode == Keys.Down)
            {
                ir�ny_x = 0;
                ir�ny_y = 1;
            }
            if (e.KeyCode == Keys.Left)
            {
                ir�ny_x = -1;
                ir�ny_y = 0;
            }
            if(e.KeyCode == Keys.Right)
            {
                ir�ny_x = 1;
                ir�ny_y = 0;
            }


        }

        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{

        //}
    }
}