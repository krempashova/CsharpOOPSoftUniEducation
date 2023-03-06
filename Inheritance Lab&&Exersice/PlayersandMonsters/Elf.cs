
using PlayersandMonsters;



namespace PlayersandMonsters
{
    public class Elf : Hero
    {
        public Elf(string username, int level) : base(username, level)
        {
            Username = username;
            Level = level;
        }
        public virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}
