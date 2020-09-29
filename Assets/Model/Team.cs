using System.Collections.Generic;

namespace Assets.Model
{
    public class Team
    {
        protected List<Player> players = new List<Player>();
        public Coach Coach { get; set; }

        public Team(Coach coach)
        {
            Coach = coach;
        }

        public List<Player> Players { get
            {
                return players;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        } 
    }
}
