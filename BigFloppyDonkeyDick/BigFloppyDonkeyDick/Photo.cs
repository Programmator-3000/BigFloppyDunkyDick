using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
	public class Photo
	{
		public int Id { get; set; }
		public PhotoOrientation Orientation { get; set; } 
		public IEnumerable<string> Tags { get; set; }
	}
}
