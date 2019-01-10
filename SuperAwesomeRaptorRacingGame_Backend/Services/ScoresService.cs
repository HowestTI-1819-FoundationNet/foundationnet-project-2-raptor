using SuperAwesomeRaptorRacingGame_Backend.Entities;
using SuperAwesomeRaptorRacingGame_Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAwesomeRaptorRacingGame_Backend.Dtos;

namespace SuperAwesomeRaptorRacingGame_Backend.Services
{

    public interface IScoreService
    {
        ICollection<ScoreDto> GetScoresForUser(int UserId);
        Task<ICollection<ScoreDto>> GetAllScores();
        Task AddScore(Score score);

    }

    public class ScoreService : IScoreService
    {

        private DataContext _context;

        public ScoreService(DataContext context)
        {
            _context = context;
        }

        public async Task AddScore(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }


        public ICollection<ScoreDto> GetScoresForUser(int UserId)
        {
            return _context.Scores.Where(score => score.User.UserId == UserId).Select(sc => new ScoreDto
            {
                TrackName = sc.TrackName,
                Time = sc.Time,
                User = new ScoreUserDto {
                    FirstName = sc.User.FirstName,
                    LastName = sc.User.LastName,
                    Username  = sc.User.Username
                }
            }).ToList();
        }

        public async Task<ICollection<ScoreDto>>GetAllScores()
        {
            return await _context.Scores.Select(sc => new
            ScoreDto
            {
              TrackName = sc.TrackName,
              Time = sc.Time,
              User = new ScoreUserDto
                {
                    FirstName = sc.User.FirstName,
                    LastName = sc.User.LastName,
                    Username = sc.User.Username
                }
            }).ToListAsync();
        }

    }
}
