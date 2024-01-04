using Heroes.Models.Contracts;
using Heroes.Models.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Maps
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = new List<Knight>();
            List<Barbarian> barbarians = new List<Barbarian>();
            foreach (IHero hero in players)

            {
                if (hero.IsAlive)
                {
                    if (hero is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (hero is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                }
            }

            bool isFightOver = false;
            string result = string.Empty;
            while (!isFightOver)
            {
                foreach (var knight in knights.Where(k => k.IsAlive))
                {
                    foreach (var barberian in barbarians.Where(B => B.IsAlive))
                    {

                        int inflictdamage = knight.Weapon.DoDamage();
                        barberian.TakeDamage(inflictdamage);
                        if (!barbarians.Any(b => b.IsAlive))
                        {
                            //knight WIN
                            result = $"The knights took {knights.Where(k => !k.IsAlive).Count()} casualties but won the battle.";
                            isFightOver = true;
                            break;
                        }

                    }
                }
                if (isFightOver)
                {
                    break;
                }

                foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                {

                    foreach (Knight knight in knights.Where(k => k.IsAlive))
                    {
                        int inflictdamage = barbarian.Weapon.DoDamage();
                        knight.TakeDamage(inflictdamage);

                        if (!knights.Any(b => b.IsAlive))
                        {
                            result = $"The barbarians took {barbarians.Where(b => !b.IsAlive).Count()} casualties but won the battle.";
                            isFightOver = true;
                            break;
                        }
                    }
                }
                if (isFightOver)
                {
                    break;
                }



                
            }

            return result;
        }
    }
}

