using System;
using System.Numerics;

namespace _25.Anonymous_Downsite
{
    class AnonymousDownsite
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            string allAffectedWebsites = string.Empty;
            decimal totalMoneyLoss = 0;
            for (int i = 0; i < n; i++)
            {
                char[] charSeparators =  { ' ' };
                string[] websiteData = Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                allAffectedWebsites += websiteData[0];
                allAffectedWebsites += "\n";
                totalMoneyLoss += LossFromSite(websiteData[1], websiteData[2]);
            }

            BigInteger securityToken = BigInteger.Pow(securityKey, n);
            if (allAffectedWebsites.Length > 0)
            {
                allAffectedWebsites = allAffectedWebsites.Remove(allAffectedWebsites.Length - 1);
            }

            Console.WriteLine(allAffectedWebsites);
            Console.WriteLine($"Total Loss: {totalMoneyLoss:f20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }

        private static decimal LossFromSite(string siteVisitsString, string siteCommercialPricePerVisitString)
        {
            long siteVisits = long.Parse(siteVisitsString);
            decimal siteCommercialPricePerVisit = decimal.Parse(siteCommercialPricePerVisitString);

            return siteVisits * siteCommercialPricePerVisit;
        }
    }
}
