
namespace PlayersandMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level) : base(username, level)
        {
            Username = username;
            Level = level;
        }
        public  virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}
