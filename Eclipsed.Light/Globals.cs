using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoyRequest
{
    public static class Globals
    {
        public static readonly string DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Eclipsed", "Unlocker_Light");

        public static readonly string LogFilePath = Path.Combine(DataFolder, "Security", "error.log");

        public static readonly string CertLocation = Path.Combine(DataFolder, "Certs", "EclipsedCertificate.p12");

        public static readonly string ConfigPath = Path.Combine(Globals.DataFolder, "config.ini");

        public static readonly string MusicPath = Path.Combine(DataFolder, "music", "unlocker_music.mp3");

        public static readonly string SecurityFolder = Path.Combine(DataFolder, "Security");

        public const string Domain = "eclipsed.top";
    }
}