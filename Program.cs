namespace uppgift_klockan
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    class Program
    {
        static int CalculateRoundPoints(string opponentChoice, string yourStrategy)
        {
            Dictionary<string, int> pointsTable = new Dictionary<string, int>
        {
            { "sten", 1 },
            { "påse", 2 },
            { "sax", 3 }
        };

            int opponentPoints = pointsTable[opponentChoice];

            if (yourStrategy == "X")
            {
                return 0; // Du förlorar
            }
            else if (yourStrategy == "Y")
            {
                return 3; // Lika
            }
            else if (yourStrategy == "Z")
            {
                return 6; // Du vinner
            }
            else
            {
                throw new ArgumentException("Ogiltig strategi: " + yourStrategy);
            }
        }

        static int CalculateTotalPoints(string strategyFile)
        {
            int totalPoints = 0;

            using (StreamReader reader = new StreamReader(strategyFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    string opponentChoice = parts[0];
                    string yourStrategy = parts[1];

                    int roundPoints = CalculateRoundPoints(opponentChoice, yourStrategy);
                    totalPoints += roundPoints;
                }
            }

            return totalPoints;
        }

        static void Main(string[] args)
        {
            string strategyFile = "C:\\Users\\kalle\\Downloads\\KarlMartensson.txt"; // Byt ut med namnet på din strategifil

            int totalPoints = CalculateTotalPoints(strategyFile);
            Console.WriteLine("Total poäng: " + totalPoints);
        }
    }
}