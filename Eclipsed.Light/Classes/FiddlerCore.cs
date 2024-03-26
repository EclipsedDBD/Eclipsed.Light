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
                if (Options.UnlockAll && session.uriContains("api/v1/inventories"))
                {
                    session.utilCreateResponseAndBypassServer();
                    var market = new MarketBuilder()
                        .WithCharacters()
                        .WithCosmetics();
                    if (Options.BloodwebExploit)
                    {
                        market.WithItems();
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
                            array[i]["bloodWebLevel"] = Options.BloodWebLevel;
                            array[i]["legacyPrestigeLevel"] = Options.LegacyPrestigeLevel;
                        }
                        session.utilSetResponseBody(getall.ToString(Newtonsoft.Json.Formatting.None));
                    }

                    if (session.uriContains("api/v1/dbd-character-data/bloodweb"))
                    {
                        var reqBody = JObject.Parse(session.GetRequestBodyAsString());
                        var resBody = JObject.Parse(session.GetResponseBodyAsString());

                        var result = JObject.Parse(Cache.CharacterData);
                        result["characterName"] = resBody["characterName"];

                        result["prestigeLevel"] = Options.Prestige;
                        result["bloodWebLevel"] = Options.BloodWebLevel;
                        result["legacyPrestigeLevel"] = Options.LegacyPrestigeLevel;

                        session.utilSetResponseBody(result.ToString(Newtonsoft.Json.Formatting.None));
                    }
                }
                #endregion

                #region Ban Status
                if (session.uriContains("api/v1/auth"))
                {
                    session.utilDecodeResponse();
                    var body = session.GetResponseBodyAsString();
                    var banStatusCodes = new string[]
                        {
                            "InvalidTokenException",
                            "NotAllowedException",
                            "localizationCode"
                        };
                    if (banStatusCodes.Any(x => body.Contains(x)))
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
