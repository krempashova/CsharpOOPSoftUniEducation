

namespace PlayersandMonsters
{
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username, level)
        {
            Username = username;
            Level = level;
        }
        public virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}

