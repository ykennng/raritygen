using System;
using System.Collections.Generic;
using MetadataGen.Common;
using MetadataGen.Model;
using MetadataGen;
//using CommandLine;
using System.IO;

namespace MetadataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string imageFolder = string.Empty;
            int size = 100; //default size
            // TODO: use commandlineparser 
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-f")
                    {
                        imageFolder = args[i + 1];
                    }
                    else if (args[i] == "-s")
                    {
                        size = Int32.Parse(args[i + 1]);
                    }
                }
            }

            if (string.IsNullOrEmpty(imageFolder))
            {
                imageFolder = Directory.GetParent(Environment.CurrentDirectory).FullName;
            }
            if (!imageFolder.EndsWith(@"\"))
            {
                imageFolder += @"\";
            }

            HashSet<string> sets = new HashSet<string>();
            StaticUtils.ReadCsv(imageFolder);

        }
    }
}
