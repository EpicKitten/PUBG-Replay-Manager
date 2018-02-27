using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace PUBG_Replay_Manager
{
    public partial class Main : Form
    {
        public string replayloc = Environment.GetEnvironmentVariable("localappdata") + "\\TslGame\\Saved\\Demos";
        public string prog_name = "PUBG Replay Manager";
        public string profile_link = "http://steamcommunity.com/profiles/";
        public string profile_id = "76561198050446061";
        public string currentlyselectedreplaypath = string.Empty;
        public Size orgWindowSize;
        public Size orgGroupSize;
        private TeamMateBlock[] tmBlocks = new TeamMateBlock[8];
        
        public Main()
        {
            InitializeComponent();
            RefreshReplayList();
            InitTeamMatesBlocks();
        }

        private void InitTeamMatesBlocks()
        {
            tmBlocks[0] = new TeamMateBlock
            {
                Group = tm1,
                Headshots = tm1_headshots,
                Headshotslabel = tm1_headshots_l,
                KillerPubgName = tm1_killer_pubgname,
                KillerPubgNameLabel = tm1_killer_pubgname_l,
                KillerSteamId = tm1_killer_steamid,
                KillerSteamIdLabel = tm1_killer_steamid_l,
                Kills = tm1_kills,
                KillsLabel = tm1_kills_l,
                PubgName = tm1_pubgname,
                PubgNameLabel = tm1_pubgname_l,
                SteamId = tm1_steamid,
                SteamIdLabel = tm1_steamid_l,
            };
            
            tmBlocks[1] = new TeamMateBlock
            {
                Group = tm2,
                Headshots = tm2_headshots,
                Headshotslabel = tm2_headshots_l,
                KillerPubgName = tm2_killer_pubgname,
                KillerPubgNameLabel = tm2_killer_pubgname_l,
                KillerSteamId = tm2_killer_steamid,
                KillerSteamIdLabel = tm2_killer_steamid_l,
                Kills = tm2_kills,
                KillsLabel = tm2_kills_l,
                PubgName = tm2_pubgname,
                PubgNameLabel = tm2_pubgname_l,
                SteamId = tm2_steamid,
                SteamIdLabel = tm2_steamid_l,
            };
            
            tmBlocks[2] = new TeamMateBlock
            {
                Group = tm3,
                Headshots = tm3_headshots,
                Headshotslabel = tm3_headshots_l,
                KillerPubgName = tm3_killer_pubgname,
                KillerPubgNameLabel = tm3_killer_pubgname_l,
                KillerSteamId = tm3_killer_steamid,
                KillerSteamIdLabel = tm3_killer_steamid_l,
                Kills = tm3_kills,
                KillsLabel = tm3_kills_l,
                PubgName = tm3_pubgname,
                PubgNameLabel = tm3_pubgname_l,
                SteamId = tm3_steamid,
                SteamIdLabel = tm3_steamid_l,
            };
            
            tmBlocks[3] = new TeamMateBlock
            {
                Group = tm4,
                Headshots = tm4_headshots,
                Headshotslabel = tm4_headshots_l,
                KillerPubgName = tm4_killer_pubgname,
                KillerPubgNameLabel = tm4_killer_pubgname_l,
                KillerSteamId = tm4_killer_steamid,
                KillerSteamIdLabel = tm4_killer_steamid_l,
                Kills = tm4_kills,
                KillsLabel = tm4_kills_l,
                PubgName = tm4_pubgname,
                PubgNameLabel = tm4_pubgname_l,
                SteamId = tm4_steamid,
                SteamIdLabel = tm4_steamid_l,
            };
            
            tmBlocks[4] = new TeamMateBlock
            {
                Group = tm5,
                Headshots = tm5_headshots,
                Headshotslabel = tm5_headshots_l,
                KillerPubgName = tm5_killer_pubgname,
                KillerPubgNameLabel = tm5_killer_pubgname_l,
                KillerSteamId = tm5_killer_steamid,
                KillerSteamIdLabel = tm5_killer_steamid_l,
                Kills = tm5_kills,
                KillsLabel = tm5_kills_l,
                PubgName = tm5_pubgname,
                PubgNameLabel = tm5_pubgname_l,
                SteamId = tm5_steamid,
                SteamIdLabel = tm5_steamid_l,
            };
            
            tmBlocks[5] = new TeamMateBlock
            {
                Group = tm6,
                Headshots = tm6_headshots,
                Headshotslabel = tm6_headshots_l,
                KillerPubgName = tm6_killer_pubgname,
                KillerPubgNameLabel = tm6_killer_pubgname_l,
                KillerSteamId = tm6_killer_steamid,
                KillerSteamIdLabel = tm6_killer_steamid_l,
                Kills = tm6_kills,
                KillsLabel = tm6_kills_l,
                PubgName = tm6_pubgname,
                PubgNameLabel = tm6_pubgname_l,
                SteamId = tm6_steamid,
                SteamIdLabel = tm6_steamid_l,
            };
            
            tmBlocks[6] = new TeamMateBlock
            {
                Group = tm7,
                Headshots = tm7_headshots,
                Headshotslabel = tm7_headshots_l,
                KillerPubgName = tm7_killer_pubgname,
                KillerPubgNameLabel = tm7_killer_pubgname_l,
                KillerSteamId = tm7_killer_steamid,
                KillerSteamIdLabel = tm7_killer_steamid_l,
                Kills = tm7_kills,
                KillsLabel = tm7_kills_l,
                PubgName = tm7_pubgname,
                PubgNameLabel = tm7_pubgname_l,
                SteamId = tm7_steamid,
                SteamIdLabel = tm7_steamid_l,
            };
            
            tmBlocks[7] = new TeamMateBlock
            {
                Group = tm8,
                Headshots = tm8_headshots,
                Headshotslabel = tm8_headshots_l,
                KillerPubgName = tm8_killer_pubgname,
                KillerPubgNameLabel = tm8_killer_pubgname_l,
                KillerSteamId = tm8_killer_steamid,
                KillerSteamIdLabel = tm8_killer_steamid_l,
                Kills = tm8_kills,
                KillsLabel = tm8_kills_l,
                PubgName = tm8_pubgname,
                PubgNameLabel = tm8_pubgname_l,
                SteamId = tm8_steamid,
                SteamIdLabel = tm8_steamid_l,
            };
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            orgWindowSize = Size;
            orgGroupSize = teamGroupBox.Size;
            foreach (Control c in Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
                resources.ApplyResources(c, c.Name, CultureInfo.InstalledUICulture);
            }
        }
        
        public void RefreshReplayList()
        {
            replayGrid.Rows.Clear();
            foreach (DataGridViewRow item in replayGrid.Rows)
            {
                replayGrid.Rows.Remove(item);
            }
            if (Directory.Exists(replayloc))
            {
                List<Replay> replays = new List<Replay>();
                
                foreach (string directory in Directory.GetDirectories(replayloc))
                {
                    if(directory.Contains("match."))
                    {
                        replays.Add(new Replay(directory));
                    }
                }
                
                replays.Sort((x, y) => x.Info.Unixtime.CompareTo(y.Info.Unixtime));
                replays.Reverse();
                
                foreach (Replay replay in replays)
                {
                    replayGrid.Rows.Add(replay.CustomName, FormatRecorderRank(replay.Recorder), FormatGameMode(replay.Info.Mode), FormatGameLength(replay.Info.LengthInMs), replay.Path.Replace(replayloc + "\\", ""));                    
                }
            }
            AmountOfReplays_SB.Text = "Replays: 0/" + replayGrid.Rows.Count;
            replayGrid.Refresh();
        }

        private string FormatRecorderRank(ReplaySummaryPlayer player)
        {
            return player?.Ranking.ToString() ?? "-";
        }

        private string FormatGameMode(GameMode mode)
        {
            return mode.ToString();
        }

        private string FormatGameLength(int length)
        {
            return TimeSpan.FromSeconds(length / 1000).ToString(@"mm\:ss");
        }

        private string FormatReplaySize(double size)
        {
            if (size < 1048576)
            {
                return Math.Truncate(size) + " Bytes";
            }
            else
            {
               size /= 1048576;
               return Math.Truncate(size) + " MB";
            }
        }

        private string FormatFloat(float value)
        {
            return Decimal.Round((decimal) value, 2).ToString();
        }

        private string FormatKillDistance(float value)
        {
            return Decimal.Round(((decimal) value / 100), 2)+" m";
        }
        
        private string FormatMovedDistance(float value)
        {
            if (value > 1000)
            {
                return Decimal.Round(((decimal) value / 1000), 2) + " km";
            }
            else
            {
                return Decimal.Round((decimal) value, 2) + " m";
            }
        }

        private string FormatWeather(string weather)
        {
            switch (weather)
            {
                case "Weather_Clear_02":
                    return "Sunny Clear";
                
                case "Weather_Desert_Sunrise":
                    return "Sunrise";
                
                case "Weather_Desert_Clear":
                case "Weather_Clear":
                    return "Sunny";
                
                case "Weather_Dark":
                    return "Sunset";
                
                default:
                    return weather;
            }
        }

        public void RefreshInfoGroups(Replay replay)
        {
            var killEvents = replay.Events().FindAll(re => re.GetType().Name == "ReplayKillEvent");
            lengthInMins.Text = FormatGameLength(replay.Info.LengthInMs);
            networkVerison.Text = replay.Info.NetworkVersion.ToString();
            matchType.Text = replay.Info.ServerType.ToString();

            if (replay.Info.ServerType == ServerType.Official)
            {
                // TODO Fix game version detection
                gameVerison.Visible = false;
                host.Visible = false;
            }
            else
            {
                gameverisonLabel.Text = "Host:";
                gameVerison.Visible = false;
                host.Visible = true;
                host.Text = replay.Info.CustomHost;
            }

            serverRegion.Text = replay.Summary.Region.ToUpper();
            serverId.Text = replay.Info.ServerId;
            recordingSize.Text = FormatReplaySize(replay.Info.DemoFileLastOffset);
            timeRecorded.Text = replay.Info.CreatedAt.ToLocalTime().ToString();
            isLive.Checked = replay.Info.IsLive;
            isIncomplete.Checked = replay.Info.IsIncomplete;
            IsServerRecording.Checked = replay.Info.IsServerRecording;
            fileLocked.Checked = replay.Info.ShouldKeep;
            teamInfo.Text = replay.Info.Mode.ToString();
            profile_id = replay.Info.RecordUserId;
            recordingUser.Text = replay.Info.RecordUserNickName;
            mapName.Text = replay.Info.MapName.ToString();
            diedorwon.Checked = replay.Info.AllDeadOrWin;
            fileSize.Text = FormatReplaySize(replay.Size());
            weatherType.Text = FormatWeather(replay.Summary.Weather);
            totalPlayers.Text = replay.Summary.PlayersCount.ToString();
            totalTeams.Text = replay.Summary.TeamsCount.ToString();
            rankNum.Text = replay.Recorder.Ranking.ToString();
            headShots.Text = replay.Recorder.HeadShots.ToString();
            kills.Text = replay.Recorder.Kills.ToString();
            dmgHandedOut.Text = FormatFloat(replay.Recorder.TotalGivenDamages);
            longestKill.Text = FormatKillDistance(replay.Recorder.LongestDistanceKill);
            distanceWalked.Text = FormatMovedDistance(replay.Recorder.TotalMovedDistance);

            for (int i = 0; i < 8; i++)
            {
                bool playerHasData = replay.Summary.Players.Length > i;
                
                tmBlocks[i].Group.Visible = playerHasData;
                tmBlocks[i].Headshots.Visible = playerHasData;
                tmBlocks[i].Headshotslabel.Visible = playerHasData;
                tmBlocks[i].KillerPubgName.Visible = playerHasData;
                tmBlocks[i].KillerPubgNameLabel.Visible = playerHasData;
                tmBlocks[i].KillerSteamId.Visible = playerHasData;
                tmBlocks[i].KillerSteamIdLabel.Visible = playerHasData;
                tmBlocks[i].Kills.Visible = playerHasData;
                tmBlocks[i].KillsLabel.Visible = playerHasData;
                tmBlocks[i].PubgName.Visible = playerHasData;
                tmBlocks[i].PubgNameLabel.Visible = playerHasData;
                tmBlocks[i].SteamId.Visible = playerHasData;
                tmBlocks[i].SteamIdLabel.Visible = playerHasData;
                
                if (playerHasData)
                {
                    tmBlocks[i].PubgName.Text = replay.Summary.Players[i].PlayerName;
                    tmBlocks[i].SteamId.Text = replay.Summary.Players[i].PlayerId.ToString();
                    tmBlocks[i].Headshots.Text = replay.Summary.Players[i].HeadShots.ToString();
                    tmBlocks[i].Kills.Text = replay.Summary.Players[i].Kills.ToString();

                    try
                    {
                        ReplayKillEvent killEvent = (ReplayKillEvent) killEvents.First(kill =>
                            ((ReplayKillEvent) kill).VictimId == replay.Summary.Players[i].PlayerId.ToString());
                        tmBlocks[i].KillerPubgName.Text = killEvent.KillerName;
                        tmBlocks[i].KillerSteamId.Text = killEvent.KillerId;
                    }
                    catch (InvalidOperationException e)
                    {
                        tmBlocks[i].KillerPubgName.Text = "[unknown]";
                        tmBlocks[i].KillerSteamId.Text = "[unknown]";
                    }
                }
            }
        }
        
        private void ReplayActionsToggle(bool toggle)
        {
            openSelectedReplay.Enabled = toggle;
            zipReplay.Enabled = toggle;
            steamidStrip.Enabled = toggle;
            deletereplay.Enabled = toggle;
            downkillTimeline.Enabled = toggle;
        }

        private void openReplayFolder_Click(object sender, EventArgs e)
        {
            Process.Start(replayloc+"\\");
        }

        private void openSelectedReplay_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(replayloc + "\\" + currentlyselectedreplaypath))
            {
                Process.Start(replayloc + "\\" + currentlyselectedreplaypath);
            }
            else
            {
                RefreshReplayList();
                openSelectedReplay.Enabled = false;
                zipReplay.Enabled = false;
                steamidStrip.Enabled = false;
                deletereplay.Enabled = false;
                downkillTimeline.Enabled = false;
            }
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
                string startPath = replayloc + "\\" + currentlyselectedreplaypath + "\\";//folder to add
                string zipPath = saveFileDialog1.FileName;//URL for your ZIP file
                ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);
            }
        }

        private void steamidStrip_Click(object sender, EventArgs e)
        {
            SteamID steamid = new SteamID(replayloc + "\\" + currentlyselectedreplaypath + "\\");
            steamid.ShowDialog();
        }

        private void importReplay_Click(object sender, EventArgs e)
        {
            if (replayGrid.Rows.Count >= 20)
            {
                DialogResult aus = MessageBox.Show("Maxmium number of replays in PUBG replay folder has been hit! (20)" + Environment.NewLine + "Adding another will cause PUBG to delete the oldest replay!" + Environment.NewLine + "Are you sure you want to add another?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (aus != DialogResult.Yes)
                {
                    return;
                }
            }
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
            RefreshReplayList();
        }

        private void clearallreplays_Click(object sender, EventArgs e)
        {
            DialogResult aus = MessageBox.Show("This will delete ALL replays in the Replays folder" + Environment.NewLine + "Are you sure you want to delete all replays?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (aus == DialogResult.Yes)
            {
                if (Directory.Exists(replayloc))
                {
                    foreach (string replay in Directory.GetDirectories(replayloc))
                    {
                        if (replay.Contains("match."))
                        {
                            Directory.Delete(replay, true);
                        }
                    }
                }
                MessageBox.Show("All replays deleted!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshReplayList();
            }
        }

        private void deletereplay_Click(object sender, EventArgs e)
        {
            DialogResult aus = MessageBox.Show("This will delete the selected replay" + Environment.NewLine + "Are you sure you want to delete the selected replay?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (aus == DialogResult.Yes)
            {
                if (Directory.Exists(replayloc + "\\" + currentlyselectedreplaypath + "\\"))
                {
                    Directory.Delete(replayloc + "\\" + currentlyselectedreplaypath + "\\", true);
                }
                MessageBox.Show("Selected replay deleted!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshReplayList();
            }
        }

        private void exportallreplays_Click(object sender, EventArgs e)
        {
            DialogResult aus = MessageBox.Show("This will export ALL replays in the Replays folder to a zip file" + Environment.NewLine + "Are you sure you want to export all replays?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (aus == DialogResult.Yes)
            {
                // Displays a SaveFileDialog so the user can save the Image  
                // assigned to Button2.  
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "ZIP File|*.zip";
                saveFileDialog1.Title = "Save a PUBG Replays as a ZIP File...";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    string zipPath = saveFileDialog1.FileName;//URL for your ZIP file
                    if (Directory.Exists(replayloc))
                    {
                        ZipFile.CreateFromDirectory(replayloc, zipPath, CompressionLevel.Fastest, true);
                    }
                }
                MessageBox.Show("All replays saved!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshReplayList();
            }
        }

        private void downkillTimeline_Click(object sender, EventArgs e)
        {
            Timeline timeline = new Timeline(replayloc + "\\" + currentlyselectedreplaypath + "\\");
            timeline.ShowDialog();
        }
        
        private void replayGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    replayGrid[i, e.RowIndex].Selected = true;
                //}
                string selectedreplaydir = (string)replayGrid[4, e.RowIndex].Value;
                if (Directory.Exists(replayloc + "\\" + selectedreplaydir) && e.RowIndex > -1)
                {
                    RefreshInfoGroups(new Replay(replayloc + "\\" + selectedreplaydir));
                    ReplayActionsToggle(true);
                    currentlyselectedreplaypath = selectedreplaydir;
                    AmountOfReplays_SB.Text = "Replays: " + (e.RowIndex + 1) + "/" + replayGrid.Rows.Count;
                }
                else
                {
                    RefreshReplayList();
                    ReplayActionsToggle(false);
                }
            }

        }

        private void replayListRefresh_Click(object sender, EventArgs e)
        {
            RefreshReplayList();
        }

        private void replayGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            Console.WriteLine("CurrentCellChanged fired");
            Console.WriteLine(e.ToString());
            Console.WriteLine(e);
        }

        private void replayGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    //for (int i = 0; i < 5; i++)
            //    //{
            //    //    replayGrid[i, e.RowIndex].Selected = true;
            //    //}
            //    string selectedreplaydir = (string)replayGrid[4, e.RowIndex].Value;
            //    if (Directory.Exists(replayloc + "\\" + selectedreplaydir) && e.RowIndex > -1)
            //    {
            //        RefreshInfoGroups(ReadReplayInfo(replayloc + "\\" + selectedreplaydir));
            //        ReplayActionsToggle(true);
            //        currentlyselectedreplaypath = selectedreplaydir;
            //        AmountOfReplays_SB.Text = "Replays: " + (e.RowIndex + 1) + "/" + replayGrid.Rows.Count;
            //    }
            //    else
            //    {
            //        RefreshReplayList();
            //        ReplayActionsToggle(false);
            //    }
            //}
        }

        private void replayGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("celledit finished");
            Console.WriteLine(replayGrid[e.ColumnIndex,e.RowIndex].Value);
            
            if (e.RowIndex > -1)
            {
                string selectedreplaydir = (string)replayGrid[4, e.RowIndex].Value;
                Replay replay = new Replay(replayloc + "\\" + selectedreplaydir);
                replay.CustomName = replayGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }
    }

    class TeamMateBlock
    {
        public GroupBox Group;
        
        public Label SteamIdLabel;
        public TextBox SteamId;
        
        public Label PubgNameLabel;
        public Label PubgName;
        
        public Label KillerSteamIdLabel;
        public TextBox KillerSteamId;

        public Label KillerPubgNameLabel;
        public Label KillerPubgName;

        public Label KillsLabel;
        public Label Kills;
        
        public Label Headshotslabel;
        public Label Headshots;   
    }
}
