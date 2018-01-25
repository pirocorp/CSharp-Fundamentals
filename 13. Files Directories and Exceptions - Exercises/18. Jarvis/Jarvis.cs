using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.Jarvis
{
    class Jarvis
    {
        static void Main()
        {
            var maximumEnergyCapacity = long.Parse(Console.ReadLine());
            var inputData = Console.ReadLine();
            var listOfArms = new List<Arm>();
            var listOfLegs = new List<Leg>();
            Torso torsoResult = null;
            Head headResult = null;

            while (inputData != "Assemble!")
            {
                var tokens = inputData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var component = tokens[0];
                var componentData = String.Join(" ", tokens.Skip(1));

                switch (component)
                {
                    case "Arm":
                        AddElementToList(componentData, listOfArms);
                        break;
                    case "Leg":
                        AddElementToList(componentData, listOfLegs);
                        break;
                    case "Torso":
                        torsoResult = AddElement(torsoResult, componentData);
                        break;
                    case "Head":
                        headResult = AddElement(headResult, componentData);
                        break;
                }

                inputData = Console.ReadLine();
            }

            var egnouhParts = torsoResult != null && headResult != null && listOfLegs.Count == 2 && listOfArms.Count == 2;

            if (egnouhParts)
            {
                var currentPartEnergyNeeds = torsoResult.EnergyConsumption +
                                             headResult.EnergyConsumption +
                                             listOfLegs.Sum(x => x.EnergyConsumption) +
                                             listOfArms.Sum(x => x.EnergyConsumption);

                if (maximumEnergyCapacity >= currentPartEnergyNeeds)
                {
                    PrintRobot(headResult, torsoResult, listOfArms, listOfLegs);
                }
                else
                {
                    Console.WriteLine($"We need more power!");
                }
            }
            else
            {
                Console.WriteLine($"We need more parts!");
            }
        }

        private static void PrintRobot(Head headResult, Torso torsoResult, List<Arm> listOfArms, List<Leg> listOfLegs)
        {
            Console.WriteLine($"Jarvis:");
            Console.WriteLine(headResult.ToString());
            Console.WriteLine(torsoResult.ToString());

            foreach (var arm in listOfArms.OrderBy(x => x.EnergyConsumption))
            {
                Console.WriteLine(arm.ToString());
            }

            foreach (var leg in listOfLegs.OrderBy(x => x.EnergyConsumption))
            {
                Console.WriteLine(leg.ToString());
            }
        }

        private static void AddElementToList(string componentData, List<Leg> listOfLegs)
        {
            var currentLeg = Leg.Parse(componentData);

            if (listOfLegs.Count < 2)
            {
                listOfLegs.Add(currentLeg);
            }
            else
            {
                var existBigger = listOfLegs.Any(x => x.EnergyConsumption > currentLeg.EnergyConsumption);

                if (existBigger)
                {
                    var legToRemove = listOfLegs.Where(x => x.EnergyConsumption > currentLeg.EnergyConsumption).First();
                    listOfLegs.Remove(legToRemove);
                    listOfLegs.Add(currentLeg);
                }
            }
        }

        private static void AddElementToList(string componentData, List<Arm> listOfArms)
        {
            var currentArm = Arm.Parse(componentData);

            if (listOfArms.Count < 2)
            {
                listOfArms.Add(currentArm);
            }
            else
            {
                var existBigger = listOfArms.Any(x => x.EnergyConsumption > currentArm.EnergyConsumption);

                if (existBigger)
                {
                    var armToRemove = listOfArms.Where(x => x.EnergyConsumption > currentArm.EnergyConsumption).First();
                    listOfArms.Remove(armToRemove);
                    listOfArms.Add(currentArm);
                }
            }
        }

        private static Head AddElement(Head headResult, string componentData)
        {
            if (headResult == null)
            {
                headResult = Head.Parse(componentData);
            }
            else
            {
                var currentElement = Head.Parse(componentData);

                if (headResult.EnergyConsumption > currentElement.EnergyConsumption)
                {
                    headResult = currentElement;
                }
            }

            return headResult;
        }

        private static Torso AddElement(Torso torsoResult, string componentData)
        {
            if (torsoResult == null)
            {
                torsoResult = Torso.Parse(componentData);
            }
            else
            {
                var currentElement = Torso.Parse(componentData);

                if (torsoResult.EnergyConsumption > currentElement.EnergyConsumption)
                {
                    torsoResult = currentElement;
                }
            }

            return torsoResult;
        }
    }
}
