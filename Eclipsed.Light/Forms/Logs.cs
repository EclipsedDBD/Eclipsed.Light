using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecoyRequest.Forms
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
        }

        public void Write(string text)
        {
            if (text == null) return;
            var t = $"[{DateTime.Now.ToString()}] {text}\r\n";
            rtbLogs.Text += t;
            WriteToLogsFile(t);
        }

        public void WriteError(string text, Exception ex)
        {
            if (ex == null) return;
            var t = $"[{DateTime.Now.ToString()}] {text}\n{Line()}\n{ex.ToString()}\n{Line()}\r\n";
            rtbLogs.Text += t;
            WriteToLogsFile(t);
        }

        private string Line()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 40; i++)
            {
                sb.Append("=");
            }
            return sb.ToString();
        }

        private object FileLock = new object();

        private void WriteToLogsFile(string text)
        {
            lock (FileLock)
            {
                if (File.Exists(Globals.LogFilePath))
                {
                    var fileInfo = new FileInfo(Globals.LogFilePath);
                    if (fileInfo.Length > 5000000)
                    {
                        File.WriteAllText(Globals.LogFilePath, string.Empty);
                    }
                }
                using (var file = File.Open(Globals.LogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    file.Seek(0, SeekOrigin.End);
                    var bytes = Encoding.UTF8.GetBytes(text);
                    file.Write(bytes, 0, bytes.Length);
                    file.Close();
                }
            }
        }

        private void Logs_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
