using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace RarityGenGen.Common
{
    public static class StaticUtils
    {
        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
        static CsvConfiguration csvReaderConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                IgnoreBlankLines = false
            };


        public static void ReadCsv(string csvDirectory = null)
        {
            var directory = csvDirectory ?? projectDirectory;
            foreach (var spriteType in Enum.GetNames(typeof(SpriteTypeEnum)))
            {
                var csvName = $"Sprite Attributes - {spriteType}.csv";
                var enumName = (SpriteTypeEnum)Enum.Parse(typeof(SpriteTypeEnum), spriteType, true);
                try
                {
                    using (var reader = new StreamReader(Path.Combine(directory, "Csv", csvName)))
                    using (var csv = new CsvReader(reader, csvReaderConfig))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var itemName = csv.GetField<string>("Name");
                            var filename = csv.GetField<string>("Filename");
                            var qty = csv.GetField<int?>("Qty");
                            //if (qty == null)
                            //{
                            //    qty = 0;
                            //}
                            var dropRate = csv.GetField<double?>("Drop");
                            if (dropRate == null)
                            {
                                dropRate = 0;
                            }

                            if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(filename))
                            {
                                Globals.SpriteDefinitions.Add(new SpriteModel(itemName, filename, qty, (double)dropRate, enumName));
                            }
                            else
                            {
                                Console.WriteLine($"Unknown entry: {itemName ?? "?"}-{ filename ?? "?"}-{ qty }-{ dropRate }");
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ csvName } not found.");
                }
            }
        }

        public static void WriteMetadataAttributesToCSV(string csvDirectory = null)
        {
            var directory = csvDirectory ?? projectDirectory;

            using (var writer = new StreamWriter(Path.Combine(directory, "Csv", "MetadataAttributes.csv")))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Globals.ItemMetadataList);
            }
        }
    }
}


