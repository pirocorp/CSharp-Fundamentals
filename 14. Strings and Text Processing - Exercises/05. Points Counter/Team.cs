namespace _05.Points_Counter
{
    using System.Collections.Generic;

    class Team
    {
        public Team(string teamName)
        {
            TeamName = teamName;
            Players = new List<Player>();
        }

        public Team(string teamName, List<Player> players)
        {
            TeamName = teamName;
            Players = players;
        }

        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
    }
}
