using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using MetadataGen.Common;
using MetadataGen.Model;
using System.IO;
using System.Drawing;

namespace MetadataGen
{
    public class MetadataGenerator
    {
        public void Generate()
        {
            string[] metadataKeys = { ConstantsMetadata.Background, ConstantsMetadata.Skin, ConstantsMetadata.Head, ConstantsMetadata.Body, ConstantsMetadata.Equipment, ConstantsMetadata.Nft_Name, ConstantsMetadata.Website_url, ConstantsMetadata.CopyrightText };
            var metas = StaticUtilsMetadata.MetadataModels;
            
            foreach (var meta in metas)
            {
                foreach(var key in metadataKeys)
                {
                    try
                    {
                        Console.WriteLine($"Generating metadata placeholders for : {meta.ImageLocation} - {key}");
                        var value = StaticUtilsMetadata.GetPropValue(meta, key);
                        if (value != null)
                        {
                            meta.NFTMakerMetadata.MetadataPlaceholders.Add(new MetadataPlaceholderModel() { Name = key, Value = value.ToString() });
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}: key: {key}");
                        continue;
                    }
                }
            }
        }

        

        public MetadataPlaceholderModel CreateMetadataPlaceholder(string key, string value)
        {
            return new MetadataPlaceholderModel() { Name = key, Value = value };
        }

        public string ConvertImageToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    //image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
