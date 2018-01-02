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
            this.SteamIDRich = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // SteamIDRich
            // 
            this.SteamIDRich.Location = new System.Drawing.Point(13, 13);
            this.SteamIDRich.Name = "SteamIDRich";
            this.SteamIDRich.Size = new System.Drawing.Size(259, 443);
            this.SteamIDRich.TabIndex = 0;
            this.SteamIDRich.Text = "";
            this.SteamIDRich.TextChanged += new System.EventHandler(this.SteamIDRich_TextChanged);
            // 
            // SteamID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 468);
            this.Controls.Add(this.SteamIDRich);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SteamID";
            this.Text = "List of all SteamID64";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SteamIDRich;
    }
}