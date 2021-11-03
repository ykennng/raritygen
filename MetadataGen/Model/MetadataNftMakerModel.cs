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
        public PreviewImageNFT PreviewImageNftModel { get; set; }

        //completely optional but accepted in api
        [JsonProperty("description", Required = Required.AllowNull)]
        public string Description { get; set; }

        //completely optional but accepted in api
        [JsonProperty("displayname", Required = Required.AllowNull)]
        public string displayName { get; set; }
    }

    public class MetadataPlaceholderModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
