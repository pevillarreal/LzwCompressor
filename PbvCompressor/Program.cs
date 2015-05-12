using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PbvCompressor
{
    public class PbvCompressor
    {
        private ICompressorAlgorithm _compressorAlgorithm;

        public ICompressorAlgorithm CompressorAlgorithm
        {
            // allows us to set the algorithm at runtime, also lets us set the algorithm dynamically if we creata  factory class
            set
            {
                _compressorAlgorithm = value;
            }
        }

        public PbvCompressor()
        {
            // setting this by default but we could create a facotry class to let us set the algorithm based on arguments passed to the main method
            // IE. "Compress.exe zip -c blah.txt" would use the zip algorithm as opposed to the default one.
            CompressorAlgorithm = new PbvCompressorLZW();
        }

        private void Start(string argument, string pInFile, string pOutFile)
        {
            string newOutFile = FileNameSelector.GetFileName(pOutFile);

            if (newOutFile == null)
            {
                Console.WriteLine("Exiting...");
                System.Environment.Exit(1);
            }

            if (argument.Equals("-c"))
                _compressorAlgorithm.Compress(pInFile, pOutFile);
            else if (argument.Equals("-d"))
            {
                _compressorAlgorithm.Decompress(pInFile, pOutFile);
            }

            return;
        }

        static void Main(string[] args)
        {
            Regex validCommands = new Regex("-[cdCD]");
            PbvCompressor pc = null;

            if (args.Length != 3)
            {
                Console.WriteLine("Too many or too few arguments! Exiting.");
                return;
            }
            else if (validCommands.IsMatch(args[0])) //if valid argments given proceed
            {
                pc = new PbvCompressor();
                pc.Start(args[0].ToLower(), args[1], args[2]);
            }
            else
                Console.WriteLine("Invalid argument command given. Exiting.");

            return;
        }
    }
}