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

            Console.ReadLine();
        }
    }
}
