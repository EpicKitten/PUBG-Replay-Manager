using System;
using Newtonsoft.Json;

namespace PUBG_Replay_Manager
{
    public class ReplayEvent: IReplayEvent
    {
        public int Time;

        protected string FormatTime()
        {
            return TimeSpan.FromSeconds(Time / 1000).ToString(@"mm\:ss");
        }
        
        public virtual string ToString()
        {
            return $"[{FormatTime()}]: {this.GetType().Name}";
        }

        protected string ToString(string id1, string player1, string verb, string id2, string player2)
        {
            return $"[{FormatTime()}]: {player1} ({id1}) {verb} {player2} ({id2})";
        }
    }
}