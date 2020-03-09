using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsImageEditor_VagundaFidler
{
    class VColor
    {
        public VColor(Int32 R, Int32 G, Int32 B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
        public Int32 R { get; set; }
        public Int32 G { get; set; }
        public Int32 B { get; set; }
    }
}
