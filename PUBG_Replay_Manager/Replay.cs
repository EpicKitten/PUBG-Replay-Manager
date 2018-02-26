using System;
using System.IO;
using Newtonsoft.Json;

namespace PUBG_Replay_Manager
{
    public class Replay
    {
        private string Path;

        public ReplayInfo Info;
        public ReplaySummary Summary;
        
        public Replay(string path)
        {
            Path = path;
            Info = DecryptReplayInfoFile();
            Summary = DecryptReplaySummaryFile();
            
            Console.Write("");
        }

        private ReplaySummary DecryptReplaySummaryFile()
        {
            string filename = null;
            
            foreach (string replay in Directory.GetFiles(Path + "\\data"))
            {
                if (replay.Contains("ReplaySummary"))
                {
                    filename = replay;
                }
            }

            if (filename == null)
            {
                throw new Exception("ReplaySummary file is not found");
            }
            
            string summaryJson = Utils.UE4StringSerializer(filename, 1);
            return JsonConvert.DeserializeObject<ReplaySummary>(summaryJson);
        }

        private ReplayInfo DecryptReplayInfoFile()
        {
            string infoJson = Utils.UE4StringSerializer(Path + "\\PUBG.replayinfo");
            return JsonConvert.DeserializeObject<ReplayInfo>(infoJson);
        }
    }
}