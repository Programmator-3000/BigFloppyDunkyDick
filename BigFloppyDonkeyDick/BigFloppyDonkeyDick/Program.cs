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
                for (int j = i; j < verticalPhotos.Count(); j++)
                {
	                var slide = verticalPhotos[i].Union(verticalPhotos[j]);
					
                }
            }


            foreach (Photo photo in result)
            {
                if (photo.Orientation == PhotoOrientation.Horizontal)
                {
                    List<Photo>  photosforSlide = new List<Photo>();
                    photosforSlide.Add(photo);
                    slides.Add(new Slide(photosforSlide));
                }

            }


			var writer = new OutputFileWriter();
			writer.WriteOutput(Slides, outputPath);

            Console.ReadLine();
        }

        public static void PerformSearch(List<Slide> slides)
        {
            slides.Sort((x, y) => (x.Tags.Count()-y.Tags.Count()).Clamp(-1,1));
        }
    }
}
