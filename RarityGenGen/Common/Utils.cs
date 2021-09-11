using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace RarityGenGen.Common
{
    public static class Utils
    {
        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static void ReadCsv()
        {
            //string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            var csvReaderConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                IgnoreBlankLines = false
            };

            using (var reader = new StreamReader(Path.Combine(projectDirectory, "Csv", "Attributes.csv")))
            using (var csv = new CsvReader(reader, csvReaderConfig))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {

                    var background = csv.GetField<string>("Background");
                    if (!string.IsNullOrEmpty(background))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(background, ItemTypeEnum.Background));
                        if (!Globals.Backgrounds.Add(background))
                        {
                            Console.WriteLine($"Duplicate background detected {background}");
                        }
                    }

                    var bag = csv.GetField<string>("Bag Type");
                    if (!string.IsNullOrEmpty(bag))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(bag, ItemTypeEnum.BagType));
                        if (!Globals.Bags.Add(bag))
                        {
                            Console.WriteLine($"Duplicate bag type detected: {bag}");
                        }
                    }

                    var greens = csv.GetField<string>("Greens");
                    if (!string.IsNullOrEmpty(greens))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(greens, ItemTypeEnum.Greens));
                        if (!Globals.Greens.Add(greens))
                        {
                            Console.WriteLine($"Duplicate vege detected: {greens}");
                        }
                    }

                    var proteins = csv.GetField<string>("Proteins");
                    if (!string.IsNullOrEmpty(proteins))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(proteins, ItemTypeEnum.Proteins));
                        if (!Globals.Proteins.Add(proteins))
                        {
                            Console.WriteLine($"Duplicate protein detected: {proteins}");
                        }
                    }

                    var drinks = csv.GetField<string>("Drink");
                    if (!string.IsNullOrEmpty(drinks))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(drinks, ItemTypeEnum.Drink));
                        if (!Globals.Drinks.Add(drinks))
                        {
                            Console.WriteLine($"Duplicate drink detected: {drinks}");
                        }
                    }

                    var snacks = csv.GetField<string>("Snack");
                    if (!string.IsNullOrEmpty(snacks))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(snacks, ItemTypeEnum.Snack));
                        if (!Globals.Snacks.Add(snacks))
                        {
                            Console.WriteLine($"Duplicate snack detected {snacks}");
                        }
                    }

                    var fruits = csv.GetField<string>("Fruits");
                    if (!string.IsNullOrEmpty(fruits))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(fruits, ItemTypeEnum.Fruits));
                        if (!Globals.Fruits.Add(fruits))
                        {
                            Console.WriteLine($"Duplicate fruit detected {fruits}");
                        }
                    }

                    var carbs = csv.GetField<string>("Carbs");
                    if (!string.IsNullOrEmpty(carbs))
                    {
                        Globals.ItemDefinitions.Add(new ItemDefinitionModel(carbs, ItemTypeEnum.Carbs));
                        if (!Globals.Carbs.Add(carbs))
                        {
                            Console.WriteLine($"Duplicate carb detected {carbs}");
                        }
                    }
                }
            }
        }

        public static void WriteItemListsToCSV()
        {
            using (var writer = new StreamWriter(Path.Combine(projectDirectory, "Csv", "ItemDefintions.csv")))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                 csv.WriteRecords(Globals.ItemDefinitions);
            }
        }
    }
}


