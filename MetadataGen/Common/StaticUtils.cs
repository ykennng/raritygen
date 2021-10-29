using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using MetadataGen.Model;

namespace MetadataGen.Common
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

            var csvName = $"{ConstantsMetadata.CsvFile}.csv";

            try
            {
                using (var reader = new StreamReader(Path.Combine(directory, "Csv", csvName)))
                using (var csv = new CsvReader(reader, csvReaderConfig))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var background = csv.GetField<string>(ConstantsMetadata.Background);
                        var skin = csv.GetField<string>(ConstantsMetadata.Skin);
                        var head = csv.GetField<string>(ConstantsMetadata.Head);
                        var body = csv.GetField<string>(ConstantsMetadata.Body);
                        var eq = csv.GetField<string>(ConstantsMetadata.Equipment);

                        Console.WriteLine($"{background ?? "?"}-{ skin ?? "?"}-{ head ?? "?"}-{ body ?? "?"}-{ eq ?? "?"}");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ csvName } not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //public static void WriteMetadataAttributesToCSV(string csvDirectory = null)
        //{
        //    var directory = csvDirectory ?? projectDirectory;

        //    using (var writer = new StreamWriter(Path.Combine(directory, "Csv", "MetadataAttributes.csv")))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        csv.WriteRecords(Globals.ItemMetadataList);
        //    }
        //}
    }
}


