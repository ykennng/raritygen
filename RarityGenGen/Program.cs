using System;
using System.Collections.Generic;
using RarityGenGen.Common;
using ImageOverlay;
using MetadataGen;
using CommandLine;
using System.IO;

namespace RarityGenGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseFolder = string.Empty;
            int size = 100; //default size
            // TODO: use commandlineparser 
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-f")
                    {
                        baseFolder = args[i + 1];
                    }
                    else if (args[i] == "-s")
                    {
                        size = Int32.Parse(args[i + 1]);
                    }
                }
            }

            if (string.IsNullOrEmpty(baseFolder))
            {
                baseFolder = Directory.GetParent(Environment.CurrentDirectory).FullName;
            }
            if (!baseFolder.EndsWith(@"\"))
            {
                baseFolder += @"\";
            }

            HashSet<string> sets = new HashSet<string>();
            StaticUtils.ReadCsv(baseFolder);

            CombinationGenerator combiGen = new CombinationGenerator(size);

            int imagePosition = 1;
            foreach (var spriteType in Enum.GetValues(typeof(SpriteTypeEnum)))
            {
                var resultSet = combiGen.GenerateCombinations((SpriteTypeEnum)spriteType);
                combiGen.FillInItemSets(resultSet, imagePosition, size, $"{spriteType.ToString()}\\", ".png");
                imagePosition++;
            }

            ImageOverlayClass imageOverlayer = new ImageOverlayClass();
            int counter = 1;
            foreach (var set in combiGen.itemSets)
            {
                var fullset = $"{set.Image1 ?? "None"}-{set.Image2 ?? "None"}-{set.Image3 ?? "None"}-{set.Image4 ?? "None"}-{set.Image5 ?? "None"}-{set.Image6 ?? "None"}";
                if(sets.Add(fullset))
                {
                    Console.WriteLine(fullset);
                    var outputImageName = imageOverlayer.GenerateImages(counter, set.Image1, set.Image2, set.Image3, set.Image4, set.Image5, set.Image6, baseFolder+"Images");
                    combiGen.FillInMetadataModel(set.Image1, set.Image2, set.Image3, set.Image4, set.Image5, set.Image6, outputImageName);
                    counter++;
                }
                else
                {
                    Console.WriteLine(fullset + " is  dupe.");
                }
            }

            StaticUtils.WriteMetadataAttributesToCSV(baseFolder);
        }
    }
}
