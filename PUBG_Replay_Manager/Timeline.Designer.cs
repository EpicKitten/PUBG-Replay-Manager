namespace PUBG_Replay_Manager
{
    partial class Timeline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timeline));
            this.timelineRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // timelineRTB
            // 
            this.timelineRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timelineRTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.timelineRTB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.timelineRTB.Location = new System.Drawing.Point(14, 11);
            this.timelineRTB.Name = "timelineRTB";
            this.timelineRTB.ReadOnly = true;
            this.timelineRTB.Size = new System.Drawing.Size(991, 508);
            this.timelineRTB.TabIndex = 0;
            this.timelineRTB.Text = "";
            // 
            // Timeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 530);
            this.Controls.Add(this.timelineRTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Timeline";
            this.Text = "킬, 기절 타임라인";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox timelineRTB;
    }
}