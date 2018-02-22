namespace _18.Football_League
{
    public class Team
    {
        public Team(string name, int score, int goals)
        {
            Name = name;
            Score = score;
            Goals = goals;
        }

        public string Name { get; set; }
        public int Score { get; set; }
        public int Goals { get; set; }
    }
}
