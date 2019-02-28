using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int f = 10;
            var t = (a - f).Clamp(-1,1);

	        string path = "a_example.txt";
	        string outputPath = "a_example_output.txt";

			var reader = new InputFileReader();
	        var result = reader.ReadFile(path);

            List<Slide> slides = new List<Slide>();

            int maxTegsCountInHorizontalPhotos = result.Where(s => s.Orientation == PhotoOrientation.Horizontal)
                .Max(s => s.Tags.Count());

            var verticalPhotos = result.Where(s => s.Orientation == PhotoOrientation.Vertical)
                .OrderByDescending(p => p.Tags.Count())
                .ToList();

            var exitNumber = Math.Round(maxTegsCountInHorizontalPhotos * 1.5d);

            for (int i = 0; i < verticalPhotos.Count(); i++)
            {
                for (int j = i+1; j < verticalPhotos.Count(); j++)
                {
	                var slide = verticalPhotos[i].Union(verticalPhotos[j]);
	                int tagsCount = slide.Tags.Count();

					if (tagsCount <= exitNumber)
	                {
						var acceptNumber = (verticalPhotos[i].Tags.Count() + verticalPhotos[j].Tags.Count()) * 1.5d / 2.0d;
						if (tagsCount > acceptNumber)
						{
							slides.Add(slide);
							verticalPhotos.Remove(verticalPhotos[j]);
							verticalPhotos.Remove(verticalPhotos[i]);
							i--;
							break;
						}
	                }
					
                }
            }

            var horizontalSlides = result.Where(p => p.Orientation == PhotoOrientation.Horizontal)
	            .Select(p => new Slide(new Photo[] {p}));

			slides.AddRange(horizontalSlides);


			var writer = new OutputFileWriter();
			writer.WriteOutput(slides, outputPath);

            Console.ReadLine();
        }

        public static void PerformSearch(List<Slide> slides)
        {
            slides.Sort((x, y) => (x.Tags.Count()-y.Tags.Count()).Clamp(-1,1));
        }
    }
}
