namespace RarityGenGen
{
    using RarityGenGen.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Numpy;

    public class CombinationGenerator
    {
        HashSet<FullSetModel> itemSets = new HashSet<FullSetModel>();
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

        public void FillInItemSets(string[] sampleSet, int imagePosition, int sampleSize = 100)
        {
            //switch(imagePosition)
            //{
            //    case 1:
            //        {
            //            break;
            //        }
            //    case 2:
            //        {
            //            break;
            //        }
            //    case 3:
            //        {
            //            break;
            //        }
            //    case 4:
            //        {
            //            break;
            //        }
            //}
            int count = 0;
            foreach(var set in itemSets)
            {
                set.GetType().GetProperty("Image1").SetValue(set, sampleSet[count]);
                //set.Image1 = sampleSet[count];
                count++;
            }
        }
    }
}
