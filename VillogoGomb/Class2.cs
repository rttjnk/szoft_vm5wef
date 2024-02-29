using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillogoGomb
{
    internal class Szinezogomb : Button
    {
        public Szinezogomb()
        {
            Height=20;
            Width=20;
            
            MouseClick += Szinezogomb_MouseClick;
        }

        private void Szinezogomb_MouseClick(object? sender, MouseEventArgs e)
        {
            if (BackColor != Color.Fuchsia)
            {
                BackColor = Color.Fuchsia;
            }
            else { BackColor = SystemColors.ButtonFace; }
        }
    }
}
