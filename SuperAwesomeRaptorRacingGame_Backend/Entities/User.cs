
using System.Collections.Generic;

namespace SuperAwesomeRaptorRacingGame_Backend.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public User()
        {
            this.Scores = new HashSet<Score>();
        }
        public ICollection<Score> Scores { get; set; }
    }
}
