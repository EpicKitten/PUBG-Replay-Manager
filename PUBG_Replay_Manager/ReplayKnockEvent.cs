using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PUBG_Replay_Manager
{
    public class ReplayKnockEvent : ReplayEvent, IReplayEvent
    {
        [JsonProperty("instigatorNetId")]
        public string InstigatorId;
        
        [JsonProperty("instigatorName")]
        public string InstigatorName;
        
        [JsonProperty("victimNetId")]
        public string VictimId;
        
        [JsonProperty("victimName")]
        public string VictimName;

        public string ToString()
        {
            return ToString(InstigatorId, InstigatorName, "downed", VictimId, VictimName);
        }
    }
}