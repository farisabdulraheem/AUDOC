using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrReader
{
    class cordinatemodal
    {

        public int x, y, w, h;





        public cordinatemodal(int cordx, int cordy, int cordw, int cordh)
        {
            this.x = cordx;
            this.y = cordy;
            this.w = cordw;
            this.h = cordh;
        }
    }
}