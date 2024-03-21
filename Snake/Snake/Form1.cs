namespace Snake
{
    public partial class Form1 : Form
    {
        int fej_x = 100;
        int fej_y = 100;
        int irány_x = 1;
        int irány_y = 0;
        int lépésszám = 0;
        int hossz = 3;

        int alma_x;
        int alma_y;
        List<KigyóElem> kígyó = new List<KigyóElem>();
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
           

            lépésszám++;
            
            fej_x += irány_x * KigyóElem.méret;
            fej_y += irány_y * KigyóElem.méret;

            foreach (object item in Controls)
            {
                if (item is KigyóElem)
                {
                    KigyóElem k = (KigyóElem)item;

                    if (k.Top == fej_y && k.Left == fej_x)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            KigyóElem ke = new KigyóElem();
            ke.Top = fej_y;
            ke.Left = fej_x;

            kígyó.Add(ke);
            Controls.Add(ke); 
            
            if(kígyó.Count > hossz)
            {
                KigyóElem levágandó = kígyó[0];
                kígyó.RemoveAt(0);
                Controls.Remove(levágandó);
            }
            if (lépésszám % 2 ==0)
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

            if (lépésszám % 5 == 0)
            {
                alma_x = rnd.Next(1, ClientRectangle.Width / KigyóElem.méret) * KigyóElem.méret;
                alma_y = rnd.Next(1, ClientRectangle.Height / KigyóElem.méret) * KigyóElem.méret;

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
                irány_x = 0;
                irány_y = -1;
            }
            if (e.KeyCode == Keys.Down)
            {
                irány_x = 0;
                irány_y = 1;
            }
            if (e.KeyCode == Keys.Left)
            {
                irány_x = -1;
                irány_y = 0;
            }
            if(e.KeyCode == Keys.Right)
            {
                irány_x = 1;
                irány_y = 0;
            }


        }

        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{

        //}
    }
}