namespace _10.Nether_Realms
{
    public class Demon
    {
        public Demon(string demonName, int demonHealth, double demonDamage)
        {
            DemonName = demonName;
            DemonHealth = demonHealth;
            DemonDamage = demonDamage;
        }

        public string DemonName { get; set; }
        public int DemonHealth { get; set; }
        public double DemonDamage { get; set; }
    }
}
