namespace _05.Points_Counter
{
    class Player
    {
        public Player(string name, int points)
        {
            PlayerName = name;
            Points = points;
        }

        public string PlayerName { get; set; }
        public int Points { get; set; }
    }
}
