namespace PUBG_Replay_Manager
{
    partial class Main
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
            this.replayList = new System.Windows.Forms.ListBox();
            this.openReplayFolder = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.steamidStrip = new System.Windows.Forms.Button();
            this.zipReplay = new System.Windows.Forms.Button();
            this.openSelectedReplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.teamInfo = new System.Windows.Forms.Label();
            this.serverRegion = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.matchType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mapName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileLocked = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timeRecorded = new System.Windows.Forms.Label();
            this.recordingSize = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lengthInMins = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.isLive = new System.Windows.Forms.CheckBox();
            this.isIncomplete = new System.Windows.Forms.CheckBox();
            this.IsServerRecording = new System.Windows.Forms.CheckBox();
            this.networkVerison = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gameVerison = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.profileLink = new System.Windows.Forms.LinkLabel();
            this.recordingUser = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.serverId = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.importReplay = new System.Windows.Forms.Button();
            this.replayListRefresh = new System.Windows.Forms.Button();
            this.diedorwon = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // replayList
            // 
            this.replayList.FormattingEnabled = true;
            this.replayList.Location = new System.Drawing.Point(12, 16);
            this.replayList.Name = "replayList";
            this.replayList.Size = new System.Drawing.Size(407, 641);
            this.replayList.TabIndex = 0;
            this.replayList.SelectedIndexChanged += new System.EventHandler(this.replayList_SelectedIndexChanged);
            // 
            // openReplayFolder
            // 
            this.openReplayFolder.Location = new System.Drawing.Point(424, 633);
            this.openReplayFolder.Name = "openReplayFolder";
            this.openReplayFolder.Size = new System.Drawing.Size(128, 23);
            this.openReplayFolder.TabIndex = 8;
            this.openReplayFolder.Text = "Open Replays Folder";
            this.openReplayFolder.UseVisualStyleBackColor = true;
            this.openReplayFolder.Click += new System.EventHandler(this.openReplayFolder_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.steamidStrip);
            this.groupBox4.Controls.Add(this.zipReplay);
            this.groupBox4.Controls.Add(this.openSelectedReplay);
            this.groupBox4.Location = new System.Drawing.Point(425, 490);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 112);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Replay Actions";
            // 
            // steamidStrip
            // 
            this.steamidStrip.Enabled = false;
            this.steamidStrip.Location = new System.Drawing.Point(6, 48);
            this.steamidStrip.Name = "steamidStrip";
            this.steamidStrip.Size = new System.Drawing.Size(252, 23);
            this.steamidStrip.TabIndex = 2;
            this.steamidStrip.Text = "Every SteamID64 in the replay";
            this.steamidStrip.UseVisualStyleBackColor = true;
            this.steamidStrip.Click += new System.EventHandler(this.steamidStrip_Click);
            // 
            // zipReplay
            // 
            this.zipReplay.Enabled = false;
            this.zipReplay.Location = new System.Drawing.Point(6, 77);
            this.zipReplay.Name = "zipReplay";
            this.zipReplay.Size = new System.Drawing.Size(252, 23);
            this.zipReplay.TabIndex = 1;
            this.zipReplay.Text = "Export Selected Replay";
            this.zipReplay.UseVisualStyleBackColor = true;
            this.zipReplay.Click += new System.EventHandler(this.zipReplay_Click);
            // 
            // openSelectedReplay
            // 
            this.openSelectedReplay.Enabled = false;
            this.openSelectedReplay.Location = new System.Drawing.Point(6, 19);
            this.openSelectedReplay.Name = "openSelectedReplay";
            this.openSelectedReplay.Size = new System.Drawing.Size(252, 23);
            this.openSelectedReplay.TabIndex = 0;
            this.openSelectedReplay.Text = "Open Selected Replay\'s Folder";
            this.openSelectedReplay.UseVisualStyleBackColor = true;
            this.openSelectedReplay.Click += new System.EventHandler(this.openSelectedReplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weather:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Team:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(148, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 90);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // teamInfo
            // 
            this.teamInfo.AutoSize = true;
            this.teamInfo.Location = new System.Drawing.Point(44, 59);
            this.teamInfo.Name = "teamInfo";
            this.teamInfo.Size = new System.Drawing.Size(51, 13);
            this.teamInfo.TabIndex = 6;
            this.teamInfo.Text = "[unkown]";
            // 
            // serverRegion
            // 
            this.serverRegion.AutoSize = true;
            this.serverRegion.Location = new System.Drawing.Point(49, 46);
            this.serverRegion.Name = "serverRegion";
            this.serverRegion.Size = new System.Drawing.Size(51, 13);
            this.serverRegion.TabIndex = 7;
            this.serverRegion.Text = "[unkown]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 109);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Match Type:";
            // 
            // matchType
            // 
            this.matchType.AutoSize = true;
            this.matchType.Location = new System.Drawing.Point(76, 109);
            this.matchType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.matchType.Name = "matchType";
            this.matchType.Size = new System.Drawing.Size(51, 13);
            this.matchType.TabIndex = 9;
            this.matchType.Text = "[unkown]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mapName);
            this.groupBox1.Controls.Add(this.matchType);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.serverRegion);
            this.groupBox1.Controls.Add(this.teamInfo);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(425, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 131);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Match Information";
            // 
            // mapName
            // 
            this.mapName.AutoSize = true;
            this.mapName.Location = new System.Drawing.Point(39, 20);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(51, 13);
            this.mapName.TabIndex = 10;
            this.mapName.Text = "[unkown]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Rank:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Headshots:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(12, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Kills:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(125, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Longest Kill:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(125, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Distance:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(125, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Damage Dealt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(425, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 63);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // fileLocked
            // 
            this.fileLocked.AutoSize = true;
            this.fileLocked.Enabled = false;
            this.fileLocked.Location = new System.Drawing.Point(15, 153);
            this.fileLocked.Margin = new System.Windows.Forms.Padding(2);
            this.fileLocked.Name = "fileLocked";
            this.fileLocked.Size = new System.Drawing.Size(81, 17);
            this.fileLocked.TabIndex = 0;
            this.fileLocked.Text = "File Locked";
            this.fileLocked.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Time Recorded:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Recording Size:";
            // 
            // timeRecorded
            // 
            this.timeRecorded.AutoSize = true;
            this.timeRecorded.Location = new System.Drawing.Point(92, 24);
            this.timeRecorded.Name = "timeRecorded";
            this.timeRecorded.Size = new System.Drawing.Size(51, 13);
            this.timeRecorded.TabIndex = 3;
            this.timeRecorded.Text = "[unkown]";
            // 
            // recordingSize
            // 
            this.recordingSize.AutoSize = true;
            this.recordingSize.Location = new System.Drawing.Point(91, 37);
            this.recordingSize.Name = "recordingSize";
            this.recordingSize.Size = new System.Drawing.Size(51, 13);
            this.recordingSize.TabIndex = 4;
            this.recordingSize.Text = "[unkown]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Recording Length:";
            // 
            // lengthInMins
            // 
            this.lengthInMins.AutoSize = true;
            this.lengthInMins.Location = new System.Drawing.Point(104, 51);
            this.lengthInMins.Name = "lengthInMins";
            this.lengthInMins.Size = new System.Drawing.Size(51, 13);
            this.lengthInMins.TabIndex = 6;
            this.lengthInMins.Text = "[unkown]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Replay Folder Size:";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(104, 67);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(51, 13);
            this.fileSize.TabIndex = 8;
            this.fileSize.Text = "[unkown]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Network Verison:";
            // 
            // isLive
            // 
            this.isLive.AutoSize = true;
            this.isLive.Enabled = false;
            this.isLive.Location = new System.Drawing.Point(15, 174);
            this.isLive.Margin = new System.Windows.Forms.Padding(2);
            this.isLive.Name = "isLive";
            this.isLive.Size = new System.Drawing.Size(46, 17);
            this.isLive.TabIndex = 10;
            this.isLive.Text = "Live";
            this.isLive.UseVisualStyleBackColor = true;
            // 
            // isIncomplete
            // 
            this.isIncomplete.AutoSize = true;
            this.isIncomplete.Enabled = false;
            this.isIncomplete.Location = new System.Drawing.Point(15, 195);
            this.isIncomplete.Margin = new System.Windows.Forms.Padding(2);
            this.isIncomplete.Name = "isIncomplete";
            this.isIncomplete.Size = new System.Drawing.Size(78, 17);
            this.isIncomplete.TabIndex = 11;
            this.isIncomplete.Text = "Incomplete";
            this.isIncomplete.UseVisualStyleBackColor = true;
            // 
            // IsServerRecording
            // 
            this.IsServerRecording.AutoSize = true;
            this.IsServerRecording.Enabled = false;
            this.IsServerRecording.Location = new System.Drawing.Point(15, 216);
            this.IsServerRecording.Margin = new System.Windows.Forms.Padding(2);
            this.IsServerRecording.Name = "IsServerRecording";
            this.IsServerRecording.Size = new System.Drawing.Size(129, 17);
            this.IsServerRecording.TabIndex = 12;
            this.IsServerRecording.Text = "Is a Server Recording";
            this.IsServerRecording.UseVisualStyleBackColor = true;
            // 
            // networkVerison
            // 
            this.networkVerison.AutoSize = true;
            this.networkVerison.Location = new System.Drawing.Point(92, 97);
            this.networkVerison.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.networkVerison.Name = "networkVerison";
            this.networkVerison.Size = new System.Drawing.Size(51, 13);
            this.networkVerison.TabIndex = 13;
            this.networkVerison.Text = "[unkown]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 82);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Game Version:";
            // 
            // gameVerison
            // 
            this.gameVerison.AutoSize = true;
            this.gameVerison.Location = new System.Drawing.Point(85, 82);
            this.gameVerison.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameVerison.Name = "gameVerison";
            this.gameVerison.Size = new System.Drawing.Size(51, 13);
            this.gameVerison.TabIndex = 15;
            this.gameVerison.Text = "[unkown]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.diedorwon);
            this.groupBox3.Controls.Add(this.profileLink);
            this.groupBox3.Controls.Add(this.recordingUser);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.serverId);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.gameVerison);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.networkVerison);
            this.groupBox3.Controls.Add(this.IsServerRecording);
            this.groupBox3.Controls.Add(this.isIncomplete);
            this.groupBox3.Controls.Add(this.isLive);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.fileSize);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lengthInMins);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.recordingSize);
            this.groupBox3.Controls.Add(this.timeRecorded);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.fileLocked);
            this.groupBox3.Location = new System.Drawing.Point(425, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 266);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File Information";
            // 
            // profileLink
            // 
            this.profileLink.AutoSize = true;
            this.profileLink.Location = new System.Drawing.Point(115, 136);
            this.profileLink.Name = "profileLink";
            this.profileLink.Size = new System.Drawing.Size(57, 13);
            this.profileLink.TabIndex = 21;
            this.profileLink.TabStop = true;
            this.profileLink.Text = "[unknown]";
            this.profileLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.profileLink_LinkClicked);
            // 
            // recordingUser
            // 
            this.recordingUser.AutoSize = true;
            this.recordingUser.Location = new System.Drawing.Point(92, 123);
            this.recordingUser.Name = "recordingUser";
            this.recordingUser.Size = new System.Drawing.Size(57, 13);
            this.recordingUser.TabIndex = 20;
            this.recordingUser.Text = "[unknown]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(107, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Recording User Link:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Recording User:";
            // 
            // serverId
            // 
            this.serverId.AutoSize = true;
            this.serverId.Location = new System.Drawing.Point(63, 110);
            this.serverId.Name = "serverId";
            this.serverId.Size = new System.Drawing.Size(57, 13);
            this.serverId.TabIndex = 17;
            this.serverId.Text = "[unknown]";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 110);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Server ID:";
            // 
            // importReplay
            // 
            this.importReplay.Location = new System.Drawing.Point(558, 608);
            this.importReplay.Name = "importReplay";
            this.importReplay.Size = new System.Drawing.Size(125, 23);
            this.importReplay.TabIndex = 10;
            this.importReplay.Text = "Import a Replay";
            this.importReplay.UseVisualStyleBackColor = true;
            this.importReplay.Click += new System.EventHandler(this.importReplay_Click);
            // 
            // replayListRefresh
            // 
            this.replayListRefresh.Location = new System.Drawing.Point(424, 608);
            this.replayListRefresh.Name = "replayListRefresh";
            this.replayListRefresh.Size = new System.Drawing.Size(128, 23);
            this.replayListRefresh.TabIndex = 11;
            this.replayListRefresh.Text = "Refresh Replay List";
            this.replayListRefresh.UseVisualStyleBackColor = true;
            this.replayListRefresh.Click += new System.EventHandler(this.replayListRefresh_Click);
            // 
            // diedorwon
            // 
            this.diedorwon.AutoSize = true;
            this.diedorwon.Enabled = false;
            this.diedorwon.Location = new System.Drawing.Point(14, 239);
            this.diedorwon.Name = "diedorwon";
            this.diedorwon.Size = new System.Drawing.Size(134, 17);
            this.diedorwon.TabIndex = 22;
            this.diedorwon.Text = "Crashed during replay?";
            this.diedorwon.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 663);
            this.Controls.Add(this.replayListRefresh);
            this.Controls.Add(this.importReplay);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.openReplayFolder);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.replayList);
            this.Name = "Main";
            this.Text = "PUBG Replay Manager";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox replayList;
        private System.Windows.Forms.Button openReplayFolder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button openSelectedReplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label teamInfo;
        private System.Windows.Forms.Label serverRegion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label matchType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox fileLocked;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label timeRecorded;
        private System.Windows.Forms.Label recordingSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lengthInMins;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label fileSize;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox isLive;
        private System.Windows.Forms.CheckBox isIncomplete;
        private System.Windows.Forms.CheckBox IsServerRecording;
        private System.Windows.Forms.Label networkVerison;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label gameVerison;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.Button zipReplay;
        private System.Windows.Forms.Button steamidStrip;
        private System.Windows.Forms.Button importReplay;
        private System.Windows.Forms.Button replayListRefresh;
        private System.Windows.Forms.Label serverId;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel profileLink;
        private System.Windows.Forms.Label recordingUser;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox diedorwon;
    }
}

