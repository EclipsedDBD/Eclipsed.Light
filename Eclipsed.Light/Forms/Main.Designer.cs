namespace honeypot
{
    partial class Main
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbOptions = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tsAutoUpdater = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lblAutoUpdater = new System.Windows.Forms.Label();
            this.nPrestige = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.tsBweExploit = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.tsUnlockAll = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lblBweExploit = new System.Windows.Forms.Label();
            this.lblUnlockAll = new System.Windows.Forms.Label();
            this.gbData = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblhStatus = new System.Windows.Forms.Label();
            this.lblBanStatus = new System.Windows.Forms.Label();
            this.lblhBanStatus = new System.Windows.Forms.Label();
            this.btnCopyBhvrSession = new Guna.UI2.WinForms.Guna2ImageButton();
            this.tbBhvrSession = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBhvrSession = new System.Windows.Forms.Label();
            this.btnToggleUnlocker = new Guna.UI2.WinForms.Guna2Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnLogs = new Guna.UI2.WinForms.Guna2ImageButton();
            this.tooltip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.lblVersion = new System.Windows.Forms.Label();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPrestige)).BeginInit();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Eclipsed.Light";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // gbOptions
            // 
            this.gbOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.gbOptions.BorderRadius = 6;
            this.gbOptions.Controls.Add(this.tsAutoUpdater);
            this.gbOptions.Controls.Add(this.lblAutoUpdater);
            this.gbOptions.Controls.Add(this.nPrestige);
            this.gbOptions.Controls.Add(this.tsBweExploit);
            this.gbOptions.Controls.Add(this.tsUnlockAll);
            this.gbOptions.Controls.Add(this.lblBweExploit);
            this.gbOptions.Controls.Add(this.lblUnlockAll);
            this.gbOptions.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.gbOptions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.gbOptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbOptions.ForeColor = System.Drawing.Color.White;
            this.gbOptions.Location = new System.Drawing.Point(12, 72);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.ShadowDecoration.Parent = this.gbOptions;
            this.gbOptions.Size = new System.Drawing.Size(360, 140);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.Text = "Options";
            // 
            // tsAutoUpdater
            // 
            this.tsAutoUpdater.Animated = true;
            this.tsAutoUpdater.BackColor = System.Drawing.Color.Transparent;
            this.tsAutoUpdater.Checked = true;
            this.tsAutoUpdater.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(50)))), ((int)(((byte)(169)))));
            this.tsAutoUpdater.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsAutoUpdater.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsAutoUpdater.CheckedState.Parent = this.tsAutoUpdater;
            this.tsAutoUpdater.Location = new System.Drawing.Point(10, 110);
            this.tsAutoUpdater.Name = "tsAutoUpdater";
            this.tsAutoUpdater.ShadowDecoration.Parent = this.tsAutoUpdater;
            this.tsAutoUpdater.Size = new System.Drawing.Size(35, 20);
            this.tsAutoUpdater.TabIndex = 8;
            this.tsAutoUpdater.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsAutoUpdater.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsAutoUpdater.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsAutoUpdater.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.tsAutoUpdater.UncheckedState.Parent = this.tsAutoUpdater;
            // 
            // lblAutoUpdater
            // 
            this.lblAutoUpdater.AutoSize = true;
            this.lblAutoUpdater.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoUpdater.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblAutoUpdater.Location = new System.Drawing.Point(51, 110);
            this.lblAutoUpdater.Name = "lblAutoUpdater";
            this.lblAutoUpdater.Size = new System.Drawing.Size(92, 20);
            this.lblAutoUpdater.TabIndex = 7;
            this.lblAutoUpdater.Text = "Auto Updater";
            this.tooltip.SetToolTip(this.lblAutoUpdater, "Auto update the market files");
            // 
            // nPrestige
            // 
            this.nPrestige.BackColor = System.Drawing.Color.Transparent;
            this.nPrestige.BorderColor = System.Drawing.Color.Empty;
            this.nPrestige.BorderRadius = 10;
            this.nPrestige.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nPrestige.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nPrestige.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nPrestige.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nPrestige.DisabledState.Parent = this.nPrestige;
            this.nPrestige.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nPrestige.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nPrestige.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.nPrestige.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.nPrestige.FocusedState.Parent = this.nPrestige;
            this.nPrestige.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nPrestige.ForeColor = System.Drawing.Color.White;
            this.nPrestige.Location = new System.Drawing.Point(171, 78);
            this.nPrestige.Name = "nPrestige";
            this.nPrestige.ShadowDecoration.Parent = this.nPrestige;
            this.nPrestige.Size = new System.Drawing.Size(63, 25);
            this.nPrestige.TabIndex = 6;
            this.tooltip.SetToolTip(this.nPrestige, "Prestige");
            this.nPrestige.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.nPrestige.UpDownButtonForeColor = System.Drawing.Color.White;
            this.nPrestige.ValueChanged += new System.EventHandler(this.OptionChanged);
            // 
            // tsBweExploit
            // 
            this.tsBweExploit.Animated = true;
            this.tsBweExploit.BackColor = System.Drawing.Color.Transparent;
            this.tsBweExploit.Checked = true;
            this.tsBweExploit.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(50)))), ((int)(((byte)(169)))));
            this.tsBweExploit.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsBweExploit.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsBweExploit.CheckedState.Parent = this.tsBweExploit;
            this.tsBweExploit.Location = new System.Drawing.Point(10, 80);
            this.tsBweExploit.Name = "tsBweExploit";
            this.tsBweExploit.ShadowDecoration.Parent = this.tsBweExploit;
            this.tsBweExploit.Size = new System.Drawing.Size(35, 20);
            this.tsBweExploit.TabIndex = 5;
            this.tsBweExploit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsBweExploit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsBweExploit.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsBweExploit.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.tsBweExploit.UncheckedState.Parent = this.tsBweExploit;
            this.tsBweExploit.CheckedChanged += new System.EventHandler(this.OptionChanged);
            // 
            // tsUnlockAll
            // 
            this.tsUnlockAll.Animated = true;
            this.tsUnlockAll.BackColor = System.Drawing.Color.Transparent;
            this.tsUnlockAll.Checked = true;
            this.tsUnlockAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(50)))), ((int)(((byte)(169)))));
            this.tsUnlockAll.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsUnlockAll.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsUnlockAll.CheckedState.Parent = this.tsUnlockAll;
            this.tsUnlockAll.Location = new System.Drawing.Point(10, 50);
            this.tsUnlockAll.Name = "tsUnlockAll";
            this.tsUnlockAll.ShadowDecoration.Parent = this.tsUnlockAll;
            this.tsUnlockAll.Size = new System.Drawing.Size(35, 20);
            this.tsUnlockAll.TabIndex = 4;
            this.tsUnlockAll.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsUnlockAll.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsUnlockAll.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsUnlockAll.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.tsUnlockAll.UncheckedState.Parent = this.tsUnlockAll;
            this.tsUnlockAll.CheckedChanged += new System.EventHandler(this.OptionChanged);
            // 
            // lblBweExploit
            // 
            this.lblBweExploit.AutoSize = true;
            this.lblBweExploit.BackColor = System.Drawing.Color.Transparent;
            this.lblBweExploit.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblBweExploit.Location = new System.Drawing.Point(51, 80);
            this.lblBweExploit.Name = "lblBweExploit";
            this.lblBweExploit.Size = new System.Drawing.Size(114, 20);
            this.lblBweExploit.TabIndex = 3;
            this.lblBweExploit.Text = "Bloodweb Exploit";
            this.tooltip.SetToolTip(this.lblBweExploit, "Unlock all the Items, Perks, and Addons");
            // 
            // lblUnlockAll
            // 
            this.lblUnlockAll.AutoSize = true;
            this.lblUnlockAll.BackColor = System.Drawing.Color.Transparent;
            this.lblUnlockAll.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblUnlockAll.Location = new System.Drawing.Point(51, 50);
            this.lblUnlockAll.Name = "lblUnlockAll";
            this.lblUnlockAll.Size = new System.Drawing.Size(69, 20);
            this.lblUnlockAll.TabIndex = 1;
            this.lblUnlockAll.Text = "Unlock all";
            this.tooltip.SetToolTip(this.lblUnlockAll, "Unlock all the Skins, Charms, Survivors, and Killers");
            // 
            // gbData
            // 
            this.gbData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.gbData.BorderRadius = 6;
            this.gbData.Controls.Add(this.lblStatus);
            this.gbData.Controls.Add(this.lblhStatus);
            this.gbData.Controls.Add(this.lblBanStatus);
            this.gbData.Controls.Add(this.lblhBanStatus);
            this.gbData.Controls.Add(this.btnCopyBhvrSession);
            this.gbData.Controls.Add(this.tbBhvrSession);
            this.gbData.Controls.Add(this.lblBhvrSession);
            this.gbData.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.gbData.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.gbData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbData.ForeColor = System.Drawing.Color.White;
            this.gbData.Location = new System.Drawing.Point(12, 218);
            this.gbData.Name = "gbData";
            this.gbData.ShadowDecoration.Parent = this.gbData;
            this.gbData.Size = new System.Drawing.Size(360, 150);
            this.gbData.TabIndex = 3;
            this.gbData.Text = "Info";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(64, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(291, 20);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // lblhStatus
            // 
            this.lblhStatus.AutoSize = true;
            this.lblhStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblhStatus.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblhStatus.Location = new System.Drawing.Point(10, 120);
            this.lblhStatus.Name = "lblhStatus";
            this.lblhStatus.Size = new System.Drawing.Size(48, 20);
            this.lblhStatus.TabIndex = 9;
            this.lblhStatus.Text = "Status:";
            // 
            // lblBanStatus
            // 
            this.lblBanStatus.AutoSize = true;
            this.lblBanStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblBanStatus.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblBanStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblBanStatus.Location = new System.Drawing.Point(91, 90);
            this.lblBanStatus.Name = "lblBanStatus";
            this.lblBanStatus.Size = new System.Drawing.Size(68, 20);
            this.lblBanStatus.TabIndex = 8;
            this.lblBanStatus.Text = "Unknown";
            // 
            // lblhBanStatus
            // 
            this.lblhBanStatus.AutoSize = true;
            this.lblhBanStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblhBanStatus.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblhBanStatus.Location = new System.Drawing.Point(10, 90);
            this.lblhBanStatus.Name = "lblhBanStatus";
            this.lblhBanStatus.Size = new System.Drawing.Size(75, 20);
            this.lblhBanStatus.TabIndex = 7;
            this.lblhBanStatus.Text = "Ban Status:";
            // 
            // btnCopyBhvrSession
            // 
            this.btnCopyBhvrSession.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyBhvrSession.CheckedState.Parent = this.btnCopyBhvrSession;
            this.btnCopyBhvrSession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyBhvrSession.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnCopyBhvrSession.HoverState.Parent = this.btnCopyBhvrSession;
            this.btnCopyBhvrSession.Image = global::honeypot.Properties.Resources.copy_50px;
            this.btnCopyBhvrSession.ImageSize = new System.Drawing.Size(25, 25);
            this.btnCopyBhvrSession.Location = new System.Drawing.Point(330, 53);
            this.btnCopyBhvrSession.Name = "btnCopyBhvrSession";
            this.btnCopyBhvrSession.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnCopyBhvrSession.PressedState.Parent = this.btnCopyBhvrSession;
            this.btnCopyBhvrSession.Size = new System.Drawing.Size(25, 25);
            this.btnCopyBhvrSession.TabIndex = 6;
            this.btnCopyBhvrSession.Click += new System.EventHandler(this.btnCopyBhvrSession_Click);
            // 
            // tbBhvrSession
            // 
            this.tbBhvrSession.BackColor = System.Drawing.Color.Transparent;
            this.tbBhvrSession.BorderColor = System.Drawing.Color.Gray;
            this.tbBhvrSession.BorderRadius = 12;
            this.tbBhvrSession.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBhvrSession.DefaultText = "";
            this.tbBhvrSession.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbBhvrSession.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbBhvrSession.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbBhvrSession.DisabledState.Parent = this.tbBhvrSession;
            this.tbBhvrSession.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbBhvrSession.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tbBhvrSession.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.tbBhvrSession.FocusedState.Parent = this.tbBhvrSession;
            this.tbBhvrSession.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbBhvrSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(50)))), ((int)(((byte)(169)))));
            this.tbBhvrSession.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.tbBhvrSession.HoverState.Parent = this.tbBhvrSession;
            this.tbBhvrSession.Location = new System.Drawing.Point(103, 53);
            this.tbBhvrSession.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBhvrSession.Name = "tbBhvrSession";
            this.tbBhvrSession.PasswordChar = '\0';
            this.tbBhvrSession.PlaceholderText = "bhvrSession";
            this.tbBhvrSession.ReadOnly = true;
            this.tbBhvrSession.SelectedText = "";
            this.tbBhvrSession.ShadowDecoration.Parent = this.tbBhvrSession;
            this.tbBhvrSession.Size = new System.Drawing.Size(220, 25);
            this.tbBhvrSession.TabIndex = 5;
            // 
            // lblBhvrSession
            // 
            this.lblBhvrSession.AutoSize = true;
            this.lblBhvrSession.BackColor = System.Drawing.Color.Transparent;
            this.lblBhvrSession.Font = new System.Drawing.Font("Segoe UI Light", 10.75F);
            this.lblBhvrSession.Location = new System.Drawing.Point(10, 55);
            this.lblBhvrSession.Name = "lblBhvrSession";
            this.lblBhvrSession.Size = new System.Drawing.Size(86, 20);
            this.lblBhvrSession.TabIndex = 4;
            this.lblBhvrSession.Text = "BhvrSession:";
            // 
            // btnToggleUnlocker
            // 
            this.btnToggleUnlocker.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleUnlocker.BorderRadius = 18;
            this.btnToggleUnlocker.CheckedState.Parent = this.btnToggleUnlocker;
            this.btnToggleUnlocker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleUnlocker.CustomImages.Parent = this.btnToggleUnlocker;
            this.btnToggleUnlocker.FillColor = System.Drawing.Color.White;
            this.btnToggleUnlocker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToggleUnlocker.ForeColor = System.Drawing.Color.Black;
            this.btnToggleUnlocker.HoverState.Parent = this.btnToggleUnlocker;
            this.btnToggleUnlocker.Location = new System.Drawing.Point(12, 383);
            this.btnToggleUnlocker.Name = "btnToggleUnlocker";
            this.btnToggleUnlocker.ShadowDecoration.Parent = this.btnToggleUnlocker;
            this.btnToggleUnlocker.Size = new System.Drawing.Size(360, 36);
            this.btnToggleUnlocker.TabIndex = 4;
            this.btnToggleUnlocker.Text = "Start";
            this.btnToggleUnlocker.Click += new System.EventHandler(this.btnToggleUnlocker_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblFooter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(1, 445);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(177, 26);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = "https://eclipsed.top/light";
            this.lblFooter.Click += new System.EventHandler(this.lblFooter_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnLogs.CheckedState.Parent = this.btnLogs;
            this.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogs.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogs.HoverState.Parent = this.btnLogs;
            this.btnLogs.Image = global::honeypot.Properties.Resources.parchment_50px;
            this.btnLogs.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogs.Location = new System.Drawing.Point(357, 443);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogs.PressedState.Parent = this.btnLogs;
            this.btnLogs.Size = new System.Drawing.Size(25, 25);
            this.btnLogs.TabIndex = 7;
            this.tooltip.SetToolTip(this.btnLogs, "Logs");
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // tooltip
            // 
            this.tooltip.AllowLinksHandling = true;
            this.tooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tooltip.BorderColor = System.Drawing.Color.White;
            this.tooltip.ForeColor = System.Drawing.Color.White;
            this.tooltip.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(268, 442);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(83, 26);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "v1.1";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 471);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.btnToggleUnlocker);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Honeypot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPrestige)).EndInit();
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2GroupBox gbOptions;
        private System.Windows.Forms.Label lblUnlockAll;
        private System.Windows.Forms.Label lblBweExploit;
        private Guna.UI2.WinForms.Guna2GroupBox gbData;
        private Guna.UI2.WinForms.Guna2TextBox tbBhvrSession;
        private System.Windows.Forms.Label lblBhvrSession;
        private Guna.UI2.WinForms.Guna2ImageButton btnCopyBhvrSession;
        private System.Windows.Forms.Label lblBanStatus;
        private System.Windows.Forms.Label lblhBanStatus;
        private Guna.UI2.WinForms.Guna2Button btnToggleUnlocker;
        private System.Windows.Forms.Label lblFooter;
        private Guna.UI2.WinForms.Guna2ImageButton btnLogs;
        private Guna.UI2.WinForms.Guna2HtmlToolTip tooltip;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblhStatus;
        public Guna.UI2.WinForms.Guna2ToggleSwitch tsBweExploit;
        public Guna.UI2.WinForms.Guna2ToggleSwitch tsUnlockAll;
        public Guna.UI2.WinForms.Guna2NumericUpDown nPrestige;
        public Guna.UI2.WinForms.Guna2ToggleSwitch tsAutoUpdater;
        private System.Windows.Forms.Label lblAutoUpdater;
        private System.Windows.Forms.Label lblVersion;
    }
}

