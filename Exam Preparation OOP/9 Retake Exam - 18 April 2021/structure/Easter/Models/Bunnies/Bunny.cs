using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.dyes = new List<IDye>();
            Dyes = dyes;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        private int energy;

        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energy = value;
            }
        }

        private ICollection<IDye> dyes;

        public ICollection<IDye> Dyes { get; }
        

        public void AddDye(IDye dye)
        { // i am not shure ifg adding shouwld be to prop or to filed???
            this.dyes.Add(dye);
        }

        public  virtual void Work()
        {
            this.Energy -= 10;
            if(this.Energy<0)
            {
                this.Energy = 0;
            }
        }
    }
}
