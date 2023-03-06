namespace PlayersandMonsters
{
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username, int level) : base(username, level)
        {
            Username = username;
            Level = level;
        }
        public  virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}
