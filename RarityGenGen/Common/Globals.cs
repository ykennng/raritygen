using System;
using System.Collections.Generic;
using System.Text;
using RarityGenGen.Models;

namespace RarityGenGen.Common
{
    public static class Globals
    {
        public static HashSet<SpriteModel> SpriteDefinitions = new HashSet<SpriteModel>();

        public static List<MetadataExportModel> ItemMetadataList = new List<MetadataExportModel>();
    }
}
