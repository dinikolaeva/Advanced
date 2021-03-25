using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var statisticsOfVloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (input != "Statistics")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = data[0];
                string action = data[1];
                string secondVloggerName = "";

                if (data.Length == 3)
                {
                    secondVloggerName = data[2];
                }

                if (action == "joined")
                {
                    Joined(statisticsOfVloggers, vloggerName);
                }
                else if (action == "followed")
                {
                    Followed(statisticsOfVloggers, vloggerName, secondVloggerName);
                }
                input = Console.ReadLine();
            }

            StringBuilder statistic = new StringBuilder();

            statistic.AppendLine($"The V-Logger has a total of {statisticsOfVloggers.Count} vloggers in its logs.");

            statisticsOfVloggers = statisticsOfVloggers.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            int counter = 1;

            foreach (var vlogger in statisticsOfVloggers)
            {
                if (counter == 1)
                {
                    statistic.AppendLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        statistic.AppendLine($"*  {follower}");
                    }
                    counter++;
                }
                else
                {
                    statistic.AppendLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                    counter++;
                }
            }

            Console.WriteLine(statistic.ToString().Trim());
        }

        private static void Followed(Dictionary<string, Dictionary<string, HashSet<string>>> statisticsOfVloggers, string vloggerName, string secondVloggerName)
        {
            string fallower = vloggerName;
            string followed = secondVloggerName;

            if (vloggerName != secondVloggerName &&
                statisticsOfVloggers.ContainsKey(vloggerName) &&
                statisticsOfVloggers.ContainsKey(secondVloggerName))
            {
                statisticsOfVloggers[followed]["followers"].Add(fallower);
                statisticsOfVloggers[fallower]["following"].Add(followed);
            }
        }

        private static void Joined(Dictionary<string, Dictionary<string, HashSet<string>>> statisticsOfVloggers, string vloggerName)
        {
            if (!statisticsOfVloggers.ContainsKey(vloggerName))
            {
                statisticsOfVloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                statisticsOfVloggers[vloggerName].Add("followers", new HashSet<string>());
                statisticsOfVloggers[vloggerName].Add("following", new HashSet<string>());
            }
        }
    }
}
