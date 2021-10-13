namespace RarityGenGen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RarityGenGen.Common;

    public class SpriteModel
    {
        public SpriteModel(string name, string filename, int? quantity, double drop, SpriteTypeEnum itemType = SpriteTypeEnum.Unknown)
        {
            ItemName = name;
            FileName = filename;
            MaxQty = quantity;
            DropRate = drop;
            SpriteType = itemType;
        }

        public string ItemName { get; set; }

        public string FileName { get; set; }

        public int? MaxQty { get; set; }

        public double DropRate { get; set; }

        public SpriteTypeEnum SpriteType { get; set; }
    }
}
