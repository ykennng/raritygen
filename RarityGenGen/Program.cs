using System;
using System.Collections.Generic;
using RarityGenGen.Common;

namespace RarityGenGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.ReadCsv();
            var items = Globals.ItemDefinitions;
            Utils.WriteItemListsToCSV();
            Console.WriteLine("Hello World!");
        }
    }
}
