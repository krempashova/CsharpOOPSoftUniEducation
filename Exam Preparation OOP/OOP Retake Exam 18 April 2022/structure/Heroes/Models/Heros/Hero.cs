﻿using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Models.Heros
{
    public abstract class Hero : IHero
    {  
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }

                name = value;
            }
        }
        public int Health
        {
            get { return health; }
             private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }

                
                health = value; 
            }
        }

     

        public int Armour
        {
            get { return armour; }
            private set
            {

                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }

                armour = value;
            }
        }
     

        public IWeapon Weapon
        {
            get { return weapon; }
             private set
            { 
                if(value==null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }
                weapon = value; 
            }
        }

      

        public bool IsAlive => this.Health > 0 ? true : false;


        public void AddWeapon(IWeapon weapon)=>this.Weapon=weapon;
        

        public void TakeDamage(int points)
        {
            if (this.Armour - points <= 0)
            {
                int attackPointLeft = points - this.Armour;
                this.Armour = 0;
                if (this.Health - attackPointLeft <= 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= attackPointLeft;
                }

            }
            else
            {
                this.Armour -= points;
            }
        }
    }
}
