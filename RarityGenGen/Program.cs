using System;
using System.Collections.Generic;
using RarityGenGen.Common;
using ImageOverlay;
using System.IO;

namespace RarityGenGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseFolder = string.Empty;
            int size = 100; //default size

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
            var hairResultSet = combiGen.GenerateCombinations(SpriteTypeEnum.Hair);
            var eyesResultSet = combiGen.GenerateCombinations(SpriteTypeEnum.Eyes);
            var clothesResultSet = combiGen.GenerateCombinations(SpriteTypeEnum.Clothes);

            combiGen.FillInItemSets(hairResultSet, 1, size, @"Hair\", ".png");
            combiGen.FillInItemSets(eyesResultSet, 2, size, @"Eyes\", ".png");
            combiGen.FillInItemSets(clothesResultSet, 3, size, @"Clothes\", ".png");

            ImageOverlayClass imageOverlayer = new ImageOverlayClass();
            int counter = 1;
            foreach (var set in combiGen.itemSets)
            {
                var fullset = $"{set.Image1}-{set.Image2}-{set.Image3}";
                if(sets.Add(fullset))
                {
                    Console.WriteLine(fullset);
                    imageOverlayer.GenerateImages(set.Image1, set.Image2, set.Image3, counter, baseFolder+"Images");
                    counter++;
                }
                else
                {
                    Console.WriteLine(fullset + " is  dupe.");
                }
            }
            
            // old stuff - Konbini
            //StaticUtils.ReadCsv();
            //StaticUtils.WriteItemListsToCSV();
            //StaticUtils.ReadItemDefinitionCsv();

            //Console.WriteLine("Enter Sample size: ");
            //string sampleSizeInput = Console.ReadLine();
            //try
            //{
            //    var sampleSize = Convert.ToInt32(sampleSizeInput);

            //    var rarityGenGen = new RarityGenerator(Globals.ItemDefinitions);
            //    rarityGenGen.CheckProbabilityAgainstSampleSize(sampleSize);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Enter a proper number baka!");
            //    throw ex;
            //}

            //Console.WriteLine("Hello World!");
        }
    }
}
