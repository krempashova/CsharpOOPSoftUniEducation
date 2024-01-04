using Heroes.Models.Contracts;
using Heroes.Models.Heros;
using Heroes.Models.Maps;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core.Contracts
{
    public class Controller : IController
    {
        private HeroRepository heroes ;
        private WeaponRepository weapons ;
        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();

        }

        public string CreateHero(string type, string name, int health, int armour)
        {
           if(heroes.FindByName(name)!=null)
            {
                throw new InvalidOperationException(String.Format(OutputMessages.HeroAlreadyExist, name));
            }
           if(type!=nameof(Barbarian)
                && type!=nameof(Knight))
            {
                throw new InvalidOperationException(String.Format(OutputMessages.HeroTypeIsInvalid, type));
            }

            IHero hero;
            if(type==nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return String.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }
            
                hero = new Knight(name, health, armour);
                  heroes.Add(hero);
                return String.Format(OutputMessages.SuccessfullyAddedKnight, name);
            
           
        }
        public string CreateWeapon(string type, string name, int durability)
        {

            IWeapon weapon = weapons.FindByName(name);
            if(weapon!=null)
            {
                //exist
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }
            if(type!= nameof(Claymore)&&
                type!=nameof(Mace))
            {
                //Invalid type 
                throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid);
            }
            else
            {
                
                if(type==nameof(Claymore))
                {
                    weapon = new Claymore(name, durability);
                }
                else if (type == nameof(Mace))
                {
                    weapon = new Mace(name, durability);
                }
                
            }

            weapons.Add(weapon);
            return String.Format(OutputMessages.WeaponAddedSuccessfully,type.ToLower(),name);   

        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if(hero==null)
            {
                //do not exist 
                throw new InvalidOperationException(String.Format(OutputMessages.HeroDoesNotExist, heroName));
            }
            IWeapon weapon = weapons.FindByName(weaponName);
            if(weapon==null)
            {
                //do not exist
                throw new InvalidOperationException(String.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }
            if (hero.Weapon != null)
                {
                    throw new InvalidOperationException($"Hero {heroName} is well-armed.");
                }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return String.Format(OutputMessages.WeaponAddedToHero,heroName,weapon.GetType().Name.ToLower());


        }
        public string StartBattle()
        {
            Map map = new Map();
           return map.Fight(heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList());

        }
        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IHero hero in heroes.Models.OrderBy(c => c.GetType().Name)
                .ThenByDescending(C => C.Health)
                .ThenBy(c => c.Name)
                .ToList())
            {
                sb
                    .AppendLine($"{hero.GetType().Name}: {hero.Name}")
                     .AppendLine($"--Health: {hero.Health}")
                          .AppendLine($"--Armour: {hero.Armour}")
                          .AppendLine(hero.Weapon == null ? "--Weapon: Unarmed"
                                                          : $"--Weapon: {hero.Weapon.Name}");
            }

            return sb.ToString().TrimEnd();
        }
        }

       
    }

