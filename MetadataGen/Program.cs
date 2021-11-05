using System;
using System.Collections.Generic;
using MetadataGen.Common;
using MetadataGen.Model;
using MetadataGen;
using CommandLine;
using System.IO;

namespace MetadataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string imageFolder = string.Empty;
            bool toUpload = false;
            string projectId = string.Empty;
            string projectName = string.Empty;
            string apiKey = string.Empty;

            Parser.Default.ParseArguments<Options>(args)
               .WithParsed<Options>(o =>
               {
                   if (!string.IsNullOrEmpty(o.BaseFolder))
                   {
                       imageFolder = o.BaseFolder;
                   }

                   toUpload = o.ToUpload;

                   if (!string.IsNullOrEmpty(o.ApiKey))
                   {
                       apiKey = o.ApiKey;
                   }

                   if (!string.IsNullOrEmpty(o.ProjectId))
                   {
                       projectId = o.ProjectId;
                   }

                   if (!string.IsNullOrEmpty(o.ProjectName))
                   {
                       projectName = o.ProjectName;
                   }
               });

            if (string.IsNullOrEmpty(imageFolder))
            {
                imageFolder = Directory.GetParent(Environment.CurrentDirectory).FullName;
            }
            if (!imageFolder.EndsWith(@"\"))
            {
                imageFolder += @"\";
            }

            HashSet<string> sets = new HashSet<string>();
            StaticUtilsMetadata.ReadCsv(imageFolder);

            MetadataGenerator metaGen = new MetadataGenerator();
            metaGen.Generate(imageFolder);
            metaGen.GenerateJsonToFileOrUpload(toUpload);
        }

        class Options
        {
            [Option('f', "folder", Required = false, HelpText = "folder to look for generated images")]
            public string BaseFolder { get; set; }

            [Option('u', "upload", Required = false, Default = false, HelpText = "boolean flag on whether to upload or not")]
            public bool ToUpload { get; set; }

            [Option('a', "apikey", Required = false, HelpText = "apikey to upload, include together with projectId  if 'u' is true")]
            public string ApiKey { get; set; }

            [Option('p', "projectId", Required = false, HelpText = "projectId to upload to, include together with apikey if 'u' is true")]
            public string ProjectId { get; set; }

            [Option('n', "projectName", Required = false, HelpText = "project Name for metadata")]
            public string ProjectName { get; set; }
        }
    }
}
