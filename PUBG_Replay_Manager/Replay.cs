using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public ReplaySummaryPlayer Recorder
        {
            get
            {
                return Summary.Players.First(player => player.PlayerName == Info.RecordUserNickName);
            }
        }

        public double Size()
        {
            return Utils.GetDirectorySize(Path);
        }

        public List<ReplayEvent> Events()
        {
            List<ReplayEvent> events = new List<ReplayEvent>();
            
            foreach (string file in Directory.GetFiles(Path + "\\data"))
            {
                string eventpath = Path + "\\events" + file.Substring(file.LastIndexOf('\\'));
                
                string dataJson = Utils.UE4StringSerializer(file, 1);
                string eventJson = Utils.UE4StringSerializer(eventpath);
                
                ReplayEventMeta meta = JsonConvert.DeserializeObject<ReplayEventMeta>(eventJson);

                switch (meta.Group)
                {
                    case "groggy":
                        ReplayKnockEvent knockEvent = JsonConvert.DeserializeObject<ReplayKnockEvent>(dataJson);
                        knockEvent.Time = meta.Time;
                        
                        events.Add(knockEvent);
                        break;
                    
                    case "kill":
                        ReplayKillEvent killEvent = JsonConvert.DeserializeObject<ReplayKillEvent>(dataJson);
                        killEvent.Time = meta.Time;
                        
                        events.Add(killEvent);
                        break;
                    
                    case "ReplaySummary":
                    case "level":
                        break;
                    
                    default:
                        Console.WriteLine($"Unknown event type: {meta.Group} for event {meta.Id}");
                        break;
                }
            }

            events.Sort((x,y) => x.Time.CompareTo(y.Time));
            return events;
        }
    }

    class ReplayEventMeta
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("group")]
        public string Group;

        [JsonProperty("time1")]
        public int Time;
    }
}