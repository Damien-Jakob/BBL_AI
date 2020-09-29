namespace Assets.Model
{
    public class Player
    {
        public Team Team { get; protected set; }
        public PitchLocation PitchLocation { get; set; } = null;

        public Player(Team team)
        {
            Team = team;
            team.AddPlayer(this);
        }
    }
}
