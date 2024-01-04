using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            this.booths = new BoothRepository();
        }
        private BoothRepository booths;
        public string AddBooth(int capacity)
        {
            int bothID = this.booths.Models.Count + 1;

            IBooth booth = new Booth(bothID, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded,bothID,capacity);


        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
                if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
                {
                    return string
                        .Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
                }

                if (this.booths.Models.Any(b => b.DelicacyMenu.Models.Any(dm => dm.Name == delicacyName)))
                {
                    return string
                        .Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
                }

                IDelicacy delicacy;
                if (delicacyTypeName == nameof(Gingerbread))
                {
                    delicacy = new Gingerbread(delicacyName);
                }
                else
                {
                    delicacy = new Stolen(delicacyName);
                }

                IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                booth.DelicacyMenu.AddModel(delicacy);

                return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
          if(cocktailTypeName!=nameof(MulledWine)&& cocktailTypeName!=nameof(Hibernation)) 
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            
            }
          if(size!="Small" && size!="Middle"&& size!="Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
          if(this.booths.Models.Any(v=>v.CocktailMenu.Models.Any(cm=>cm.Name==cocktailName && cm.Size== size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;
            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

      
        public string BoothReport(int boothId)
        {

             return this.booths.Models.FirstOrDefault(v => v.BoothId == boothId).ToString().TrimEnd();
           
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(v => v.BoothId == boothId);


            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] orderArray = order.Split('/');

            bool isCocktail = false;

            string itemTypeName = orderArray[0];

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            string itemName = orderArray[1];

            if (!booth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(m => m.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            int pieces = int.Parse(orderArray[2]);



            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                isCocktail = true;
            }

            if (isCocktail)
            {
                string size = orderArray[3];

                ICocktail desiredCocktail = booth
                    .CocktailMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName && m.Size == size);

                if (desiredCocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(desiredCocktail.Price * pieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
            }
            else
            {
                IDelicacy desiredDelicacy = booth
                .DelicacyMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName);

                if (desiredDelicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemName);
                }

                booth.UpdateCurrentBill(desiredDelicacy.Price * pieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
            }
        }
    }
}
