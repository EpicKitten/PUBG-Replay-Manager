using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
//using System.IO.Compression.FileSystem;


namespace PUBG_Replay_Manager
{
    public partial class Main : Form
    {
        public string replayloc = Environment.GetEnvironmentVariable("localappdata") + "\\TslGame\\Saved\\Demos";
        public string prog_name = "PUBG Replay Manager";
        public string profile_link = "http://steamcommunity.com/profiles/";
        public string profile_id = "76561198050446061";
        public Main()
        {
            InitializeComponent();
            RefreshReplayList();
        }
        public void RefreshReplayList()
        {
            replayList.Items.Clear();
            if (Directory.Exists(replayloc))
            {
                foreach (string replay in Directory.GetDirectories(replayloc))
                {
                    if(replay.Contains("match."))
                    {
                        replayList.Items.Add(replay.Replace(replayloc + "\\", ""));
                    }
                }
            }
            replayList.Refresh();
        }
        public void RefreshInfoGroups(string[] newInfo)
        {
            lengthInMins.Text = newInfo[0];
            networkVerison.Text = newInfo[1];
            matchType.Text = newInfo[4];
            gameVerison.Text = newInfo[5];
            serverRegion.Text = newInfo[6];
            recordingSize.Text = newInfo[10];
            timeRecorded.Text = newInfo[12];
            if (newInfo[13] == "false")
            {
                isLive.Checked = false;
            }
            if (newInfo[13] == "true")
            {
                isLive.Checked = true;
            }
            if (newInfo[14] == "false")
            {
                isIncomplete.Checked = false;
            }
            if (newInfo[14] == "true")
            {
                isIncomplete.Checked = true;
            }
            if (newInfo[15] == "false")
            {
                IsServerRecording.Checked = false;
            }
            if (newInfo[15] == "true")
            {
                IsServerRecording.Checked = true;
            }
            if (newInfo[16] == "false")
            {
                fileLocked.Checked = false;
            }
            if (newInfo[16] == "true")
            {
                fileLocked.Checked = true;
            }
            teamInfo.Text = newInfo[17];
            profile_id = newInfo[18];
            recordingUser.Text = newInfo[19];
            profileLink.Text = newInfo[19];
            mapName.Text = newInfo[20];
            fileSize.Text = newInfo[21];
            serverId.Text = newInfo[22];
        }

        private void replayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(replayloc+ "\\" + replayList.SelectedItem))
            {
                RefreshInfoGroups(ReadReplayInfo(replayloc + "\\" + replayList.SelectedItem));
                openSelectedReplay.Enabled = true;
                zipReplay.Enabled = true;
                steamidStrip.Enabled = true;
            }
            else
            {
                RefreshReplayList();
                openSelectedReplay.Enabled = false;
                zipReplay.Enabled = false;
                steamidStrip.Enabled = false;
            }
        }

        private void openReplayFolder_Click(object sender, EventArgs e)
        {
            Process.Start(replayloc+"\\");
        }

        private void openSelectedReplay_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(replayloc + "\\" + replayList.SelectedItem))
            {
                Process.Start(replayloc + "\\" + replayList.SelectedItem);
            }
            else
            {
                RefreshReplayList();
                openSelectedReplay.Enabled = false;
                zipReplay.Enabled = false;
                steamidStrip.Enabled = false;
            }
        }
        private string[] ReadReplayInfo(string directory_of_recording)
        {
            string[] placeholder = { "0", "0", "0", "0", "[unknown]", "[unknown]", "[unknown]", "[unknown]", "[unknown]", "[unknown]", "0", "0", "[unknown]", "false", "true", "false", "false", "[unknown]", "[unknown]", "[unknown]", "[unknown]", "[unknown]", "[unknown]" };
            if (File.Exists(directory_of_recording + "\\PUBG.replayinfo"))
            {
                Console.WriteLine("===========================================================================");
                string[] ReplayInfoFile = File.ReadAllLines(directory_of_recording + "\\PUBG.replayinfo");
                string[] info = {
                    "LengthInMS", //Length of the recording in miliseconds
                    "NetworkVersion", //??????
                    "Changelist", //??????
                    "FriendlyName", //String with lots of match info
                    "MatchType",//(Derived from FriendlyName) offical or ??????? (possibly custom)
                    "UpdateType",//(Derived from FriendlyName) 2018-01, 2017-pre6, 2017-test
                    "ServerLocation",//(Derived from FriendlyName) NA or ?????????
                    "TeamType",//(Derived from FriendlyName) unused in favor of mode, squad or solo or ????
                    "DateRecorded",//(Derived from FriendlyName) unused in favor of TimeStamp
                    "UUID",//(Derived from FriendlyName) Some kind of uuid? maybe for looking up matchs? Unsure.
                    "DemoFileLastOffset", //[more likely this one]File size of the recording (in bytes) or time between recordings
                    "SizeInBytes",//?????? its always 0
                    "TimeStamp",//Unix Time (in Miliseconds)
                    "bIsLive",//LiveStreaming detection?
                    "bIncomplete",//Detection for corrupt files?
                    "bIsServerRecording", //Heavy possibly the server also records a copy of the entire match
                    "bShouldKeep",//True = Pubg won't delete the file for a new one and it prevents the user from deleting it to
                    "Mode",//Solo or Sqaud
                    "RecordUserId", //The recording user (SteamID 64)
                    "RecordUserNickname", //The recording user (In-Game Username)
                    "MapName", //name of the map (Desert_Main or Erangel_Main)
                    "FolderSize", //Size of the Replay Folder
                    "ServerID", //the server id 
                }; 

                //--------------------------------------------------
                //-------------------Length in Ms ------------------
                //--------------------------------------------------
                string lengthflag = ReplayInfoFile[1].Remove(0, 15);
                lengthflag = lengthflag.Remove(lengthflag.Length - 1, 1);
                int length = 0;
                if(!int.TryParse(lengthflag, out length))
                {
                    MessageBox.Show("Unable to parse LengthInMS!" + Environment.NewLine + prog_name + " will now exit!", "Serious Error!");
                    Environment.Exit(-1);
                }
                if (length < 60000)
                {
                    length /= 1000; //miliseconds to seconds
                    info[0] = length.ToString() + " Secs";
                }
                else
                {
                    length /= 60000; //miliseconds to mintues
                    info[0] = length.ToString() + " Mins";
                }
                //--------------------------------------------------
                //-------------------Network Version----------------
                //--------------------------------------------------
                string networkverflag = ReplayInfoFile[2].Remove(0, 19);
                networkverflag = networkverflag.Remove(networkverflag.Length - 1, 1);
                info[1] = networkverflag;
                //--------------------------------------------------
                //-------------------Changelist---------------------
                //--------------------------------------------------
                string changelistflag = ReplayInfoFile[3].Remove(0, 15);
                changelistflag = changelistflag.Remove(changelistflag.Length - 1, 1);
                info[2] = changelistflag;
                //--------------------------------------------------
                //-------------------FriendlyName-------------------
                //--------------------------------------------------
                string FriendlyNameflag = ReplayInfoFile[4].Remove(0, 18);
                FriendlyNameflag = FriendlyNameflag.Remove(FriendlyNameflag.Length - 2, 2);
                string[] temp = FriendlyNameflag.Split('.');
                info[3] = FriendlyNameflag; //match.bro.official.2017 - test.na.squad.2017.12.05.470ec7f1 - c342 - 46ad - 81c9 - e9117f27b44a
                if (temp[2]=="official")
                {
                    info[4] = "Official";//official
                }
                if (temp[2] == "custom")
                {
                    info[4] = "Custom";//official
                }
                info[5] = temp[3]; //2017-test
                info[6] = temp[4].ToUpper(); //na
                info[7] = temp[5]; //sqaud
                info[8] = temp[6] + "-" + temp[7] + "-" + temp[8]; //2017.12.05
                info[9] = temp[9]; //470ec7f1-c342-46ad-81c9-e9117f27b44a
                info[22] = temp[9].Remove(0, 30); //27b44a

                //--------------------------------------------------
                //-------------------DemoFileLastOffset-------------
                //--------------------------------------------------
                string DemoFileLastOffsetflag = ReplayInfoFile[5].Remove(0, 23);
                DemoFileLastOffsetflag = DemoFileLastOffsetflag.Remove(DemoFileLastOffsetflag.Length - 1, 1);
                int size = 0;
                if (!int.TryParse(DemoFileLastOffsetflag, out size))
                {
                    MessageBox.Show("Unable to parse DemoFileLastOffset!" + Environment.NewLine + prog_name + " will now exit!", "Serious Error!");
                    Environment.Exit(-1);
                }
                if (size > 1000000)
                {
                    size /= 1000000;
                    info[10] = size.ToString() + " MB";
                }
                else
                {
                    info[10] = size.ToString() + " Bytes";
                }
                //--------------------------------------------------
                //-------------------SizeInBytes--------------------
                //--------------------------------------------------
                string SizeInBytesflag = ReplayInfoFile[6].Remove(0, 16);
                SizeInBytesflag = SizeInBytesflag.Remove(SizeInBytesflag.Length - 1, 1);
                info[11] = SizeInBytesflag;
                //--------------------------------------------------
                //-------------------TimeStamp----------------------
                //--------------------------------------------------
                string timecreateflag = ReplayInfoFile[7].Remove(0, 14);
                timecreateflag = timecreateflag.Remove(timecreateflag.Length - 1, 1);
                double time = 0;
                if (!double.TryParse(timecreateflag, out time))
                {
                    MessageBox.Show("Unable to parse TimeStamp!" + Environment.NewLine + prog_name + " will now exit!", "Serious Error!");
                    Environment.Exit(-1);
                }
                double timestamp = time;
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddMilliseconds(timestamp).ToLocalTime();
                info[12] = dateTime.ToString();
                //--------------------------------------------------
                //-------------------isLive-------------------------
                //--------------------------------------------------
                string isliveflag = ReplayInfoFile[8].Remove(0, 12);
                isliveflag = isliveflag.Remove(isliveflag.Length - 1, 1);
                info[13] = isliveflag;
                //--------------------------------------------------
                //-------------------Incomplete---------------------
                //--------------------------------------------------
                string incompleteflag = ReplayInfoFile[9].Remove(0, 16);
                incompleteflag = incompleteflag.Remove(incompleteflag.Length - 1, 1);
                info[14] = incompleteflag;
                //--------------------------------------------------
                //-------------------InServerRecording--------------
                //--------------------------------------------------
                string InServerRecordingflag = ReplayInfoFile[10].Remove(0, 23);
                InServerRecordingflag = InServerRecordingflag.Remove(InServerRecordingflag.Length - 1, 1);
                info[15] = InServerRecordingflag;
                //--------------------------------------------------
                //--------------------Keep--------------------------
                //--------------------------------------------------
                string keepflag = ReplayInfoFile[11].Remove(0, 16);
                keepflag = keepflag.Remove(keepflag.Length - 1, 1);
                info[16] = keepflag;
                //--------------------------------------------------
                //--------------------Mode--------------------------
                //--------------------------------------------------
                string modeflag = ReplayInfoFile[12].Remove(0, 10);
                modeflag = modeflag.Remove(modeflag.Length - 2, 2);
                if (modeflag == "solo")
                {
                    info[17] = "Solo";
                }
                else
                {
                    info[17] = "Sqaud";
                }
                //--------------------------------------------------
                //--------------------RecordUserId------------------
                //--------------------------------------------------
                string RecordUserIDflag = ReplayInfoFile[13].Remove(0, 18);
                RecordUserIDflag = RecordUserIDflag.Remove(RecordUserIDflag.Length - 2, 2);
                info[18] = RecordUserIDflag;
                //--------------------------------------------------
                //--------------------RecordUserNickName------------------
                //--------------------------------------------------
                string RecordUserNickNameflag = ReplayInfoFile[14].Remove(0, 24);
                RecordUserNickNameflag = RecordUserNickNameflag.Remove(RecordUserNickNameflag.Length - 2, 2);
                info[19] = RecordUserNickNameflag;
                //--------------------------------------------------
                //--------------------MapName------------------
                //--------------------------------------------------
                string MapNameflag = ReplayInfoFile[15].Remove(0, 13);
                MapNameflag = MapNameflag.Remove(MapNameflag.Length - 2, 2);
                if (MapNameflag == "Erangel_Main")
                {
                    info[20] = "Erangel";
                }
                else
                {
                    info[20] = "Miramar";
                }
                foreach(string obj in info)
                {
                    Console.WriteLine(obj);
                }
                //--------------------------------------------------
                //--------------------FolderSize--------------------
                //--------------------------------------------------
                double dirsize = GetDirectorySize(replayloc + "\\" + replayList.SelectedItem + "\\");
                //Console.WriteLine(GetDirectorySize(replayloc + "\\" + replayList.SelectedItem + "\\"));
                if (dirsize < 1048576)
                {
                    info[21] = Math.Truncate(dirsize).ToString() + " Bytes";
                }
                else
                {
                    dirsize /= 1048576;
                    info[21] = Math.Truncate(dirsize).ToString() + " MB";
                }
                return info;
            }
            MessageBox.Show("PUBG.replayinfo for this recording was not found!" + Environment.NewLine + "Recording may be corrupt!", "Waring!");
            return placeholder;
        }

        private void zipReplay_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "ZIP File|*.zip";
            saveFileDialog1.Title = "Save a PUBG Replay as a ZIP File...";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                string startPath = replayloc + "\\" + replayList.SelectedItem + "\\";//folder to add
                string zipPath = saveFileDialog1.FileName;//URL for your ZIP file
                ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);
            }
        }
        private double GetDirectorySize(string directory)
        {
            double foldersize = 0;
            foreach (string dir in Directory.GetDirectories(directory))
            {
                GetDirectorySize(dir);
            }

            foreach (FileInfo file in new DirectoryInfo(directory).GetFiles())
            {
                foldersize += file.Length;
            }

            return foldersize;
        }

        private void steamidStrip_Click(object sender, EventArgs e)
        {
            SteamID steamid = new SteamID(replayloc + "\\" + replayList.SelectedItem + "\\");
            steamid.ShowDialog();
        }

        private void importReplay_Click(object sender, EventArgs e)
        {
            OpenFileDialog importReplayDialog = new OpenFileDialog();
            importReplayDialog.Filter = "ZIP Files|*.zip";
            importReplayDialog.Title = "Select a PUBG Replay in a ZIP File...";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (importReplayDialog.ShowDialog() == DialogResult.OK)
            {
                ZipFile.ExtractToDirectory(importReplayDialog.FileName, replayloc);
                MessageBox.Show("Success!", "Imported Replay!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // Assign the cursor in the Stream to the Form's Cursor property.  
                //this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        private void replayListRefresh_Click(object sender, EventArgs e)
        {
            RefreshReplayList();
        }

        private void killFileDecoder_Click(object sender, EventArgs e)
        {
            KillFeed steamid = new KillFeed(replayloc + "\\" + replayList.SelectedItem + "\\");
            steamid.ShowDialog();
        }

        private void profileLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/profiles/"+profile_id);
        }
    }
}
