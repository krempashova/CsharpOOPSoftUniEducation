using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{      
    

    public class Booth : IBooth
    {
        public Booth(int boothId, int capacity)
        {

            BoothId = boothId;
            Capacity = capacity;
           this.availabledelicaties =new DelicacyRepository();
           this. availablecocktails = new CocktailRepository();


            this.currentBill = 0;
            this.turnover = 0;



        }
        private int capacity;
        private double currentBill;
        private double turnover;
        private readonly IRepository<IDelicacy> availabledelicaties;
        private readonly IRepository<ICocktail> availablecocktails;
        public int BoothId { get; private set; }
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                else
                {
                    capacity = value;
                }
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.availabledelicaties;

        public IRepository<ICocktail> CocktailMenu => this.availablecocktails;

        public double CurrentBill => this.currentBill;

        public double Turnover => this.turnover;

        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
        {

            this.currentBill += amount;
        }
        public void Charge()
        {
            this.turnover += currentBill;
            this.currentBill = 0;
        }
        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Booth: {BoothId}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Turnover: {Turnover:F2} lv")
                .AppendLine($"-Cocktail menu:");
                foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }
            sb.AppendLine($"-Delicacy menu:");
                foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }
            return sb.ToString().TrimEnd();
        }


    }
}
