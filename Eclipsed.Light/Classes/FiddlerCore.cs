using honeypot.Classes;
using Fiddler;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace honeypot
{
    public static class FiddlerCore
    {
        public static bool CheckCertificate()
        {
            if (!Directory.Exists(Path.GetDirectoryName(Globals.CertLocation)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Globals.CertLocation));
            }

            BCCertMaker.BCCertMaker bC = new BCCertMaker.BCCertMaker();
            CertMaker.oCertProvider = bC;
            string cert = Globals.CertLocation;
            string password = string.Empty;
            if (!File.Exists(cert))
            {
                bC.CreateRootCertificate();
                bC.WriteRootCertificateAndPrivateKeyToPkcs12File(cert, password);
            }
            else
            {
                bC.ReadRootCertificateAndPrivateKeyFromPkcs12File(cert, password);
            }

            if (!CertMaker.rootCertIsTrusted())
            {
                CertMaker.trustRootCert();
            }

            if (CertMaker.rootCertIsTrusted())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsStarted
        {
            get
            {
                return FiddlerApplication.IsStarted();
            }
        }

        public static void BeforeRequest(Session session)
        {
            try
            {
                if (!session.hostname.Contains("bhvrdbd.com")) return;

                #region Get BhvrSession
                if (session.uriContains("/api/v1/config"))
                {
                    if (session.oRequest["Cookie"].Length > 0)
                    {
                        var bhvrsession = session.oRequest["Cookie"].Replace("bhvrSession=", string.Empty);
                        Main.instance.UpdateBhvrSession(bhvrsession);
                    }
                }
                #endregion

                #region Unlock Skins
                if (Options.UnlockAll && session.fullUrl.EndsWith("/api/v1/inventories", StringComparison.OrdinalIgnoreCase))
                {
                    session.utilCreateResponseAndBypassServer();

                    var market = new MarketBuilder()
                        .WithCharacters()
                        .WithCosmetics();

                    if (Options.BloodwebExploit)
                    {
                        market.WithInventory();
                    }

                    session.utilSetResponseBody(market.Build());
                }
                #endregion

                #region Player Card
                if (Options.UnlockAll)
                {
                    if (session.uriContains("api/v1/dbd-player-card"))
                    {
                        if (session.url.EndsWith("/set"))
                        {
                            session.utilCreateResponseAndBypassServer();
                            var body = session.GetRequestBodyAsString();

                            Cache.SelectedBanner = body;
                            Main.instance.SaveSettings();

                            session.utilSetResponseBody(body);
                        }
                        if (session.url.EndsWith("/get"))
                        {
                            if (Cache.SelectedBanner != null)
                            {
                                session.utilCreateResponseAndBypassServer();
                                session.utilSetResponseBody(Cache.SelectedBanner);
                            }
                        }
                    }
                }
                #endregion

                #region Bloodweb Exploit
                if (Options.BloodwebExploit)
                {
                    if (session.uriContains("api/v1/dbd-character-data/bloodweb"))
                    {

                        session.bBufferResponse = true;
                    }

                    if (session.uriContains("api/v1/dbd-character-data/get-all"))
                    {
                        session.responseCode = 200;
                        session.bBufferResponse = true;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                Main.Logs.WriteError($"<{MethodInfo.GetCurrentMethod().Name}> An Error Occurred", ex);
            }
        }
        
        public static void BeforeResponse(Session session)
        {
            try
            {
                #region Bloodweb Exploit
                if (Options.BloodwebExploit)
                {
                    if (session.uriContains("api/v1/dbd-character-data/get-all"))
                    {
                        var getall = JObject.Parse(Cache.CharactersData);
                        var array = getall["list"] as JArray;
                        for (int i = 0; i < array.Count; i++)
                        {
                            array[i]["prestigeLevel"] = Options.Prestige;
                            array[i]["bloodWebLevel"] = 50;
                            array[i]["legacyPrestigeLevel"] = 3;
                        }
                        session.utilSetResponseBody(getall.ToString(Newtonsoft.Json.Formatting.None));
                    }

                    if (Options.BloodwebExploit)
                    {
                        if (session.uriContains("api/v1/dbd-character-data/bloodweb"))
                        {
                            session.responseCode = 200;
                            var reqBody = session.GetRequestBodyAsString();
                            var resBody = session.GetResponseBodyAsString();
                            if (reqBody.TryParseJObject(out var json_Request) && resBody.TryParseJObject(out var json_Response))
                            {
                                var charName = (string)json_Request["characterName"];

                                var result_Response = JObject.Parse(Cache.CharacterData);
                                result_Response["characterName"] = charName;

                                result_Response["prestigeLevel"] = Options.Prestige;
                                result_Response["bloodWebLevel"] = Options.BloodWebLevel;
                                result_Response["legacyPrestigeLevel"] = Options.LegacyPrestigeLevel;

                                session.utilSetResponseBody(result_Response.ToString(Newtonsoft.Json.Formatting.None));
                            }
                        }
                    }
                }
                #endregion

                #region Ban Status
                if (session.uriContains("api/v1/players/ban/status"))
                {
                    session.utilDecodeResponse();
                    var body = session.GetResponseBodyAsString();

                    if (body.Contains("\"isBanned\":true"))
                    {
                        Main.instance.UpdateBanStatus(true);
                    }
                    else
                    {
                        Main.instance.UpdateBanStatus(false);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Main.Logs.WriteError($"<{MethodInfo.GetCurrentMethod().Name}> An Error Occurred", ex);
            }
        }
    }
}
