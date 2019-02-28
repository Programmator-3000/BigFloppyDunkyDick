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
	        string path = "a_example.txt";

			var reader = new InputFileReader();
	        var result = reader.ReadFile(path);

            List<Slide> Slides = new List<Slide>();

            foreach (Photo photo in result)
            {
                if (photo.Orientation == PhotoOrientation.Horizontal)
                {
                    List<Photo>  photosforSlide = new List<Photo>();
                    photosforSlide.Add(photo);
                    Slides.Add(new Slide(photosforSlide));
                }
            }

            Console.ReadLine();
        }
    }
}
