using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using MetadataGen.Common;
using MetadataGen.Model;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MetadataGen
{
    public class MetadataGenerator
    {
        public void Generate(string folder)
        {
            string[] metadataKeys = { ConstantsMetadata.Background, ConstantsMetadata.Skin, ConstantsMetadata.Head, ConstantsMetadata.Body, ConstantsMetadata.Equipment };
            var metas = StaticUtilsMetadata.MetadataModels;
            
            foreach (var meta in metas)
            {
                Console.WriteLine($"Generating metadata placeholders for : {meta.ImageLocation}");
                foreach (var key in metadataKeys)
                {
                    try
                    {
                        //Console.WriteLine($"Generating metadata placeholders for : {meta.ImageLocation} - {key}");
                        var value = StaticUtilsMetadata.GetPropValue(meta, key);
                        if (value != null)
                        {
                            meta.NFTMakerMetadata.PreviewImageNftModel.MetadataPlaceholders.Add(new MetadataPlaceholderModel() { Name = key, Value = value.ToString() });
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}: key: {key}");
                        continue;
                    }
                }

                var base64 = ConvertImageToBase64($"{folder}\\Images\\{meta.ImageLocation}");
                meta.NFTMakerMetadata.AssetName = meta.Name;
                meta.NFTMakerMetadata.PreviewImageNftModel.FileFromBase64 = base64;
                meta.NFTMakerMetadata.PreviewImageNftModel.MimeType = $"image/png";
                meta.NFTMakerMetadata.PreviewImageNftModel.MetadataPlaceholders.Add(new MetadataPlaceholderModel() { Name = ConstantsMetadata.Nft_Name, Value = meta.Name });
                meta.NFTMakerMetadata.PreviewImageNftModel.MetadataPlaceholders.Add(new MetadataPlaceholderModel() { Name = ConstantsMetadata.Website_url, Value = ConstantsMetadata.WebsiteUrlContent });
                meta.NFTMakerMetadata.PreviewImageNftModel.MetadataPlaceholders.Add(new MetadataPlaceholderModel() { Name = ConstantsMetadata.CopyrightText, Value = ConstantsMetadata.CopyrightTextContent });
                meta.NFTMakerMetadata.PreviewImageNftModel.MetadataPlaceholders.Add(new MetadataPlaceholderModel() { Name = ConstantsMetadata.Project_name, Value = "" });
            }
        }

        public async Task<bool> GenerateJsonToFileOrUpload(string apikey, string projectId,  bool toUpload = false)
        {
            List<string> jsonObjects = new List<string>();
            var metas = StaticUtilsMetadata.MetadataModels;
            var client = new HttpClient
            {
                BaseAddress = new Uri($"{ConstantsMetadata.Url}"),
            };

            foreach (var meta in metas)
            {
                var serializedObject = JsonConvert.SerializeObject(meta.NFTMakerMetadata);
                jsonObjects.Add(serializedObject);

                if (toUpload)
                {
                    var buffer = System.Text.Encoding.UTF8.GetBytes(serializedObject);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    try
                    {
                        var response = await client.PostAsync($"{ConstantsMetadata.Upload}/{apikey}/{projectId}", byteContent);
                        if (!response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            throw new Exception($"Upload failed for {meta.ImageLocation}, aborting...");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + ex.StackTrace);
                    }
                }
            }
            return true;
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
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
