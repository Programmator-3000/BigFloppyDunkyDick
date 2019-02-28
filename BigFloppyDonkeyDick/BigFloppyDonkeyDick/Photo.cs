using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
	public class Photo
	{
		public PhotoOrientation Orientation { get; set; } 
		public IEnumerable<string> Tags { get; set; }
	}
}
