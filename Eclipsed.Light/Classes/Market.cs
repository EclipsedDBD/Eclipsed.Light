using honeypot.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace honeypot.Classes
{
    public static class Market
    {
        static readonly string BasePath = Path.Combine(Globals.DataFolder, "Market");

        public static readonly Dictionary<string, string> MarketFilePaths = new Dictionary<string, string>()
        {
            { "MarketEmpty", Path.Combine(BasePath, "MarketEmpty.json") },
            { "CharactersData", Path.Combine(BasePath, "CharactersData.json") },
            { "CharacterData", Path.Combine(BasePath, "CharacterData.json") },
            { "Characters", Path.Combine(BasePath, "Characters.json") },
            { "Cosmetics", Path.Combine(BasePath, "Cosmetics.json") },
            { "Items", Path.Combine(BasePath, "Items.json") }
        };


        /// <summary>
        /// Check the market files by hash on server and return the non-matching files
        /// </summary>
        /// <returns>market file names that non-matching hashes by given server</returns>
        public static async Task<List<string>> CheckFiles()
        {
            try
            {
                Directory.CreateDirectory(BasePath);
                var local_files = new List<MarketFile>();
                foreach (var marketfile in MarketFilePaths)
                {
                    var mf = new MarketFile();
                    mf.Name = marketfile.Key;
                    if (File.Exists(marketfile.Value))
                    {
                        var data = File.ReadAllText(marketfile.Value);
                        mf.Hash = Utils.CalculateSha1(data);
                    }
                    local_files.Add(mf);
                }

                var filesToUpdate = new List<string>();
                var response = await Rest.GetMarketFileHashes();
                if (response.IsSuccessStatusCode)
                {
                    var json = JsonConvert.DeserializeObject<List<MarketFile>>(response.Content);
                    foreach (var mf in json)
                    {
                        var files = local_files.Where(x => x.Name == mf.Name);
                        if (files.Count() != 0)
                        {
                            var file = files.First();
                            if (file.Hash != mf.Hash)
                            {
                                filesToUpdate.Add(mf.Name);
                            }
                        }
                    }
                    return filesToUpdate;

                }
                else
                {
                    Main.Logs.Write($"Unable to check market files\nStatus Code: {(int)response.StatusCode}\nResponse: {response.Content}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Main.Logs.WriteError("Unable to check market files", ex);
                return null;
            }
        }

        /// <summary>
        /// Updates the market files from the server
        /// </summary>
        /// <param name="market_files">the list of market file names to update</param>
        /// <returns</returns>
        public static async Task<bool> UpdateFiles(List<string> market_files)
        {
            try
            {
                if (market_files == null || market_files.Count == 0) return true;

                Main.instance.UpdateStatus($"Updating market files: {string.Join(", ", market_files)}");
                foreach (var ftu in market_files)
                {
                    var market_response = await Rest.GetMarketFile(ftu);
                    if (market_response.IsSuccessStatusCode)
                    {
                        if (MarketFilePaths.TryGetValue(ftu, out var path))
                        {
                            using (var file = File.Open(path, FileMode.Create, FileAccess.Write))
                            {
                                var bytes = Encoding.UTF8.GetBytes(market_response.Content);
                                await file.WriteAsync(bytes, 0, bytes.Length);
                                file.SetLength(bytes.Length);
                                file.Close();
                            }
                        }
                    }
                    else
                    {
                        Main.Logs.Write($"Unable to update market file: {ftu}\nStatus Code: {(int)market_response.StatusCode}\nResponse: {market_response.Content}");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Main.Logs.WriteError("Unable to update market files", ex);
                return false;
            }
        }
    }
}
