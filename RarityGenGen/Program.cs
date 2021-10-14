using System;
using System.Collections.Generic;
using RarityGenGen.Common;
using ImageOverlay;

namespace RarityGenGen
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> sets = new HashSet<string>();
            StaticUtils.ReadCsv2();

            var testfolder = @"C:\Users\Rig Mk-II SSD\source\repos\raritygen\RarityGenGen\Images\";

            CombinationGenerator combiGen = new CombinationGenerator(100);
            var hairResultSet = combiGen.GenerateCombinations(SpriteTypeEnum.Hair);
            var eyesResultSet = combiGen.GenerateCombinations(SpriteTypeEnum.Eyes);
            var clothesResultSet = combiGen.GenerateCombinations(SpriteTypeEnum.Clothes);
            combiGen.FillInItemSets(hairResultSet, 1, 100, @"Hair\", ".png");
            combiGen.FillInItemSets(eyesResultSet, 2, 100, @"Eyes\", ".png");
            combiGen.FillInItemSets(clothesResultSet, 3, 100, @"Clothes\", ".png");

            ImageOverlayClass imageOverlayer = new ImageOverlayClass();
            int counter = 1;
            foreach (var set in combiGen.itemSets)
            {
                var fullset = $"{set.Image1}-{set.Image2}-{set.Image3}";
                if(sets.Add(fullset))
                {
                    Console.WriteLine(fullset);
                    imageOverlayer.GenerateImages(set.Image1, set.Image2, set.Image3, counter, testfolder);
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

            Console.WriteLine("Enter Sample size: ");
            string sampleSizeInput = Console.ReadLine();
            try
            {
                var sampleSize = Convert.ToInt32(sampleSizeInput);

                var rarityGenGen = new RarityGenerator(Globals.ItemDefinitions);
                rarityGenGen.CheckProbabilityAgainstSampleSize(sampleSize);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Enter a proper number baka!");
                throw ex;
            }

            Console.WriteLine("Hello World!");
        }
    }
}
