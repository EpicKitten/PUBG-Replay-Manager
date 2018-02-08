using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing;

namespace PUBG_Replay_Manager
{
    public partial class Main : Form
    {
        public string replayloc = Environment.GetEnvironmentVariable("localappdata") + "\\TslGame\\Saved\\Demos";
        public string prog_name = "PUBG Replay Manager";
        public string profile_link = "http://steamcommunity.com/profiles/";
        public string profile_id = "76561198050446061";
        public Size orgWindowSize;
        public Size orgGroupSize;
        public Main()
        {
            InitializeComponent();
            RefreshReplayList();            
        }
        private void Main_Load(object sender, EventArgs e)
        {
            orgWindowSize = Size;
            orgGroupSize = teamGroupBox.Size;
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
            AmountOfReplays_SB.Text = "Replays: 0/" + replayList.Items.Count;
            replayList.Refresh();
        }
        public void RefreshInfoGroups(ArrayList newInfo)
        {
            Size orgWinSize = orgWindowSize;
            Size orgTeamSize = orgGroupSize;
            
            
            lengthInMins.Text = (string)newInfo[1];
            networkVerison.Text = newInfo[2].ToString();
            matchType.Text = (string)newInfo[6];
            if (!newInfo[7].ToString().Contains("-") && newInfo[7].ToString().Length != 7)
            {
                gameverisonLabel.Text = "Host:";
                gameVerison.Visible = false;
                host.Visible = true;
                host.Text = (string)newInfo[7];
            }
            else
            {
                gameVerison.Text = (string)newInfo[7];
                gameverisonLabel.Text = "Game Verison:";
                gameVerison.Visible = true;
                host.Visible = false;
            }
            serverRegion.Text = (string)newInfo[9];
            serverId.Text = (string)newInfo[13];
            recordingSize.Text = (string)newInfo[15];
            timeRecorded.Text = (string)newInfo[19];
            isLive.Checked = (bool)newInfo[20];
            isIncomplete.Checked = (bool)newInfo[21];
            IsServerRecording.Checked = (bool)newInfo[22];
            fileLocked.Checked = (bool)newInfo[23];
            teamInfo.Text = (string)newInfo[25];
            profile_id = (string)newInfo[26];
            recordingUser.Text = (string)newInfo[27];
            mapName.Text = (string)newInfo[29];
            diedorwon.Checked = (bool)newInfo[30];
            fileSize.Text = (string)newInfo[31];
            weatherType.Text = (string)newInfo[32];
            totalPlayers.Text = newInfo[33].ToString();
            totalTeams.Text = newInfo[34].ToString();
            rankNum.Text = newInfo[38].ToString();
            for (int i = 0; i < newInfo.Count; i++)
            {
                Console.WriteLine("n " + i + " | " + newInfo[i]);
            }
            for (int i = 35; i < newInfo.Count; i++)
            {
                Console.WriteLine("Checking " + i);
                if (newInfo[i].ToString() == newInfo[27].ToString())
                {
                    headShots.Text = newInfo[i + 3].ToString();
                    kills.Text = newInfo[i + 4].ToString();
                    dmgHandedOut.Text = newInfo[i + 6].ToString();
                    longestKill.Text = newInfo[i + 8].ToString();
                    distanceWalked.Text = newInfo[i + 10].ToString();
                    break;

                }
            }
            //-----------------------------------------------------------------------
            //---------------------TeamMates-----------------------------------------
            //-----------------------------------------------------------------------
            int z = 0;
            for (int i = 35; i < newInfo.Count; i++)
            {
                Console.WriteLine("Checking " + i);
                //if (newInfo[i].ToString().Contains("765611") && !(newInfo[i + 1].ToString().Contains("765611") || newInfo[i + 1].ToString().Contains("unknown")))
                if (newInfo[i].ToString().Contains("765611"))
                {
                    Console.WriteLine("Line " + i + " has one!");
                    z++;
                    if (z == 1)
                    {
                        tm1.Visible = true;
                        tm1_pubgname.Visible = true;
                        tm1_steamid.Visible = true;
                        tm1_headshots.Visible = true;
                        tm1_kills.Visible = true;
                        tm1_pubgname_l.Visible = true;
                        tm1_steamid_l.Visible = true;
                        tm1_headshots_l.Visible = true;
                        tm1_kills_l.Visible = true;
                        tm1_killer_pubgname.Visible = true;
                        tm1_killer_pubgname_l.Visible = true;
                        tm1_killer_steamid.Visible = true;
                        tm1_killer_steamid_l.Visible = true;
                        tm1_pubgname.Text = newInfo[i + 1].ToString();
                        tm1_steamid.Text = newInfo[i].ToString();
                        tm1_headshots.Text = newInfo[i + 4].ToString();
                        tm1_kills.Text = newInfo[i + 5].ToString();
                        //tm1_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm1_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 1)
                    {
                        tm1.Visible = false;
                        tm1_pubgname.Visible = false;
                        tm1_steamid.Visible = false;
                        tm1_headshots.Visible = false;
                        tm1_kills.Visible = false;
                        tm1_pubgname_l.Visible = false;
                        tm1_steamid_l.Visible = false;
                        tm1_headshots_l.Visible = false;
                        tm1_kills_l.Visible = false;
                        tm1_killer_pubgname.Visible = false;
                        tm1_killer_pubgname_l.Visible = false;
                        tm1_killer_steamid.Visible = false;
                        tm1_killer_steamid_l.Visible = false;
                    }
                    if (z == 2)
                    {
                        tm2.Visible = true;
                        tm2_pubgname.Visible = true;
                        tm2_steamid.Visible = true;
                        tm2_headshots.Visible = true;
                        tm2_kills.Visible = true;
                        tm2_pubgname_l.Visible = true;
                        tm2_steamid_l.Visible = true;
                        tm2_headshots_l.Visible = true;
                        tm2_kills_l.Visible = true;
                        tm2_killer_pubgname.Visible = true;
                        tm2_killer_pubgname_l.Visible = true;
                        tm2_killer_steamid.Visible = true;
                        tm2_killer_steamid_l.Visible = true;
                        tm2_pubgname.Text = newInfo[i + 1].ToString();
                        tm2_steamid.Text = newInfo[i].ToString();
                        tm2_headshots.Text = newInfo[i + 4].ToString();
                        tm2_kills.Text = newInfo[i + 5].ToString();
                        //tm2_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm2_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 2)
                    {
                        tm2.Visible = false;
                        tm2_pubgname.Visible = false;
                        tm2_steamid.Visible = false;
                        tm2_headshots.Visible = false;
                        tm2_kills.Visible = false;
                        tm2_pubgname_l.Visible = false;
                        tm2_steamid_l.Visible = false;
                        tm2_headshots_l.Visible = false;
                        tm2_kills_l.Visible = false;
                        tm2_killer_pubgname.Visible = false;
                        tm2_killer_pubgname_l.Visible = false;
                        tm2_killer_steamid.Visible = false;
                        tm2_killer_steamid_l.Visible = false;
                    }
                    if (z == 3)
                    {
                        tm3.Visible = true;
                        tm3_pubgname.Visible = true;
                        tm3_steamid.Visible = true;
                        tm3_headshots.Visible = true;
                        tm3_kills.Visible = true;
                        tm3_pubgname_l.Visible = true;
                        tm3_steamid_l.Visible = true;
                        tm3_headshots_l.Visible = true;
                        tm3_kills_l.Visible = true;
                        tm3_killer_pubgname.Visible = true;
                        tm3_killer_pubgname_l.Visible = true;
                        tm3_killer_steamid.Visible = true;
                        tm3_killer_steamid_l.Visible = true;
                        tm3_pubgname.Text = newInfo[i + 1].ToString();
                        tm3_steamid.Text = newInfo[i].ToString();
                        tm3_headshots.Text = newInfo[i + 4].ToString();
                        tm3_kills.Text = newInfo[i + 5].ToString();
                        //tm3_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm3_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 3)
                    {
                        tm3.Visible = false;
                        tm3_pubgname.Visible = false;
                        tm3_steamid.Visible = false;
                        tm3_headshots.Visible = false;
                        tm3_kills.Visible = false;
                        tm3_pubgname_l.Visible = false;
                        tm3_steamid_l.Visible = false;
                        tm3_headshots_l.Visible = false;
                        tm3_kills_l.Visible = false;
                        tm3_killer_pubgname.Visible = false;
                        tm3_killer_pubgname_l.Visible = false;
                        tm3_killer_steamid.Visible = false;
                        tm3_killer_steamid_l.Visible = false;
                    }
                    if (z == 4)
                    {
                        tm4.Visible = true;
                        tm4_pubgname.Visible = true;
                        tm4_steamid.Visible = true;
                        tm4_headshots.Visible = true;
                        tm4_kills.Visible = true;
                        tm4_pubgname_l.Visible = true;
                        tm4_steamid_l.Visible = true;
                        tm4_headshots_l.Visible = true;
                        tm4_kills_l.Visible = true;
                        tm4_killer_pubgname.Visible = true;
                        tm4_killer_pubgname_l.Visible = true;
                        tm4_killer_steamid.Visible = true;
                        tm4_killer_steamid_l.Visible = true;
                        tm4_pubgname.Text = newInfo[i + 1].ToString();
                        tm4_steamid.Text = newInfo[i].ToString();
                        tm4_headshots.Text = newInfo[i + 4].ToString();
                        tm4_kills.Text = newInfo[i + 5].ToString();
                        //tm4_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm4_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 4)
                    {
                        tm4.Visible = false;
                        tm4_pubgname.Visible = false;
                        tm4_steamid.Visible = false;
                        tm4_headshots.Visible = false;
                        tm4_kills.Visible = false;
                        tm4_pubgname_l.Visible = false;
                        tm4_steamid_l.Visible = false;
                        tm4_headshots_l.Visible = false;
                        tm4_kills_l.Visible = false;
                        tm4_killer_pubgname.Visible = false;
                        tm4_killer_pubgname_l.Visible = false;
                        tm4_killer_steamid.Visible = false;
                        tm4_killer_steamid_l.Visible = false;
                    }
                    if (z == 5)
                    {
                        //Size = orgWindowSize;
                        //teamGroupBox.Size = orgGroupSize;
                        //orgWindowSize = Size;
                        //orgGroupSize = teamGroupBox.Size;
                        //Size = new Size(1187, 756); //Pops the right side out to show more teammates (up to 8)
                        //teamGroupBox.Size = new Size(469, 674); //Pops the team group box out to show more teammates (up to 8)
                        tm5.Visible = true;
                        tm5_pubgname.Visible = true;
                        tm5_steamid.Visible = true;
                        tm5_headshots.Visible = true;
                        tm5_kills.Visible = true;
                        tm5_pubgname_l.Visible = true;
                        tm5_steamid_l.Visible = true;
                        tm5_headshots_l.Visible = true;
                        tm5_kills_l.Visible = true;
                        tm5_killer_pubgname.Visible = true;
                        tm5_killer_pubgname_l.Visible = true;
                        tm5_killer_steamid.Visible = true;
                        tm5_killer_steamid_l.Visible = true;
                        tm5_pubgname.Text = newInfo[i + 1].ToString();
                        tm5_steamid.Text = newInfo[i].ToString();
                        tm5_headshots.Text = newInfo[i + 4].ToString();
                        tm5_kills.Text = newInfo[i + 5].ToString();
                    }
                    else if (z < 5)
                    {
                        //Size = new Size(orgWindowSize.Height, orgWindowSize.Width + 226);
                        //teamGroupBox.Size = new Size(orgGroupSize.Height + 232, orgGroupSize.Width);
                        //Size = new Size(961, 756); //returns it to normal
                        //teamGroupBox.Size = new Size(237, 674); //returns it to normal
                        tm5.Visible = false;
                        tm5_pubgname.Visible = false;
                        tm5_steamid.Visible = false;
                        tm5_headshots.Visible = false;
                        tm5_kills.Visible = false;
                        tm5_pubgname_l.Visible = false;
                        tm5_steamid_l.Visible = false;
                        tm5_headshots_l.Visible = false;
                        tm5_kills_l.Visible = false;
                        tm5_killer_steamid.Visible = false;
                        tm5_killer_pubgname_l.Visible = false;
                        tm5_killer_steamid.Visible = false;
                        tm5_killer_steamid_l.Visible = false;
                    }
                    if (z == 6)
                    {
                        tm6.Visible = true;
                        tm6_pubgname.Visible = true;
                        tm6_steamid.Visible = true;
                        tm6_headshots.Visible = true;
                        tm6_kills.Visible = true;
                        tm6_pubgname_l.Visible = true;
                        tm6_steamid_l.Visible = true;
                        tm6_headshots_l.Visible = true;
                        tm6_kills_l.Visible = true;
                        tm6_killer_pubgname.Visible = true;
                        tm6_killer_pubgname_l.Visible = true;
                        tm6_killer_steamid.Visible = true;
                        tm6_killer_steamid_l.Visible = true;
                        tm6_pubgname.Text = newInfo[i + 1].ToString();
                        tm6_steamid.Text = newInfo[i].ToString();
                        tm6_headshots.Text = newInfo[i + 4].ToString();
                        tm6_kills.Text = newInfo[i + 5].ToString();
                        //tm6_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm6_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 6)
                    {
                        tm6.Visible = false;
                        tm6_pubgname.Visible = false;
                        tm6_steamid.Visible = false;
                        tm6_headshots.Visible = false;
                        tm6_kills.Visible = false;
                        tm6_pubgname_l.Visible = false;
                        tm6_steamid_l.Visible = false;
                        tm6_headshots_l.Visible = false;
                        tm6_kills_l.Visible = false;
                        tm6_killer_pubgname.Visible = false;
                        tm6_killer_pubgname_l.Visible = false;
                        tm6_killer_steamid.Visible = false;
                        tm6_killer_steamid_l.Visible = false;
                    }
                    if (z == 7)
                    {
                        tm7.Visible = true;
                        tm7_pubgname.Visible = true;
                        tm7_steamid.Visible = true;
                        tm7_headshots.Visible = true;
                        tm7_kills.Visible = true;
                        tm7_pubgname_l.Visible = true;
                        tm7_steamid_l.Visible = true;
                        tm7_headshots_l.Visible = true;
                        tm7_kills_l.Visible = true;
                        tm7_killer_pubgname.Visible = true;
                        tm7_killer_pubgname_l.Visible = true;
                        tm7_killer_steamid.Visible = true;
                        tm7_killer_steamid_l.Visible = true;
                        tm7_pubgname.Text = newInfo[i + 1].ToString();
                        tm7_steamid.Text = newInfo[i].ToString();
                        tm7_headshots.Text = newInfo[i + 4].ToString();
                        tm7_kills.Text = newInfo[i + 5].ToString();
                        //tm7_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm7_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 7)
                    {
                        tm7.Visible = false;
                        tm7_pubgname.Visible = false;
                        tm7_steamid.Visible = false;
                        tm7_headshots.Visible = false;
                        tm7_kills.Visible = false;
                        tm7_pubgname_l.Visible = false;
                        tm7_steamid_l.Visible = false;
                        tm7_headshots_l.Visible = false;
                        tm7_kills_l.Visible = false;
                        tm7_killer_pubgname.Visible = false;
                        tm7_killer_pubgname_l.Visible = false;
                        tm7_killer_steamid.Visible = false;
                        tm7_killer_steamid_l.Visible = false;
                    }
                    if (z == 8)
                    {
                        tm8.Visible = true;
                        tm8_pubgname.Visible = true;
                        tm8_steamid.Visible = true;
                        tm8_headshots.Visible = true;
                        tm8_kills.Visible = true;
                        tm8_pubgname_l.Visible = true;
                        tm8_steamid_l.Visible = true;
                        tm8_headshots_l.Visible = true;
                        tm8_kills_l.Visible = true;
                        tm8_killer_pubgname.Visible = true;
                        tm8_killer_pubgname_l.Visible = true;
                        tm8_killer_steamid.Visible = true;
                        tm8_killer_steamid_l.Visible = true;
                        tm8_pubgname.Text = newInfo[i + 1].ToString();
                        tm8_steamid.Text = newInfo[i].ToString();
                        tm8_headshots.Text = newInfo[i + 4].ToString();
                        tm8_kills.Text = newInfo[i + 5].ToString();
                        //tm8_killer_pubgname.Text = newInfo[i + 12].ToString();
                        //tm8_killer_steamid.Text = newInfo[i + 13].ToString();
                    }
                    else if (z < 8)
                    {
                        tm8.Visible = false;
                        tm8_pubgname.Visible = false;
                        tm8_steamid.Visible = false;
                        tm8_headshots.Visible = false;
                        tm8_kills.Visible = false;
                        tm8_pubgname_l.Visible = false;
                        tm8_steamid_l.Visible = false;
                        tm8_headshots_l.Visible = false;
                        tm8_kills_l.Visible = false;
                        tm8_killer_pubgname.Visible = false;
                        tm8_killer_pubgname_l.Visible = false;
                        tm8_killer_steamid.Visible = false;
                        tm8_killer_steamid_l.Visible = false;
                    }
                }
            }
            Console.WriteLine(z + " Players");
            z = 0;
            
        }

        private void replayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(replayloc+ "\\" + replayList.SelectedItem) && replayList.SelectedIndex > -1)
            {
                RefreshInfoGroups(ReadReplayInfo(replayloc + "\\" + replayList.SelectedItem));
                openSelectedReplay.Enabled = true;
                zipReplay.Enabled = true;
                steamidStrip.Enabled = true;
                deletereplay.Enabled = true;
                AmountOfReplays_SB.Text = "Replays: " + (replayList.SelectedIndex + 1) + "/" + replayList.Items.Count;
            }
            else
            {
                RefreshReplayList();
                openSelectedReplay.Enabled = false;
                zipReplay.Enabled = false;
                steamidStrip.Enabled = false;
                deletereplay.Enabled = false;
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
                deletereplay.Enabled = false;
            }
        }
        static string UE4StringSerializer(string file_path, bool encoded = false, int encoded_offset = 0)
        {
            byte[] little_endian_length = new byte[4];//a 4 length byte array used later
            byte[] file = File.ReadAllBytes(file_path);//The file into a byte array
            for (int i = 0; i < 4; i++)//For the next 4 bytes...
            {
                little_endian_length[i] = file[i];//...Add them to the little_endian_length
            }
            int bytestoread = BitConverter.ToInt32(little_endian_length, 0);//Convert this into a int to tell the program how many bytes to read
            byte[] readspace = new byte[bytestoread];//use bytestoread to expand the array to what we're about to read
            using (BinaryReader reader = new BinaryReader(new FileStream(file_path, FileMode.Open)))
            {
                reader.BaseStream.Seek(4, SeekOrigin.Begin);//Set the base of where to start reading 4 bytes ahead of the file (essenially skipping the little-endian unsigned 32-bit integer)
                reader.Read(readspace, 0, bytestoread);//Read the space that the little_endian_length told us to read
            }
            List<byte> unencodedbytes = new List<byte>();//Make a list so we can dynamically add things to it 
            foreach (byte encodedbyte in readspace)//For each byte in the readspace of what we just read from the file
            {
                if (!encodedbyte.Equals(0))//if the byte is zero (techinally should only be handled at the end per numinit (https://github.com/numinit)'s specifications but I'm lazy
                {
                    if (encoded)//Did the user specificity that its encoded?
                    {
                        unencodedbytes.Add((byte)(encodedbyte + encoded_offset));// Yes! Add the encoded offset to the byte, cast it to a byte and add it to the list
                    }
                    else
                    {
                        unencodedbytes.Add(encodedbyte);//No! Just add the byte to the array
                    }
                }
            }
            Console.WriteLine(Encoding.UTF8.GetString(readspace));
            Console.WriteLine(Encoding.UTF8.GetString(unencodedbytes.ToArray()));
            return Encoding.UTF8.GetString(unencodedbytes.ToArray());//take all the bytes, make the list a array, put the array into UTF8 encoding and return it
        }
        private JObject DecryptReplaySummaryFile(string directory_of_recording)
        {
            List<string> replaySummaryList = new List<string>();
            foreach (string replay in Directory.GetFiles(directory_of_recording + "\\data"))
            {
                if (replay.Contains("ReplaySummary"))
                {
                    replaySummaryList.Add(replay);
                }
            }
            replaySummaryList.Reverse();
            return JObject.Parse(UE4StringSerializer(replaySummaryList.ToArray()[0], true, 1));
        }
        //private JObject DecryptDBNOorKillFile(string path_to_file)
        //{
        //    return JObject.Parse(CaesarCipher(File.ReadAllText(path_to_file), +1).Remove(0, 1));
        //}
        //private string[] DecryptGroggyFiles(string directory_of_recording)
        //{
        //    List<string> dbnoList = new List<string>();
        //    foreach (string file in Directory.GetFiles(directory_of_recording + "\\data"))
        //    {
        //        if (file.Contains("groggy"))
        //        {
        //             JObject groggyfile = DecryptDBNOorKillFile(file);
        //             dbnoList.Add((string)groggyfile["instigatorNetId"]);
        //             dbnoList.Add((string)groggyfile["instigatorName"]);
        //             dbnoList.Add((string)groggyfile["victimNetId"]);
        //             dbnoList.Add((string)groggyfile["victimName"]);
        //        }
        //    }
        //    foreach (var item in dbnoList.ToArray())
        //    {
        //        Console.WriteLine(item);
        //    }
        //    return dbnoList.ToArray();
        //}
        //private string[] DecryptKillFiles(string directory_of_recording)
        //{
        //    List<string> killList = new List<string>();
        //    foreach (string file in Directory.GetFiles(directory_of_recording + "\\data"))
        //    {
        //        if (file.Contains("kill"))
        //        {
        //            JObject groggyfile = DecryptDBNOorKillFile(file);
        //            killList.Add((string)groggyfile["killerNetId"]);
        //            killList.Add((string)groggyfile["killerName"]);
        //            killList.Add((string)groggyfile["victimNetId"]);
        //            killList.Add((string)groggyfile["victimName"]);
        //        }
        //    }
        //    foreach (var item in killList.ToArray())
        //    {
        //        Console.WriteLine(item);
        //    }
        //    return killList.ToArray();
        //}
        private ArrayList ReadReplayInfo(string directory_of_recording)
        {
            ArrayList ReplayInfo = new ArrayList();
            JObject NormalizedReplayInfoFile = JObject.Parse(UE4StringSerializer(directory_of_recording + "\\PUBG.replayinfo"));
            JObject DecryptedReplaySummaryFile = DecryptReplaySummaryFile(directory_of_recording);
            ReplayInfo.Add((int)NormalizedReplayInfoFile["LengthInMS"]); //Length of the recording in miliseconds
            int temp0 = (int)NormalizedReplayInfoFile["LengthInMS"];
            if (temp0 < 60000)
            {
                temp0 /= 1000; //milliseconds to seconds
                ReplayInfo.Add(temp0.ToString() + " Sec.");
            }
            else
            {
                temp0 /= 60000; //milliseconds to minutes
                ReplayInfo.Add(temp0.ToString() + " Min.");
            }
            ReplayInfo.Add((int)NormalizedReplayInfoFile["NetworkVersion"]); //The verison of the netcode used by PUBG (It's been 720898 since Dec. 25 2017)
            ReplayInfo.Add((int)NormalizedReplayInfoFile["Changelist"]); //Unknown - Has never changed since Dec. 25 2017
            ReplayInfo.Add((string)NormalizedReplayInfoFile["FriendlyName"]); //A long string used to quickly identify matches
            string FriendlyName = (string)NormalizedReplayInfoFile["FriendlyName"];
            string[] temp1 = FriendlyName.Split('.');
            //FriendlyName example
            //match.bro.official.2018-01.na.solo.4018.01.31.e67b52af-f562-47b9-8f94-59c7a2da8195
            ReplayInfo.Add(temp1[2]);//Marks this is a official match - official
            if (temp1[2] == "official")
            {
                ReplayInfo.Add("Official");//official
            }
            if (temp1[2] == "custom")
            {
                ReplayInfo.Add("Custom");//custom
            }
            ReplayInfo.Add(temp1[3]); //(Offical)Marks the update - 2018-01 | (Custom) Marks the Hosting user - 1cePrime
            ReplayInfo.Add(temp1[4]); //Marks the region - na
            ReplayInfo.Add(temp1[4].ToUpper());
            ReplayInfo.Add(temp1[5]); //(Offical)Marks the gamemode - solo | (Custom) Marks the gamemode - normal (and zombies?)
            ReplayInfo.Add(temp1[6] + "-" + temp1[7] + "-" + temp1[8]); //Marks the date - 4018.01.31 (Guess we're 2000 years in the future
            ReplayInfo.Add(temp1[9]); //added the raw UUID for fun - 470ec7f1-c342-46ad-81c9-e9117f27b44a
            ReplayInfo.Add(temp1[9].Remove(0, temp1[9].Length - 6)); //27b44a
            ReplayInfo.Add((ulong)NormalizedReplayInfoFile["DemoFileLastOffset"]); //The file size (in bytes)
            ulong temp2 = (ulong)NormalizedReplayInfoFile["DemoFileLastOffset"];
            if (temp2 > 1000000)
            {
                temp2 /= 1000000;
                ReplayInfo.Add(temp2.ToString() + " MB");
            }
            else
            {
                ReplayInfo.Add(temp2.ToString() + " Bytes");
            }
            ReplayInfo.Add((int)NormalizedReplayInfoFile["SizeInBytes"]);//Unknown - is always zero
            ReplayInfo.Add((double)NormalizedReplayInfoFile["Timestamp"]);//Timestamp in unix time of when it was recorded
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds((double)NormalizedReplayInfoFile["Timestamp"]).ToLocalTime();
            ReplayInfo.Add(dateTime);
            ReplayInfo.Add(dateTime.ToString());
            ReplayInfo.Add((bool)NormalizedReplayInfoFile["bIsLive"]);//Unknown - is always true
            ReplayInfo.Add((bool)NormalizedReplayInfoFile["bIncomplete"]);//Unknown - is always true
            ReplayInfo.Add((bool)NormalizedReplayInfoFile["bIsServerRecording"]);//Heavy possibly the server also records a copy of the entire match
            ReplayInfo.Add((bool)NormalizedReplayInfoFile["bShouldKeep"]);//True = Pubg won't delete the file for a new one and it prevents the user from deleting it to
            ReplayInfo.Add((string)NormalizedReplayInfoFile["Mode"]);//Solo, Duo, Squad (and ffp)
            string modeflag = (string)NormalizedReplayInfoFile["Mode"];
            if (modeflag == "solo")
            {
                ReplayInfo.Add("Solo");
            }
            else if (modeflag == "solo-fpp")
            {
                ReplayInfo.Add("Solo (First person)");
            }
            else if (modeflag == "duo")
            {
                ReplayInfo.Add("Duo");
            }
            else if (modeflag == "duo-fpp")
            {
                ReplayInfo.Add("Duo (First person)");
            }
            else if (modeflag == "squad")
            {
                ReplayInfo.Add("Squad");
            }
            else if (modeflag == "squad-fpp")
            {
                ReplayInfo.Add("Squad (First person)");
            }
            else
            {
                ReplayInfo.Add("Unknown");
            }
            ReplayInfo.Add((string)NormalizedReplayInfoFile["RecordUserId"]);//Past replays have the Steam64 ID but newer replays have a UUID of some kind
            //if (NormalizedReplayInfoFile["RecordUserId"].ToString().Contains("765611"))
            //{
            //    ReplayInfo.Add((ulong)NormalizedReplayInfoFile["RecordUserId"]);
            //}
            ReplayInfo.Add((string)NormalizedReplayInfoFile["RecordUserNickName"]);//Solo, Duo, Squad (and ffp)
            ReplayInfo.Add((string)NormalizedReplayInfoFile["MapName"]);//Desert_Main (Miramar) or Erangel_Main (Erangel)
            if ((string)NormalizedReplayInfoFile["MapName"] == "Erangel_Main")
            {
                ReplayInfo.Add("Erangel");
            }
            else if ((string)NormalizedReplayInfoFile["MapName"] == "Desert_Main")
            {
                ReplayInfo.Add("Miramar");
            }
            else
            {
                ReplayInfo.Add("Unknown");
            }
            try
            {
                ReplayInfo.Add((bool)NormalizedReplayInfoFile["bAllDeadOrWin"]);//Unknown - is always true
            }
            catch (Exception)
            {
                ReplayInfo.Add(true);
            }
            double dirsize = GetDirectorySize(replayloc + "\\" + replayList.SelectedItem + "\\");
            if (dirsize < 1048576)
            {
                ReplayInfo.Add(Math.Truncate(dirsize).ToString() + " Bytes");
            }
            else
            {
                dirsize /= 1048576;
                ReplayInfo.Add(Math.Truncate(dirsize).ToString() + " MB");
            }
            if (DecryptedReplaySummaryFile["weatherName"].ToString() == "Weather_Clear_02")
            {
                ReplayInfo.Add("Sunny Clear");
            }
            else if (DecryptedReplaySummaryFile["weatherName"].ToString() == "Weather_Desert_Sunrise")
            {
                ReplayInfo.Add("Sunrise");
            }
            else if (DecryptedReplaySummaryFile["weatherName"].ToString() == "Weather_Desert_Clear")
            {
                ReplayInfo.Add("Sunny");
            }
            else if (DecryptedReplaySummaryFile["weatherName"].ToString() == "Weather_Clear")
            {
                ReplayInfo.Add("Sunny");
            }
            else if (DecryptedReplaySummaryFile["weatherName"].ToString() == "Weather_Dark")
            {
                ReplayInfo.Add("Sunset");
            }
            else
            {
                ReplayInfo.Add(DecryptedReplaySummaryFile["weatherName"].ToString());
            }
            ReplayInfo.Add((int)DecryptedReplaySummaryFile["numPlayers"]);
            ReplayInfo.Add((int)DecryptedReplaySummaryFile["numTeams"]);
            //string[] killfiles = DecryptKillFiles(directory_of_recording);
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    ReplayInfo.Add((ulong)DecryptedReplaySummaryFile["playerStateSummaries"][i]["uniqueId"]);
                    ReplayInfo.Add((string)DecryptedReplaySummaryFile["playerStateSummaries"][i]["playerName"]);
                    ReplayInfo.Add((int)DecryptedReplaySummaryFile["playerStateSummaries"][i]["teamNumber"]);
                    ReplayInfo.Add((int)DecryptedReplaySummaryFile["playerStateSummaries"][i]["ranking"]);
                    ReplayInfo.Add((int)DecryptedReplaySummaryFile["playerStateSummaries"][i]["headShots"]);
                    ReplayInfo.Add((int)DecryptedReplaySummaryFile["playerStateSummaries"][i]["numKills"]);

                    ReplayInfo.Add((float)DecryptedReplaySummaryFile["playerStateSummaries"][i]["totalGivenDamages"]);
                    decimal orgDmg = (decimal)DecryptedReplaySummaryFile["playerStateSummaries"][i]["totalGivenDamages"];
                    ReplayInfo.Add(Decimal.Round(orgDmg, 2));

                    ReplayInfo.Add((float)DecryptedReplaySummaryFile["playerStateSummaries"][i]["longestDistanceKill"]);//recorded in centimeters
                    decimal orgInCentimeters = (decimal)DecryptedReplaySummaryFile["playerStateSummaries"][i]["longestDistanceKill"];
                    ReplayInfo.Add(Decimal.Round((orgInCentimeters / 100),2).ToString()+" m");

                    ReplayInfo.Add((float)DecryptedReplaySummaryFile["playerStateSummaries"][i]["totalMovedDistanceMeter"]);
                    decimal orgDisc = (decimal)DecryptedReplaySummaryFile["playerStateSummaries"][i]["totalMovedDistanceMeter"];
                    if (orgDisc > 1000)
                    {
                        ReplayInfo.Add(Decimal.Round((orgDisc / 1000), 2).ToString() + " km");
                    }
                    else
                    {
                        ReplayInfo.Add(Decimal.Round(orgDisc, 2).ToString() + " m");
                    }
                    //for (int q = 0; q < killfiles.Length; q++)
                    //{
                    //    if (killfiles[q] == (string)DecryptedReplaySummaryFile["playerStateSummaries"][i]["uniqueId"])
                    //    {
                    //        ReplayInfo.Add(killfiles[q - 1]);//pubg name
                    //        ReplayInfo.Add(killfiles[q - 2]);//steam id
                    //    }
                    //}
                }
                catch (Exception)
                {
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                    ReplayInfo.Add("[unknown]");
                }
            }
            int replayinfoline = 0;
            foreach (var item in ReplayInfo.ToArray())
            {
                Console.WriteLine(replayinfoline + " | " + item.ToString());
                replayinfoline++;
            }
            return ReplayInfo;
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
            if (replayList.Items.Count >= 20)
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

        private void replayListRefresh_Click(object sender, EventArgs e)
        {
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
                if (Directory.Exists(replayloc + "\\" + replayList.SelectedItem + "\\"))
                {
                    Directory.Delete(replayloc + "\\" + replayList.SelectedItem + "\\", true);
                }
                MessageBox.Show("Selected replay deleted!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshReplayList();
            }
        }

        private void exportallreplays_Click(object sender, EventArgs e)
        {
            DialogResult aus = MessageBox.Show("This will export ALL replays in the Replays folder to a zip file" + Environment.NewLine + "Are you sure you want to delete all replays?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
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

    }
}
