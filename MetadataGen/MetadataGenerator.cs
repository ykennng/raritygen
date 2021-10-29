using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using MetadataGen.Model;

namespace MetadataGen
{
    public class MetadataGenerator
    {
        public void Generate(string policyId)
        {
            JObject tetst = new JObject();

            JSchemaGenerator generator = new JSchemaGenerator();
            //JSchema schema = generator.Generate(typeof(Account));
        // {
        //   "type": "object",
        //   "properties": {
        //     "email": { "type": "string", "format": "email" }
        //   },
        //   "required": [ "email" ]
        // }

        //public class Account
        //{
        //    [EmailAddress]
        //    [JsonProperty("email", Required = Required.Always)]
        //    public string Email;
        //}
        }

        public MetadataPlaceholderModel CreateMetadataPlaceholder(string key, string value)
        {
            return new MetadataPlaceholderModel() { Name = key, Value = value };
        }
    }
}
