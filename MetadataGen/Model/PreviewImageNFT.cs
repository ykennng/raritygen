using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataGen.Model
{
    public class PreviewImageNFT
    {
        [JsonProperty("mimetype", Required = Required.Always)]
        public string MimeType { get; set; }

        // choose one image source location only
        [JsonProperty("FileFromBase64", Required = Required.AllowNull)]
        public string FileFromBase64 { get; set; }

        [JsonProperty("FileFromsUrl", Required = Required.AllowNull)]
        public string fileFromsUrl { get; set; }

        [JsonProperty("FileFromIPFS", Required = Required.AllowNull)]
        public string fileFromIPFS { get; set; }

        [JsonProperty("metadataPlaceholder", Required = Required.AllowNull)]
        public List<MetadataPlaceholderModel> MetadataPlaceholders { get; set; }
    }
}
