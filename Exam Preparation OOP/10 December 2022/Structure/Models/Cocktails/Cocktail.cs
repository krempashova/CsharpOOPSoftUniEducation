using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
       
        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        private string  name;
        private string size;
        private double price;

        public string  Name
        {
            get { return name; }
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                
                name = value; 
            
            }
        }
        public string Size
        {
            get { return size; }
            private set
            {
                size = value;
            }
        }

        public double Price
        {
            get { return price; }
           private  set 
            {
                if (this.Size == "Small")
                {
                    value /= 3;
                }
                else if (this.Size == "Middle")
                {
                    value = (value / 3) * 2;
                }

                price = value;

            }

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({Size}) - {Price:F2} lv");
            return sb.ToString().TrimEnd();
        }
    }
}
