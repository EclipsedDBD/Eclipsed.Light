namespace DecoyRequest.Forms
{
    partial class Logs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logs));
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbLogs
            // 
            this.rtbLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.rtbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtbLogs.ForeColor = System.Drawing.Color.White;
            this.rtbLogs.Location = new System.Drawing.Point(0, 0);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(484, 261);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.rtbLogs);
            this.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Logs | DecoyRequest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logs_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLogs;
    }
}