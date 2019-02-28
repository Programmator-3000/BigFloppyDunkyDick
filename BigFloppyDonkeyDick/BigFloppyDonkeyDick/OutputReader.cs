using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
	public class OutputReader
	{
		public IEnumerable<Slide> Read(IEnumerable<Photo> originalPhotos, string outputPath)
		{
			string[] readText = File.ReadAllLines(outputPath);
			string firstLine = readText[0];

			Random rnd = new Random();
			var newResult = readText.Skip(1);
				//.OrderBy(x => rnd.Next())

			return newResult.Select(r => new Slide(r.Split(' ').Select(
					p => originalPhotos.Single(op => op.Id == int.Parse(p))))).ToList();

			/*using (var writer = new StreamWriter(path+"1"))
			{
				writer.WriteLine(firstLine);

				foreach (var result in newResult)
				{
					writer.WriteLine(result);
				}
			}*/
		}
	}
}
