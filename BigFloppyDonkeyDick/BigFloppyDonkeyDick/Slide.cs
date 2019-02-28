using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
    class Slide
    {
        IEnumerable<Photo> Photos { get; set; }

        public Slide(IEnumerable<Photo> ph)
        {
            Photos = ph;
        }
    }
}
