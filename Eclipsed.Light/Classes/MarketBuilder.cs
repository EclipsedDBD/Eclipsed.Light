using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honeypot.Classes
{
    public class MarketBuilder
    {
        private int unix = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        private JObject MarketData;
        private Random rnd = new Random();
        public MarketBuilder()
        {
            MarketData = JObject.Parse(Cache.MarketEmpty);
            if (MarketData["inventoryItems"] == null)
                MarketData["inventoryItems"] = new JArray();
        }

        public MarketBuilder WithCharacters()
        {
            var chars = JArray.Parse(Cache.Characters);
            foreach (var character in chars)
            {
                var jobject = new JObject();
                jobject.Add("lastUpdateAt", rnd.Next(unix - 1000, unix + 1000));
                jobject.Add("objectId", character["itemId"].ToString());
                jobject.Add("quantity", 1);
                (MarketData["inventoryItems"] as JArray).Add(jobject);
            }
            return this;
        }

        public MarketBuilder WithCosmetics()
        {
            var cosmetics = JArray.Parse(Cache.Cosmetics);
            foreach (var cosmetic in cosmetics)
            {
                var jobject = new JObject();
                jobject.Add("lastUpdateAt", rnd.Next(unix - 1000, unix + 1000));
                jobject.Add("objectId", cosmetic);
                jobject.Add("quantity", 1);
                (MarketData["inventoryItems"] as JArray).Add(jobject);
            }
            return this;
        }

        public MarketBuilder WithInventory()
        {
            var Inventory = JArray.Parse(Cache.Inventory);
            foreach (var item in Inventory)
            {
                var jobject = new JObject();
                jobject.Add("lastUpdateAt", rnd.Next(unix - 1000, unix + 1000));
                jobject.Add("objectId", item);
                jobject.Add("quantity", 3);
                (MarketData["inventoryItems"] as JArray).Add(jobject);
            }
            return this;
        }


        public string Build()
        {
            return MarketData.ToString(Newtonsoft.Json.Formatting.None);
        }
    }
}
