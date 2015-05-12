using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace PbvCompressor
{
    public class FileNameSelector
    {
        public static string GetFileName(string pFileName)
        {
            string newFileName = pFileName;
            if (File.Exists(pFileName))
            {
                Console.WriteLine(pFileName + " already exists. Overwrite it?");
                string response = PromptUserYNQ().ToLower();
                
                if (response.Equals("n"))
                    newFileName = PromptUserFileName();
                else if (response.Equals("q"))
                    return null;
            }

            return newFileName;
        }

        private static string PromptUserYNQ()
        {
            Regex goodResponse = new Regex("[ynqYNQ]");
            string lineRead;
            bool firstRun = true;

            do
            {
                if (!firstRun)
                {
                    Console.WriteLine("Entered invalid option, try again...");
                }

                Console.WriteLine("[Y]es, [N]o, [Q]uit");
                lineRead = Console.ReadLine();
                firstRun = false;
            } while (!goodResponse.IsMatch(lineRead));

            return lineRead;
        }

        private static string PromptUserFileName()
        {
            Console.WriteLine("Enter filename to use: ");
            return Console.ReadLine();
        }
    }
}
