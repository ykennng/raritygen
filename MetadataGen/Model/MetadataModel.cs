using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace MetadataGen.Model
{
    class MetadataModel
    {
        //[EmailAddress]
        [JsonProperty("email", Required = Required.Always)]
        public string Email;
    }
}
