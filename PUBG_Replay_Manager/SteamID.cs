using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PUBG_Replay_Manager
{
    public partial class SteamID : Form
    {
        public SteamID(string folder)
        {
            InitializeComponent();
            foreach (string arch in SearchFilesInDirectoryForSteamID64(folder, true))
            {
                //SteamIDRich.
                SteamIDRich.AppendText(Environment.NewLine + arch);
                //Console.WriteLine(arch);
            }
        }
        public static string[] SearchFilesInDirectoryForSteamID64(string dir_path, bool summery)
        {
            string fullsearch = "";
            List<String> fulllist = new List<String>();
            int i = 0;
            int p = 0;
            foreach (string file in Directory.GetFiles(dir_path, "*", SearchOption.AllDirectories))
            {
                FileStream stream = File.OpenRead(file);
                byte[] text = new byte[stream.Length];
                stream.Read(text, 0, (int)stream.Length);
                ASCIIEncoding encoding = new ASCIIEncoding();
                string content = encoding.GetString(text);
                MatchCollection matches = Regex.Matches(content, @"7656\d\d\d\d\d\d\d\d\d\d\d\d\d");
                Hashtable hash = new Hashtable();
                foreach (Match mt in matches)
                {
                    string foundMatch = mt.ToString();
                    if (hash.Contains(foundMatch) == false)
                        hash.Add(foundMatch, string.Empty);
                }
                foreach (DictionaryEntry element in hash)
                {
                    fullsearch += element.Key;
                }
                i++;
            }
            MatchCollection fullmatches = Regex.Matches(fullsearch, @"7656\d\d\d\d\d\d\d\d\d\d\d\d\d");
            Hashtable fullhash = new Hashtable();
            foreach (Match mt in fullmatches)
            {
                string foundMatch = mt.ToString();
                if (fullhash.Contains(foundMatch) == false)
                    fullhash.Add(foundMatch, string.Empty);
            }
            foreach (DictionaryEntry element in fullhash)
            {
                fulllist.Add(element.Key.ToString());
                p++;
            }
            if (summery)
            {
                fulllist.Add("==================================");
                fulllist.Add(i + " 개의 SteamID 가 기록되어 있음");
                fulllist.Add(p + " 개의 SteamID 가 기록되어 있음 (중복 제외)");
                fulllist.Add("==================================");
            }
            return fulllist.ToArray();
        }

        private void SteamIDRich_TextChanged(object sender, EventArgs e)
        {

        }

        private void SteamID_Load(object sender, EventArgs e)
        {

        }
    }
}
