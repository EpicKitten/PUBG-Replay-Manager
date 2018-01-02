using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUBG_Replay_Manager
{
    public partial class KillFeed : Form
    {
        public KillFeed(string killfeel_loc)
        {
            InitializeComponent();
        }

        private void KillFeed_Load(object sender, EventArgs e)
        {

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
                MatchCollection matches = Regex.Matches(content, @"!654500\d\d\d\d\d\d\d\d\d\d\d!");
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
                fulllist.Add(i + " SteamID(s) recorded from replay files");
                fulllist.Add(p + " SteamID(s) recorded from replay files (duplicates removed)");
                fulllist.Add("==================================");
            }
            return fulllist.ToArray();
        }
        }
}
