using System.Data.Common;
using Newtonsoft.Json;

namespace PUBG_Replay_Manager
{
    public class ReplaySummary
    {
        [JsonProperty("bIsServerRecording")]
        public bool IsServerRecording;

        [JsonProperty("matchId")]
        public string Id;

        [JsonProperty("numPlayers")]
        public int PlayersCount;
        
        [JsonProperty("numTeams")]
        public int TeamsCount;
        
        [JsonProperty("regionName")]
        public string Region;
        
        [JsonProperty("weatherName")]
        public string Weather;
        
        [JsonProperty("playerStateSummaries")]
        public ReplaySummaryPlayer[] Players;
    }

    public class ReplaySummaryPlayer
    {
        [JsonProperty("playerName")]
        public string PlayerName;

        [JsonProperty("uniqueId")]
        public ulong PlayerId;
        
        [JsonProperty("teamNumber")]
        public int PlayerTeamId;
        
        [JsonProperty("ranking")]
        public int Ranking;
        
        [JsonProperty("headShots")]
        public int HeadShots;
        
        [JsonProperty("numKills")]
        public int Kills;
        
        [JsonProperty("longestDistanceKill")]
        public float LongestDistanceKill;
        
        [JsonProperty("totalGivenDamages")]
        public float TotalGivenDamages;
        
        [JsonProperty("totalMovedDistanceMeter")]
        public float TotalMovedDistance;
    }
}