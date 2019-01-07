using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesomeRaptorRacingGame_Backend.Entities
{
    public class Score
    {
        public int ScoreId { get; set; }
        public string TrackName { get; set; }
        public string Time { get; set; }
        public User User { get; set; }
    }
}
