using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesomeRaptorRacingGame_Backend.Dtos
{
    public class ScoreDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TrackName { get; set; }
        public string Time { get; set; }
    }
}
