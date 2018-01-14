using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Batteries
{
    class Batteries
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var capacitiesOfBatteriesInmAh = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            var usagePerHour = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            var hoursOfTest = int.Parse(Console.ReadLine());

            for (int i = 0; i < capacitiesOfBatteriesInmAh.Count; i++)
            {
                var canLastHours = Math.Ceiling(capacitiesOfBatteriesInmAh[i] / (usagePerHour[i]));

                if (canLastHours <= hoursOfTest)
                {
                    Console.WriteLine($"Battery {i + 1}: dead (lasted {canLastHours} hours)");
                }
                else
                {
                    var leftCharge = capacitiesOfBatteriesInmAh[i] - (usagePerHour[i] * hoursOfTest);
                    var percentage = (leftCharge / capacitiesOfBatteriesInmAh[i]) * 100.0;
                    Console.WriteLine($"Battery {i + 1}: {leftCharge:f2} mAh ({percentage:f2})%");
                }
            }
        }
    }
}
