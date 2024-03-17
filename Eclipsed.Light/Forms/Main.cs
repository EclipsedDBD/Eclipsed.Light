using Eclipsed.Light.Classes;
using Eclipsed.Light.Forms;
using Eclipsed.Light.Properties;
using Fiddler;
using IniParser;
using IniParser.Model;
using IniParser.Parser;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Eclipsed.Light
{
    public partial class Main : Form
    {
        public static Main instance { get; private set; }
        public Main()
        {
            InitializeComponent();
            instance = this;
            Directory.CreateDirectory(Globals.DataFolder);
        }

        public static Logs Logs { get; private set; }

        private void Main_Load(object sender, EventArgs e)
        {
            Logs = new Logs();
            Logs.Location = new Point((this.Location.X + this.Width), this.Location.Y);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            LoadSettings();
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (Logs != null)
                Logs.WriteError("Unhandled Exception", e.Exception);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (Logs != null)
                Logs.WriteError("Unhandled Exception", (Exception)e.ExceptionObject);
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            if (Logs.Visible)
                Logs.Hide();
            else
                Logs.Show();
        }

        private void lblFooter_Click(object sender, EventArgs e)
        {
            Process.Start("https://eclipsed.top/light");
        }

        private void btnCopyBhvrSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbBhvrSession.Text)) return;

                Clipboard.SetText(tbBhvrSession.Text);
            }
            catch (Exception ex)
            {
                Logs.WriteError($"<{MethodInfo.GetCurrentMethod().Name}> Unable to set clipboard text", ex);
            }
        }

        private async void btnToggleUnlocker_Click(object sender, EventArgs e)
        {
            try
            {
                if (FiddlerCore.IsStarted)
                {
                    await StopUnlocker();
                }
                else
                {
                    await StartUnlocker();
                }
            }
            finally
            {
                if (FiddlerCore.IsStarted)
                {
                    this.btnToggleUnlocker.Text = "Stop";
                }
                else
                {
                    this.btnToggleUnlocker.Text = "Start";
                }
            }
        }

        public void UpdateStatus(string text)
        {
            this.lblStatus.Text = text;
            Logs.Write($"<UpdateStatus> {text}");
        }

        private async Task StartUnlocker()
        {
            if (Options.AutoUpdater)
            {
                UpdateStatus("Updating market files");
                var filesToUpdate = await Market.CheckFiles();

                if (filesToUpdate == null)
                {
                    UpdateStatus("Market update failed");
                    var _continue = MessageBox.Show("Unable to check if market files updated, check the logs for more information.\r\nDo you want to continue without updating market files?", "Update Market Files", MessageBoxButtons.YesNo);
                    if (_continue == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (filesToUpdate.Count > 0)
                {
                    var UpdateFiles = MessageBox.Show($"Do you want to update market files in the following list:\r\n- {string.Join("\r\n- ", filesToUpdate)}", "Update Market Files", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (UpdateFiles == DialogResult.Yes)
                    {
                        var uf_status = await Market.UpdateFiles(filesToUpdate);
                        if (!uf_status)
                        {
                            UpdateStatus("Market update failed");
                            var _continue = MessageBox.Show("Unable to update market files, check the logs for more information.\r\nDo you want to continue without updating market files?", "Update Market Files", MessageBoxButtons.YesNo);
                            if (_continue == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
            }

            UpdateStatus("Updating cache");
            await Cache.UpdateCache();
            UpdateStatus("Creating proxy...");

            while (!FiddlerCore.CheckCertificate())
            {
                UpdateStatus("Trust the certificate");
                await Task.Delay(3000);
            }

            var Fiddlersettings = new FiddlerCoreStartupSettingsBuilder()
                    .ListenOnPort(8888).RegisterAsSystemProxy().ChainToUpstreamGateway().DecryptSSL().OptimizeThreadPool().Build();
            FiddlerApplication.Startup(Fiddlersettings);
            FiddlerApplication.BeforeRequest += FiddlerCore.BeforeRequest;
            FiddlerApplication.BeforeResponse += FiddlerCore.BeforeResponse;

            UpdateStatus($"Internet Proxy Enabled ({FiddlerApplication.oProxy.ListenPort})");
            await Task.Delay(2000);
            UpdateStatus("Unlocker ready");
        }

        private Task StopUnlocker()
        {
            FiddlerApplication.Shutdown();
            UpdateStatus("Unlocker stopped");
            return Task.CompletedTask;
        }

        public void SaveSettings()
        {
            var section = "Options";
            if (!File.Exists(Globals.ConfigPath))
                File.Create(Globals.ConfigPath).Close();

            var parser = new FileIniDataParser();
            var cfg = new IniData();

            cfg[section]["UnlockAll"] = tsUnlockAll.Checked.ToString();
            cfg[section]["BweExploit"] = tsBweExploit.Checked.ToString();
            cfg[section]["Prestige"] = nPrestige.Value.ToString();
            cfg[section]["AutoUpdater"] = tsAutoUpdater.Checked.ToString();
            if (Cache.SelectedBanner != null)
            {
                cfg["Player"]["SelectedBanner"] = Cache.SelectedBanner;
            }

            parser.WriteFile(Globals.ConfigPath, cfg);
        }

        public void LoadSettings()
        {
            if (File.Exists(Globals.ConfigPath))
            {
                var section = "Options";
                var parser = new FileIniDataParser();
                var cfg = parser.ReadFile(Globals.ConfigPath);

                if (cfg.TryGetKey(section + cfg.SectionKeySeparator + "UnlockAll", out var s_unlockall) && bool.TryParse(s_unlockall, out var unlockall))
                {
                    tsUnlockAll.Checked = unlockall;
                }
                if (cfg.TryGetKey(section + cfg.SectionKeySeparator + "BweExploit", out var s_bweexploit) && bool.TryParse(s_bweexploit, out var bweexploit))
                {
                    tsBweExploit.Checked = bweexploit;
                }
                if (cfg.TryGetKey(section + cfg.SectionKeySeparator + "Prestige", out var s_prestige) && int.TryParse(s_prestige, out var prestige))
                {
                    nPrestige.Value = prestige;
                }
                if (cfg.TryGetKey(section + cfg.SectionKeySeparator + "AutoUpdater", out var s_autoupdater) && bool.TryParse(s_autoupdater, out var autoupdater))
                {
                    tsAutoUpdater.Checked = autoupdater;
                }
                if (cfg.TryGetKey("Player" + cfg.SectionKeySeparator + "SelectedBanner", out var selectedbanner))
                {
                    Cache.SelectedBanner = selectedbanner;
                }
            }
        }

        private void OptionChanged(object sender, EventArgs e)
        {
            if (sender == tsBweExploit)
            {
                if (tsBweExploit.Checked)
                    nPrestige.Enabled = true;
                else
                    nPrestige.Enabled = false;
            }
            SaveSettings();
        }

        public void UpdateBhvrSession(string bhvrSession)
        {
            this.tbBhvrSession.Text = bhvrSession;
        }

        public void UpdateBanStatus(bool banned)
        {
            this.lblBanStatus.ForeColor = banned ? Color.FromArgb(231, 77, 60) : Color.FromArgb(42, 156, 50);
            this.lblBanStatus.Text = banned ? "Banned" : "Not Banned";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FiddlerCore.IsStarted)
            {
                FiddlerApplication.Shutdown();
            }
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            tooltip.SetToolTip(lblStatus, lblStatus.Text);
        }

        private bool DavidBackground;

        private bool IsPlayerInitialized;

        private IWavePlayer player = new WaveOutEvent();

        private void lblTitle_Click(object sender, EventArgs e)
        {
            DavidBackground = !DavidBackground;
            if (DavidBackground)
            {
                this.BackgroundImage = Resources.roblox_david;
                ToggleMusic(true);
            }
            else
            {
                this.BackgroundImage = null;
                ToggleMusic(false);
            }
        }

        private async void ToggleMusic(bool play)
        {
            try
            {
                if (!IsPlayerInitialized)
                {
                    IsPlayerInitialized = true;
                    player.PlaybackStopped += (s, e) =>
                    {
                        ToggleMusic(true);
                    };
                }
                if (play)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Globals.MusicPath));
                    var head = await Rest.HeadMusic();
                    if (head.IsSuccessStatusCode && head.ContentType.StartsWith("audio"))
                    {
                        var headers_last_modified = head.ContentHeaders.Where(x => x.Name == "Last-Modified");
                        if (headers_last_modified.Count() != 0 && DateTime.TryParse(headers_last_modified.First().Value.ToString(), out var last_modified))
                        {
                            if (File.Exists(Globals.MusicPath))
                            {
                                var info = new FileInfo(Globals.MusicPath);
                                if (info.LastWriteTime.CompareTo(last_modified) != 0)
                                {
                                    await UpdateMusic();
                                }
                            }
                            else
                            {
                                await UpdateMusic();
                            }
                        }
                        else
                        {
                            await UpdateMusic();
                        }

                        if (player.PlaybackState == PlaybackState.Paused)
                        {
                            player.Play();
                        }
                        else
                        {
                            var audioFile = new AudioFileReader(Globals.MusicPath);
                            if (player.PlaybackState != PlaybackState.Playing)
                            {
                                player.Init(audioFile);
                            }
                            player.Play();
                        }

                    }
                }
                else
                {
                    player.Pause();
                }
            }
            catch (Exception ex)
            {
                Logs.WriteError("An error occurred while starting music", ex);
            }
        }

        private async Task UpdateMusic()
        {
            try
            {
                var response = await Rest.GetMusic();
                if (response.IsSuccessStatusCode && response.ContentType.StartsWith("audio"))
                {
                    using (var file = File.Open(Globals.MusicPath, FileMode.Create, FileAccess.Write))
                    {
                        var bytes = response.RawBytes;
                        await file.WriteAsync(bytes, 0, bytes.Length);
                        file.SetLength(bytes.Length);
                        file.Close();
                    }
                    File.SetLastWriteTimeUtc(Globals.MusicPath, DateTime.Parse(response.ContentHeaders.First(x => x.Name == "Last-Modified").Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                Logs.WriteError("An error occurred while updating music", ex);
            }
        }

    }
}
