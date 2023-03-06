using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersandMonsters
{
    public class DarkKnight : Knight
    {
        public DarkKnight(string username, int level) : base(username, level)
        {

            Username = username;
            Level = level;
        }
        public virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}
