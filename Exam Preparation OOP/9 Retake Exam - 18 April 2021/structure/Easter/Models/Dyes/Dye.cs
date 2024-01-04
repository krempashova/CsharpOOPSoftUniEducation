using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            Power = power;
           
        }

        public int Power
        {
            get { return power; }
            private set
            {
                if(value<0)
                {
                    value = 0;
                }
                
                power = value; 
            }
        }

        public bool IsFinished()
        {
            if(Power!=0)
            {
                return false;
            }
            return true;
        }

        public void Use()
        {
            Power -= 10;
            if(Power<0) 
            {
                Power = 0;
            }
        }
    }
}
