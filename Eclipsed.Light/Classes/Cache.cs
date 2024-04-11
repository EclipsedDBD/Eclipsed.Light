using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honeypot.Classes
{
    public static class Cache
    {
        public static async Task UpdateCache()
        {
            MarketEmpty = File.ReadAllText(Market.MarketFilePaths["MarketEmpty"]);
            CharactersData = File.ReadAllText(Market.MarketFilePaths["CharactersData"]);
            CharacterData = File.ReadAllText(Market.MarketFilePaths["CharacterData"]);
            Characters = File.ReadAllText(Market.MarketFilePaths["Characters"]);
            Cosmetics = File.ReadAllText(Market.MarketFilePaths["Cosmetics"]);
            Inventory = File.ReadAllText(Market.MarketFilePaths["Inventory"]);
        }

        public static string MarketEmpty { get; set; }
        public static string CharactersData { get; set; }
        public static string CharacterData { get; set; }
        public static string Characters { get; set; }
        public static string Cosmetics { get; set; }
        public static string Inventory { get; set; }

        public static string SelectedBanner { get; set; }
    }
}
