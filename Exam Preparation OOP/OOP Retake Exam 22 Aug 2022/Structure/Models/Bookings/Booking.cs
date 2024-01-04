namespace BookingApp.Models.Bookings
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;
    using Contracts;
    using System;
    using System.Text;

    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;


        }
       


        public IRoom Room { get; private set; }

       
        public int ResidenceDuration

        {
            get { return residenceDuration; }
             private set 
            { 
                if(value<1)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
               
                residenceDuration = value; 
            }
        }
        public int AdultsCount
        {
            get { return adultsCount; }
             private set 
            { 
               if(value<1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                
                adultsCount = value;
            }
        }
       
        public int ChildrenCount
        {
            get { return childrenCount; }
         private   set 
            { 
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                
                childrenCount = value; 
            
            }
        }
        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
         
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {Room.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {TotalPaid():F2} $");
            return sb.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            return Math.Round(Room.PricePerNight * residenceDuration, 2);
        }
    }
}
