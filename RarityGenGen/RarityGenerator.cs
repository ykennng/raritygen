namespace RarityGenGen
{
    using RarityGenGen.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class RarityGenerator
    {
        HashSet<ItemDefinitionModel> itemDefinitions = new HashSet<ItemDefinitionModel>();
        Dictionary<string, int> dropRateInSampleSize = new Dictionary<string, int>();

        public RarityGenerator(HashSet<ItemDefinitionModel> items)
        {
            this.itemDefinitions = items;
        }

        public void CheckProbabilityAgainstSampleSize(int sampleSize)
        {
            var common = itemDefinitions.Where(x => x.Rarity == RarityEnum.Common).Count();
            var uncommon = itemDefinitions.Where(x => x.Rarity == RarityEnum.Uncommon).Count();
            var rare = itemDefinitions.Where(x => x.Rarity == RarityEnum.Rare).Count();
            var exotic = itemDefinitions.Where(x => x.Rarity == RarityEnum.Exotic).Count();
            var divine = itemDefinitions.Where(x => x.Rarity == RarityEnum.Divine).Count();
            var ethereal = itemDefinitions.Where(x => x.Rarity == RarityEnum.Ethereal).Count();
            decimal totalNumberOfItems = common + uncommon + rare + exotic + divine + ethereal;
            
            var commonShare = Math.Round((common / totalNumberOfItems * 100), 2, MidpointRounding.ToEven);
            var uncommonShare = Math.Round((uncommon / totalNumberOfItems * 100), 2, MidpointRounding.ToEven);
            var rareShare = Math.Round((rare / totalNumberOfItems * 100), 2, MidpointRounding.ToEven);
            var exoticShare = Math.Round((exotic / totalNumberOfItems * 100), 2, MidpointRounding.ToEven);
            var divineShare = Math.Round((divine / totalNumberOfItems * 100), 2, MidpointRounding.ToEven);
            var etherealShare = Math.Round((ethereal / totalNumberOfItems * 100), 2, MidpointRounding.ToEven);

            Console.WriteLine("\nItem count and their distribution among total number of items:");
            Console.WriteLine($"Common:{common}, {commonShare}%");
            Console.WriteLine($"Uncommon:{uncommon}, {uncommonShare}%");
            Console.WriteLine($"Rare:{rare}, {rareShare}%");
            Console.WriteLine($"Exotic:{exotic}, {exoticShare}%");
            Console.WriteLine($"Divine:{divine}, {divineShare}%");
            Console.WriteLine($"Ethereal:{ethereal}, {etherealShare}%");
            Console.WriteLine($"Total Number of Items:{totalNumberOfItems}\n");
            
            var dropRatesEnumArray = Enum.GetValues(typeof(DropRateEnum));
            var dropRates = dropRatesEnumArray.Cast<int>().ToArray();
            
            for(int i = 0; i < dropRatesEnumArray.Length; i++)
            {
                var rarityName = dropRatesEnumArray.GetValue(i).ToString();
                var rate = dropRates[i];
                var frequencyInSample = Math.Round((sampleSize * (rate / 100.0)), 0, MidpointRounding.AwayFromZero);
                dropRateInSampleSize.Add(rarityName, (int)frequencyInSample);
            }
            var test = itemDefinitions.Where(x => x.ItemType != ItemTypeEnum.Background && x.ItemType != ItemTypeEnum.BagType && x.ItemType != ItemTypeEnum.Unknown).Count();
        }
    }
}
