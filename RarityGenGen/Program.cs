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

            Parser.Default.ParseArguments<Options>(args)
               .WithParsed<Options>(o =>
               {
                   if (!string.IsNullOrEmpty(o.BaseFolder))
                   {
                       baseFolder = o.BaseFolder;
                   }

                   if (o.size != null)
                   {
                       size = (int)o.size;
                   }
               });

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
                var resultSet = combiGen.GenerateCombinations((SpriteTypeEnum)spriteType, size);
                combiGen.FillInItemSets(resultSet, imagePosition, size, $"{spriteType.ToString()}\\", ".png");
                imagePosition++;
            }

            ImageOverlayClass imageOverlayer = new ImageOverlayClass();
            int counter = 1;
            foreach (var set in combiGen.itemSets)
            {
                var fullset = $"{set.Image1 ?? "None"}-{set.Image2 ?? "None"}-{set.Image3 ?? "None"}-{set.Image4 ?? "None"}-{set.Image5 ?? "None"}";
                if(sets.Add(fullset))
                {
                    Console.WriteLine(fullset);
                    var outputImageName = imageOverlayer.GenerateImages(counter, set.Image1, set.Image2, set.Image3, set.Image4, set.Image5, null, baseFolder+"Images");
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

    class Options
    {
        [Option('f', "folder", Required = false, HelpText = "folder to look for images, csv.")]
        public string BaseFolder { get; set; }

        [Option('s', "size", Default = 100, Required = false, HelpText = "Default size of randomized items to generate, default is 100.")]
        public int? size { get; set; }

        //[Option('p', "projectName", Default = 100, Required = false, HelpText = "Default size of randomize items to generate, default is 100.")]
        //public int size { get; set; }

        //// Omitting long name, defaults to name of property, ie "--verbose"
        //[Option(
        //  Default = false,
        //  HelpText = "Prints all messages to standard output.")]
        //public bool Verbose { get; set; }

        //[Option("stdin",
        //  Default = false,
        //  HelpText = "Read from stdin")]
        //public bool stdin { get; set; }

        //[Value(0, MetaName = "offset", HelpText = "File offset.")]
        //public long? Offset { get; set; }
    }
}
