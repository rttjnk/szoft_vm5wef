using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class KigyóElem :PictureBox
    {
        public static int méret = 20;
        
        public KigyóElem()
        {
            Height = méret;
            Width = méret;
            BackColor = Color.Fuchsia;
            
        }

    }
}
