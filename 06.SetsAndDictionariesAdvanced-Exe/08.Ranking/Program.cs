using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var data = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                var cmdArgs = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

                var contest = cmdArgs[0];
                var passForContest = cmdArgs[1];

                if (!data.ContainsKey(contest))
                {
                    data.Add(contest, passForContest);
                }
                data[contest] = passForContest;

                input = Console.ReadLine();
            }

            var commands = Console.ReadLine();

            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while (commands != "end of submissions")
            {
                CheckAndFillTheDictionary(data, commands, users);

                commands = Console.ReadLine();
            }

            BestResult(users);
            Console.WriteLine("Ranking:");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contest in user.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void BestResult(SortedDictionary<string, Dictionary<string, int>> users)
        {
            int bestResult = 0;
            string bestCandidate = string.Empty;

            foreach (var user in users)
            {
                int point = 0;

                foreach (var contest in user.Value)
                {
                    point += contest.Value;
                }

                if (bestResult < point)
                {
                    bestResult = point;
                    bestCandidate = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestResult} points.");
        }

        private static void CheckAndFillTheDictionary(Dictionary<string, string> data, string commands, SortedDictionary<string, Dictionary<string, int>> users)
        {
            var cmdArgs = commands.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            var recivedContest = cmdArgs[0];
            var recivedPass = cmdArgs[1];
            var username = cmdArgs[2];
            var points = int.Parse(cmdArgs[3]);

            if (data.ContainsKey(recivedContest) && data[recivedContest] == recivedPass)
            {
                if (data.ContainsKey(recivedContest) && data[recivedContest] == recivedPass)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                        users[username].Add(recivedContest, points);
                    }
                    else if (!users[username].ContainsKey(recivedContest))
                    {
                        users[username].Add(recivedContest, points);
                    }
                    else
                    {
                        if (points > users[username][recivedContest])
                        {
                            users[username][recivedContest] = points;
                        }
                    }
                }
            }
        }
    }
}