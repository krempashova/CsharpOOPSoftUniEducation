namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> playerList;
        private Team()
        {
            this.playerList = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
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
        public int Rating
           => this.playerList.Count > 0 ?
           (int)Math.Round(this.playerList.Average(p => p.RaitingCalculation), 0) : 0;
        public void AddPlayer(Player player)
        {
            this.playerList.Add(player);    
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.playerList
                .FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(
                    MessageExseptions.MissingPlayerMessage, playerName, this.Name));
            }

            this.playerList.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}