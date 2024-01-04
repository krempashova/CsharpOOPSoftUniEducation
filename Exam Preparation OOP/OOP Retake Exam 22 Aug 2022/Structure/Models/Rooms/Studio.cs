namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {

        private const int bedCapacityForStudio = 4;
        public Studio() 
            : base(bedCapacityForStudio)
        {

        }
    }
}
