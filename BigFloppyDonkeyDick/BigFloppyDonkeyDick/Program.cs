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

	        //string path = "a_example.txt";
	        //string outputPath = "a_example_output.txt";

	        //string path = "b_lovely_landscapes.txt";
	        //string outputPath = "b_lovely_landscapes_output.txt";

	        //string path = "c_memorable_moments.txt";
	        //string outputPath = "c_memorable_moments_output.txt";

	        //string path = "d_pet_pictures.txt";
	        //string outputPath = "d_pet_pictures_output.txt";

	        string path = "e_shiny_selfies.txt";
	        string outputPath = "e_shiny_selfies_output.txt";

			var reader = new InputFileReader();
	        var result = reader.ReadFile(path);

            List<Slide> slides = new List<Slide>();

            var horizontalPhotos = result.Where(p => p.Orientation == PhotoOrientation.Horizontal).ToList();

            var verticalPhotos = result.Where(s => s.Orientation == PhotoOrientation.Vertical)
	            .OrderByDescending(p => p.Tags.Count())
	            .ToList();

			int maxTegsCountInHorizontalPhotos = horizontalPhotos.Any() ?
				horizontalPhotos.Max(s => s.Tags.Count())
				: verticalPhotos[0].Tags.Count();

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

            var horizontalSlides = horizontalPhotos
	            .Select(p => new Slide(new Photo[] {p}));

			slides.AddRange(horizontalSlides);


			var writer = new OutputFileWriter();
			writer.WriteOutput(slides, outputPath);
        }

        public static void PerformSearch(List<Slide> slides)
        {
            slides.Sort((x, y) => (x.Tags.Count()-y.Tags.Count()).Clamp(-1,1));
        }
    }
}
