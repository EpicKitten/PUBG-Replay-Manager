using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PUBG_Replay_Manager
{
    public partial class Timeline : Form
    {
        public Timeline(string directory_of_recording)
        {
            InitializeComponent();
            Font old_font = timelineRTB.Font;
            timelineRTB.AppendText("|----------------------------------------------------------------------------------------------------------------------|", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("| These kills and downs are from the groggy and kill files and isn't complete! |", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("| These kills and downs all happened within 1km of the recording player.      |", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("|                                   YOU HAVE BEEN WARNED                                     |", Color.Red);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("|----------------------------------------------------------------------------------------------------------------------|", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText(Environment.NewLine);
            foreach (string item in CreateMatchTimeline(directory_of_recording, true))
            {
                if (item.Contains("downed"))
                {
                    timelineRTB.AppendText(item, Color.Orange);
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (item.Contains("killed"))
                {
                    timelineRTB.AppendText(item, Color.Red);
                    //Console.ForegroundColor = ConsoleColor.Red;
                }
                timelineRTB.AppendText(Environment.NewLine);
                //Console.WriteLine(item);
                //Console.ResetColor();
            }
            timelineRTB.SelectionStart = 0;
            timelineRTB.SelectionLength = 0;
            timelineRTB.ScrollToCaret();
            //timelineRTB.Font = Font.Size
            //timelineRTB.Res
        }
        static string[] CreateMatchTimeline(string directory_of_recording, bool humanFriendly)
        {
            List<string> masterline = new List<string>();
            List<string> timeline = new List<string>();
            List<int> times = new List<int>();
            foreach (string file in Directory.GetFiles(directory_of_recording + "\\data"))
            {
                if (file.Contains("groggy"))
                {
                    JObject groggyfile = JObject.Parse(Utils.UE4StringSerializer(file, 1));
                    string eventpath = directory_of_recording + "events" + file.Substring(file.LastIndexOf('\\'));
                    JObject groggyeventfile = JObject.Parse(Utils.UE4StringSerializer(eventpath));
                    times.Add((int)groggyeventfile["time1"]);
                    timeline.Add((string)groggyeventfile["time1"]);
                    timeline.Add((string)groggyfile["instigatorNetId"]);
                    timeline.Add((string)groggyfile["instigatorName"]);
                    timeline.Add("downed");
                    timeline.Add((string)groggyfile["victimNetId"]);
                    timeline.Add((string)groggyfile["victimName"]);
                }
                if (file.Contains("kill"))
                {
                    JObject killfile = JObject.Parse(Utils.UE4StringSerializer(file, 1));
                    string eventpath = directory_of_recording + "events" + file.Substring(file.LastIndexOf('\\'));
                    JObject killeventfile = JObject.Parse(Utils.UE4StringSerializer(eventpath));
                    times.Add((int)killeventfile["time1"]);
                    timeline.Add((string)killeventfile["time1"]);
                    timeline.Add((string)killfile["killerNetId"]);
                    timeline.Add((string)killfile["killerName"]);
                    timeline.Add("killed");
                    timeline.Add((string)killfile["victimNetId"]);
                    timeline.Add((string)killfile["victimName"]);
                }
            }

            times.Sort();
            foreach (int time in times.ToArray())
            {
                for (int i = 0; i < timeline.ToArray().Length; i++)
                {
                    if (timeline.ToArray()[i].Contains(time.ToString()))
                    {
                        decimal timeInSeconds = ((decimal)time) / 1000;
                        decimal timeInMins = timeInSeconds / 60;
                        decimal timeInMinsTrunt = TruncateDecimal(timeInMins, 2);
                        masterline.Add(timeInSeconds.ToString() + " seconds into the replay (" + timeInMinsTrunt.ToString() + " mins.) " + timeline.ToArray()[i + 2].ToString() + " (" + timeline.ToArray()[i + 1].ToString() + ") " + timeline.ToArray()[i + 3].ToString() + " " + timeline.ToArray()[i + 5].ToString() + " (" + timeline.ToArray()[i + 4].ToString() + ")");
                    }
                }
            }

            return masterline.Distinct().ToArray();
        }
        static decimal TruncateDecimal(decimal value, int decialplace)
        {
            decimal step = (decimal)Math.Pow(10, decialplace);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
