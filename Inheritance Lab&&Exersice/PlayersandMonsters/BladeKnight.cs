

namespace PlayersandMonsters
{
    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string username, int level) : base(username, level)
        {
            Username = username;
            Level = level;
        }
        public virtual string Username { get; set; }
        public virtual int Level { get; set; }

    }
}