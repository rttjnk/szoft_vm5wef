using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillogoGomb
{
    internal class Szamologomb:Button
    {
        int szám;
        
        public Szamologomb()
        {
            Height = 20;
            Width = 20;
            szám = 0;
            MouseClick += Szamologomb_MouseClick;
            
        }

        private void Szamologomb_MouseClick(object? sender, MouseEventArgs e)
        {
            szám++;
            Text = szám.ToString();
            if (szám == 5)
            {
                szám = 0;
            }
        }
    }
}
