using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PUBG_Replay_Manager
{
    public enum GameMode
    {
        Unknown,
        
        [EnumMember(Value = "solo")]
        SoloTPP,
        
        [EnumMember(Value = "solo-fpp")]
        SoloFPP,
        
        [EnumMember(Value = "duo")]
        DuoTPP,
        
        [EnumMember(Value = "duo-fpp")]
        DuoFPP,
        
        [EnumMember(Value = "squad")]
        SquadTPP,
        
        [EnumMember(Value = "squad-fpp")]
        SquadFPP,
    }

    public enum GameMap
    {
        Unknown,
        
        [EnumMember(Value = "Desert_Main")]
        Miramar,
        
        [EnumMember(Value = "Erangel_Main")]
        Erangel,
    }

    public enum ServerType
    {
        Unknown,
        Official,
        Custom,
    }
    
    public class ReplayInfo
    {
        [JsonProperty("LengthInMS")]
        public int LengthInMs; //Length of the recording in miliseconds

        public int NetworkVersion; //The verison of the netcode used by PUBG (It's been 720898 since Dec. 25 2017)

        public int Changelist; //Unknown - Has never changed since Dec. 25 2017

        private string friendlyName;
        
        public string FriendlyName
        {
            set
            {
                friendlyName = value;
                
                string[] parts = friendlyName.Split('.');

                switch (parts[2])
                {
                    case "official":
                        ServerType = ServerType.Official;
                        break;
                    
                    case "custom":
                        ServerType = ServerType.Custom;
                        CustomHost = parts[3];
                        break;
                    
                    default:
                        ServerType = ServerType.Unknown;
                        break;
                }
            }

            get { return friendlyName; }
        }

        public ServerType ServerType = ServerType.Unknown;

        public string CustomHost = null;

        public ulong DemoFileLastOffset; //The file size (in bytes)

        public int SizeInBytes; //Unknown - is always zero

        private double unixtime;
        
        [JsonProperty("Timestamp")]
        public double Unixtime //Timestamp in unix time of when it was recorded
        {
            set
            {
                unixtime = value;
                CreatedAt = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(value);
            }

            get { return unixtime; }
        }

        public DateTime CreatedAt;

        [JsonProperty("bIsLive")]
        public bool IsLive; //Unknown - is always true

        [JsonProperty("bIncomplete")]
        public bool IsIncomplete; //Unknown - is always true

        [JsonProperty("bIsServerRecording")]
        public bool IsServerRecording; //Heavy possibly the server also records a copy of the entire match

        [JsonProperty("bShouldKeep")] 
        public bool ShouldKeep; //True = Pubg won't delete the file for a new one and it prevents the user from deleting it to

        [JsonConverter(typeof(StringEnumConverter))]
        public GameMode Mode;

        public string RecordUserId; //Past replays have the Steam64 ID but newer replays have a UUID of some kind

        public string RecordUserNickName;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public GameMap MapName;
        
        [JsonProperty("bAllDeadOrWin")]
        public bool AllDeadOrWin; //Unknown - is always true
    }
}