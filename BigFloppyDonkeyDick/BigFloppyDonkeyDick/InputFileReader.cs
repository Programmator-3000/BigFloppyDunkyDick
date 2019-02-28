using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
	public class InputFileReader {
		public IEnumerable<Photo> ReadFile(string path)
		{
			var result = new List<Photo>();
			using (StreamReader sr = File.OpenText(path))
			{
				int i = 0;
				string s = sr.ReadLine(); //skip number of rows

				while ((s = sr.ReadLine()) != null)
				{
					var split = s.Split(' ');
					var photo = new Photo()
					{
						Id = i,
						Orientation = split[0] == "H" ? PhotoOrientation.Horizontal : PhotoOrientation.Vertical,
						Tags = split.Skip(2).ToList()
					};

					result.Add(photo);
					i++;
				}
			}

			return result;
		}
	}
}
