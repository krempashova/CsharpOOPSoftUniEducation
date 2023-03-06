using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersandMonsters
{

    public class Knight : Hero
    {
        public Knight(string username, int level) : base(username, level)
        {
            Username = username;
            Level = level;
        }
        public virtual string Username { get; set; }
        public virtual int Level { get; set; }
    }
}
