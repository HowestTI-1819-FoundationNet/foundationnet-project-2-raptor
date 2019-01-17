using SuperAwesomeRaptorRacingGame_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesomeRaptorRacingGame_Backend.Hubs
{
    public interface IScoresHub
    {
        Task BroadCastScore(string type, ScoreDto scoreDto);
    }
}
