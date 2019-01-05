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
        ICollection<Score> GetScoresForUser(int UserId);
        ICollection<ScoreDto> GetAllScores();
        void AddScore(Score score);

    }

    public class ScoreService : IScoreService
    {

        private DataContext _context;

        public ScoreService(DataContext context)
        {
            _context = context;
        }


        public void AddScore(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }


        public ICollection<Score> GetScoresForUser(int UserId)
        {
            return _context.Scores.Where(score => score.User.UserId == UserId).ToList();
        }

        public ICollection<ScoreDto>GetAllScores()
        {
            return _context.Scores.Select(sc => new
            ScoreDto
            {
                TrackName = sc.TrackName,
                Time = sc.Time,
                Username = sc.User.Username,
                FirstName = sc.User.FirstName,
                LastName = sc.User.LastName
            }).ToList();
        }

    }
}
