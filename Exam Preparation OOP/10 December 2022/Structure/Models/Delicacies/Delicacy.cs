namespace ChristmasPastryShop.Models.Delicacies
{
    using Delicacies.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Delicacy : IDelicacy
    {

        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
        }
        private string name;

        public string Name
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
        public double Price { get; private set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} - {Price:F2} lv");
            return sb.ToString().TrimEnd();
        }
    }
    
}
