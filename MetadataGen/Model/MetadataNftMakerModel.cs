using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace MetadataGen.Model
{
    public class MetadataNftMakerModel
    {
        [JsonProperty("assetName", Required = Required.Always)]
        public string AssetName { get; set; }

        [JsonProperty("previewImageNft", Required = Required.Always)]
        public string PreviewImageNft { get; set; }

        // choose one image source location only
        [JsonProperty("FileFromBase64", Required = Required.AllowNull)]
        public string FileFromBase64 { get; set; }

        [JsonProperty("FileFromsUrl", Required = Required.AllowNull)]
        public string fileFromsUrl { get; set; }

        [JsonProperty("FileFromIPFS", Required = Required.AllowNull)]
        public string fileFromIPFS { get; set; }

        //completely optional but accepted in api
        [JsonProperty("description", Required = Required.AllowNull)]
        public string Description { get; set; }

        //completely optional but accepted in api
        [JsonProperty("displayname", Required = Required.AllowNull)]
        public string displayName { get; set; }

        //Use either metadata OR metadataPlaceholders, not both, metadata has priority
        [JsonProperty("metadata", Required = Required.AllowNull)]
        public MetadataModel Metadata { get; set; }

        [JsonProperty("metadataPlaceholder", Required = Required.AllowNull)]
        public List<MetadataPlaceholderModel> MetadataPlaceholders { get; set; }
    }

    public class MetadataPlaceholderModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
