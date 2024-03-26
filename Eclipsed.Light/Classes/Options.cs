using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace honeypot.Classes
{
    public static class Options
    {
        public static bool UnlockAll
        {
            get
            {
                return Main.instance?.tsUnlockAll?.Checked ?? false;
            }
        }
        
        public static bool BloodwebExploit
        {
            get
            {
                return Main.instance?.tsBweExploit?.Checked ?? false;
            }
        }
        
        public static int Prestige
        {
            get
            {
                return (int)(Main.instance?.nPrestige?.Value ?? 0);
            }
        }

        public static bool AutoUpdater
        {
            get
            {
                return Main.instance?.tsAutoUpdater?.Checked ?? false;
            }
        }

        /// <summary>
        /// The default value of the bloodweb level for every character for bloodweb exploit, value must be minimum 0 and maximum 50
        /// </summary>
        public const int BloodWebLevel = 50;

        /// <summary>
        /// The default value of the legacy prestige for every character for bloodweb exploit, value must be minimum 0 and maximum 3
        /// </summary>
        public const int LegacyPrestigeLevel = 3;

    }
}
