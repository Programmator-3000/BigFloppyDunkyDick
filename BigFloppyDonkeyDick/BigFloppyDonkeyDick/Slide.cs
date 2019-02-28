using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
    public class Slide
    {
        IEnumerable<Photo> Photos { get; set; }

        public Slide(IEnumerable<Photo> ph)
        {
            Photos = ph;
        }

        public IEnumerable<string> Tags => Photos.SelectMany(x => x.Tags);

        //Should be minimal
        public int Union(Slide other)
        {
            return Tags.Union(other.Tags).Count();
        }

        public int Intersect(Slide other)
        {
            return Tags.Intersect(other.Tags).Count();
        }

        public int Except(Slide other)
        {
            return Tags.Except(other.Tags).Count();
        }

        public int Quality(Slide other)
        {
            return Math.Min(Intersect(other), Except(other));
        }
    }
}
