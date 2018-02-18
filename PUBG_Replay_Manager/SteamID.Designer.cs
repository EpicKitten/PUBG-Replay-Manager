namespace PUBG_Replay_Manager
{
    partial class SteamID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SteamID));
            this.SteamIDRich = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // SteamIDRich
            // 
            this.SteamIDRich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamIDRich.Location = new System.Drawing.Point(15, 12);
            this.SteamIDRich.Name = "SteamIDRich";
            this.SteamIDRich.ReadOnly = true;
            this.SteamIDRich.Size = new System.Drawing.Size(301, 409);
            this.SteamIDRich.TabIndex = 0;
            this.SteamIDRich.Text = "";
            this.SteamIDRich.TextChanged += new System.EventHandler(this.SteamIDRich_TextChanged);
            // 
            // SteamID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 432);
            this.Controls.Add(this.SteamIDRich);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SteamID";
            this.Text = "SteamID64 목록";
            this.Load += new System.EventHandler(this.SteamID_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SteamIDRich;
    }
}