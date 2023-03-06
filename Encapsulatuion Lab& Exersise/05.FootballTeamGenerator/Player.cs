namespace _05.FootballTeamGenerator
{
    public class Player
    {

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");

                }
                value = name;
            }
        }


        public int Endurance
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(MessageExseptions.RangeStats, nameof(this.Endurance)));
                }
            }
        }
        public int Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(MessageExseptions.RangeStats, nameof(this.Sprint)));
                }
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(MessageExseptions.RangeStats, nameof(this.Dribble)));
                }

            }
        }
        public int Passing

        {
            get => passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(MessageExseptions.RangeStats, nameof(this.Passing)));
                }
            }
        }
        public int Shooting
        {
            get => shooting;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(MessageExseptions.RangeStats, nameof(this.Shooting)));
                }
            }

        }


        public double  RaitingCalculation
        
           => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        
    }
}
