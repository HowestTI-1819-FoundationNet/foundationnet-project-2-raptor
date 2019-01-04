using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesomeRaptorRacingGame_Backend.Dtos
{
    public class ScoreDto
    {
        public int UserId { get; set; }
        public int ScoreId { get; set; }
        public string TrackName { get; set; }
        public string Time { get; set; }
    }
}
