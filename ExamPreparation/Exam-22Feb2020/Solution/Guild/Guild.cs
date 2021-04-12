using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => this.roster.Count; }

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player wantedPlayer = roster.Find(x => x.Name == name);

            if (wantedPlayer != null)
            {
                roster.Remove(wantedPlayer);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    if (player.Rank == "Trial")
                    {
                        player.Rank = "Member";
                    }
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    if (player.Rank == "Member")
                    {
                        player.Rank = "Trial";
                    }
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var removedPlayers = roster.Where(x => x.Class == @class).ToArray();
            roster = roster.Where(x => x.Class != @class).ToList();
            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine($"{player}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
