using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double threshold = double.Parse(Console.ReadLine());

        double lastPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double currentPrice = double.Parse(Console.ReadLine());
            double priceDifference = FindPriceDifference(lastPrice, currentPrice);
            bool SignificantDifference = FindIfIsSignificantDifference(priceDifference, threshold);
            string message = Get(currentPrice, lastPrice, priceDifference, SignificantDifference);
            Console.WriteLine(message);
            lastPrice = currentPrice;
        }
    }

    private static string Get(double currentPrice, double lastPrice, double difference, bool SignificantDifference)
    {
        string to = "";

        if (difference == 0)
        {
            to = string.Format("NO CHANGE: {0}", currentPrice);
        }
        else if (!SignificantDifference)
        {
            to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference * 100);
        }
        else if (SignificantDifference && (difference > 0))
        {
            to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference * 100);
        }
        else if (SignificantDifference && (difference < 0))
            to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference * 100);
        return to;
    }

    private static bool FindIfIsSignificantDifference(double priceDifference, double threshold)
    {
        if (Math.Abs(priceDifference) >= threshold)
        {
            return true;
        }
        return false;
    }

    private static double FindPriceDifference(double lastPrice, double currentPrice)
    {
        double result = (currentPrice - lastPrice) / lastPrice;
        return result;
    }
}
