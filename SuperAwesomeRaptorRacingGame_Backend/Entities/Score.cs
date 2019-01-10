using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperAwesomeRaptorRacingGame_Backend.Entities
{
    public class Score
    {
        public int ScoreId { get; set; }
        public string TrackName { get; set; }
        public string Time { get; set; }
        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore, IsReference = true)]
        public User User { get; set; }
    }
}
