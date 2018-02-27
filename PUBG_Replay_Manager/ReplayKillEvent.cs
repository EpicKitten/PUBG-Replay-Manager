using Newtonsoft.Json;

namespace PUBG_Replay_Manager
{
    public class ReplayKillEvent : ReplayEvent, IReplayEvent
    {
        [JsonProperty("killerNetId")]
        public string KillerId;
        
        [JsonProperty("killerName")]
        public string KillerName;
        
        [JsonProperty("victimNetId")]
        public string VictimId;
        
        [JsonProperty("victimName")]
        public string VictimName;
        
        public string ToString()
        {
            return ToString(KillerId, KillerName, "killed", VictimId, VictimName);
        }
    }
}