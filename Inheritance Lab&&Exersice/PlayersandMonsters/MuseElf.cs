
namespace PlayersandMonsters
{
    public class MuseElf : Elf
    {
        public MuseElf(string username, int level) : base(username, level)
        {
            Username=username;
            Level=level;    
        }
        public virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}
