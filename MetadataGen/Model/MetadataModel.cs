using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace MetadataGen.Model
{
    public class MetadataModel
    {
        public string Name { get; set; }
        public string Background_Name {get;set;}
        public string Skin_Name { get; set; }
        public string Head_Name { get; set; }
        public string Body_Name { get; set; }
        public string Equipment_Name { get; set; }
        public string ImageLocation { get; set; }

        public string ImageBase64 { get; set; }

        public MetadataNftMakerModel NFTMakerMetadata { get; set; }

    }
}
