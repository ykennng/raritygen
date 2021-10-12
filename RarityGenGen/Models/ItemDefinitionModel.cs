namespace RarityGenGen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RarityGenGen.Common;

    public class ItemDefinitionModel
    {
        public ItemDefinitionModel(string name, ItemTypeEnum itemType = ItemTypeEnum.Unknown, RarityEnum rarity = RarityEnum.Unknown, PositionEnum position = PositionEnum.Any)
        {
            ItemName = name;
            ItemType = itemType;
            Rarity = rarity;
            Positioning = position;
        }

        public string ItemName { get; set; }
        public ItemTypeEnum ItemType { get; set; }
        public RarityEnum Rarity { get; set; }
        
        public PositionEnum Positioning { get; set; }
    }
}
