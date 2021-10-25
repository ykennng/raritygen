namespace RarityGenGen
{
    using RarityGenGen.Common;
    using RarityGenGen.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Numpy;

    public class CombinationGenerator
    {
        public List<FullSetModel> itemSets { get; set; } = new List<FullSetModel>();
        int sampleSize = 0;

        public CombinationGenerator(int setSize)
        {
            sampleSize = setSize;
            int count = 0;
            while(count < sampleSize)
            {
                itemSets.Add(new FullSetModel());
                count++;
            }
        }

        public string[] GenerateCombinations(SpriteTypeEnum spriteType, int resultSize = 100)
        {
            var itemFilenames = Globals.SpriteDefinitions.Where(x => x.SpriteType == spriteType).Select(x=>x.FileName).ToArray();
            var itemDroprates = Globals.SpriteDefinitions.Where(x => x.SpriteType == spriteType).Select(x => x.DropRate).ToArray();
            
            if(!itemFilenames.Any())
            {
                return itemFilenames;
            }

            var remainingDropRateProbability = 1 - itemDroprates.Sum();
            var avgProbabilityForRemainderItems = remainingDropRateProbability / itemDroprates.Where(x=>x ==0).ToArray().Length;            
            for(int i = 0; i < itemDroprates.Length; i++)
            {
                if(itemDroprates[i] == 0)
                {
                    itemDroprates[i] = avgProbabilityForRemainderItems;
                }
            }

            NDarray<string> nDarrayItem = new NDarray<string>(itemFilenames);
            NDarray<string> nDarrayItemDropRate = new NDarray<string>(itemDroprates);
            int[] size = new int[1];
            size[0] = resultSize;

            var result = Numpy.np.random.choice(nDarrayItem, size, true, nDarrayItemDropRate);
            var resultInString = result.ravel().ToString().Replace("['", string.Empty).Replace("']", string.Empty).Replace("\n", string.Empty);
            var resultArray = resultInString.Split("' '");

            return resultArray;
        }

        public void FillInItemSets(string[] sampleSet, int imagePosition, int sampleSize = 100, string folderName = null, string picFormat = null)
        {
            int count = 0;
            if (!sampleSet.Any())
            {
                Console.WriteLine($"No items for set: {folderName ?? "Nani"}");
            }
            else
            {
                foreach (var set in itemSets)
                {
                    set.GetType().GetProperty($"Image{imagePosition}").SetValue(set, (folderName ?? string.Empty) + sampleSet[count] + picFormat);
                    count++;
                }
            }
        }

        public void FillInMetadataModel(string image01 = null, string image02 = null, string image03 = null, string image04 = null, string image05 = null, string image06 = null, string outputImageName = null)
        {
            var attribute1 = !string.IsNullOrEmpty(image01) ? image01.Split("\\")[1].Replace(".png", string.Empty) : null;
            var attribute2 = !string.IsNullOrEmpty(image02) ? image02.Split("\\")[1].Replace(".png", string.Empty) : null;
            var attribute3 = !string.IsNullOrEmpty(image03) ? image03.Split("\\")[1].Replace(".png", string.Empty) : null;
            var attribute4 = !string.IsNullOrEmpty(image04) ? image04.Split("\\")[1].Replace(".png", string.Empty) : null;
            var attribute5 = !string.IsNullOrEmpty(image05) ? image05.Split("\\")[1].Replace(".png", string.Empty) : null;
            //var attribute6 = !string.IsNullOrEmpty(image06) ? image06.Split("\\")[1].Replace(".png", string.Empty) : null;
            var outputImage = outputImageName;

            Globals.ItemMetadataList.Add(new MetadataExportModel()
            {
                Background_Name = attribute1,
                Skin_Name = attribute2,
                Head_Name = attribute3,
                Body_Name = attribute4,
                Equipment_Name = attribute5,
                OutputImageLocation = outputImageName
            });
        }
    }
}
