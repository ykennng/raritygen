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
            StaticUtils.ReadCsv2();
            ImageOverlayClass imageOverlayer = new ImageOverlayClass();
            
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
