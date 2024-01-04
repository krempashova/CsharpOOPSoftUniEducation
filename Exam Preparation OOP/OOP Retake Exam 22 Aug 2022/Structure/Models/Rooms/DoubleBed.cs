namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int bedCapacityforDoubleRoom = 2;
        public DoubleBed() 
            : base(bedCapacityforDoubleRoom)
        {

        }
    }
}
