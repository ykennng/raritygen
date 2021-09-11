namespace RarityGenGen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RarityGenGen.Common;

    public class ItemDefinitionModel
    {
        public ItemDefinitionModel(string name, ItemTypeEnum itemType = ItemTypeEnum.Unknown, RarityEnum rarity = RarityEnum.Unknown, int? position = null)
        {
            ItemName = name;
            ItemType = itemType;
            Rarity = rarity;
            Positioning = position;
        }

        public string ItemName { get; set; }
        public ItemTypeEnum ItemType { get; set; }
        public RarityEnum Rarity { get; set; }
        
        // If one position only, specify 1,2 or 3, if exclude from position, use negatives
        public int? Positioning { get; set; }
    }
}
