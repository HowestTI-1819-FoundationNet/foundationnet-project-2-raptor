using SuperAwesomeRaptorRacingGame_Backend.Entities;
using SuperAwesomeRaptorRacingGame_Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAwesomeRaptorRacingGame_Backend.Services
{

    public interface IScoreService
    {
        ICollection<Score> GetScoresForUser(User user);
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


        public ICollection<Score> GetScoresForUser(User user)
        {
            return _context.Scores.Where(score => score.User.UserId == user.UserId).ToList();
        }
    }
}
