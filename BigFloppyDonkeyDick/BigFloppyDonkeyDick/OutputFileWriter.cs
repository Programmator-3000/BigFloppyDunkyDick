using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
	public class OutputFileWriter
	{
		public void WriteOutput(IEnumerable<Slide> slides, string outputPath)
		{
			using (var writer = new StreamWriter(outputPath))
			{
				writer.WriteLine(slides.Count());

				foreach (var slide in slides)
				{
					var photoIds = slide.Photos.Select(p => p.Id);
					string output = String.Join(" ", photoIds);
					writer.WriteLine(output);
				}
			}
		}
	}
}
