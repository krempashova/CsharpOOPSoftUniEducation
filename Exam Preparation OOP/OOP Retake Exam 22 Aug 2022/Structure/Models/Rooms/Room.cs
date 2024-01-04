using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;
        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            this.pricePerNight = 0;

        }
       


        public int BedCapacity
        {
            get { return bedCapacity; }
            private set { bedCapacity = value; }
        }
         public double PricePerNight
        {
            get { return pricePerNight; }
           private  set 
            { 
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight = value; 
            }
        }



       
        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        } 
    }
}
