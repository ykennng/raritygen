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
    public static class StaticUtilsMetadata
    {
        public static List<MetadataModel> MetadataModels = new List<MetadataModel>();
        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
        static CsvConfiguration csvReaderConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreBlankLines = false
        };

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

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
                        var imgLocation = csv.GetField<string>(ConstantsMetadata.OutputImageLocation);

                        Console.WriteLine($"{background ?? "?"}-{ skin ?? "?"}-{ head ?? "?"}-{ body ?? "?"}-{ eq ?? "?"}");
                        
                        MetadataModels.Add(
                        new MetadataModel()
                        {
                            Name = imgLocation.Replace(".png", string.Empty),
                            Background_Name = background,
                            Skin_Name = skin,
                            Head_Name = head,
                            Body_Name = body,
                            Equipment_Name = eq,
                            ImageLocation = "Output\\" + imgLocation,
                            NFTMakerMetadata = new MetadataNftMakerModel() { MetadataPlaceholders = new List<MetadataPlaceholderModel>()},

                            //AssetName = imgLocation.Replace(".png", string.Empty),
                            //MimeType = "image/" + ImageTypeEnum.PNG.ToString(),
                        });
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


