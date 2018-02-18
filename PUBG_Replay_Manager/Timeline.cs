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
            timelineRTB.AppendText("| 이 킬,기절 목록은 미완성 기능입니다. 몇몇 빠진 정보가 있을 수 있습니다.", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("| 리플레이 기록자의 1km 이내의 모든 킬, 기절에 대한 정보입니다.", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("| 빨간 색이 킬, 주황색이 기절입니다.", Color.Red);
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
                    JObject groggyfile = JObject.Parse(UE4StringSerializer(file, true, 1));
                    string eventpath = directory_of_recording + "events" + file.Substring(file.LastIndexOf('\\'));
                    JObject groggyeventfile = JObject.Parse(UE4StringSerializer(eventpath));
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
                    JObject killfile = JObject.Parse(UE4StringSerializer(file, true, 1));
                    string eventpath = directory_of_recording + "events" + file.Substring(file.LastIndexOf('\\'));
                    JObject killeventfile = JObject.Parse(UE4StringSerializer(eventpath));
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
            //Console.WriteLine(Encoding.UTF8.GetString(readspace));
            //Console.WriteLine(Encoding.UTF8.GetString(unencodedbytes.ToArray()));
            return Encoding.UTF8.GetString(unencodedbytes.ToArray());//take all the bytes, make the list a array, put the array into UTF8 encoding and return it
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
