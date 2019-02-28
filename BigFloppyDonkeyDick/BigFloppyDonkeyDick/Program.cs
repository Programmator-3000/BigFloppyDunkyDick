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
	        string outputPath = "a_example_output.txt";

			var reader = new InputFileReader();
	        var result = reader.ReadFile(path);


	        var slides = new List<Slide>();

			var writer = new OutputFileWriter();
			writer.WriteOutput(slides, outputPath);

            Console.ReadLine();
        }
    }
}
