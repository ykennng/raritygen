namespace RarityGenGen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RarityGenGen.Common;

    public class SpriteModel
    {
        public SpriteModel(string name, string filename, int? quantity, SpriteTypeEnum itemType = SpriteTypeEnum.Unknown)
        {
            ItemName = name;
            FileName = filename;
            MaxQty = quantity;
            SpriteType = itemType;
        }

        public string ItemName { get; set; }

        public string FileName { get; set; }

        public int? MaxQty { get; set; }
        
        public SpriteTypeEnum SpriteType { get; set; }
    }
}
