namespace Assets.Model
{
    public class Player
    {
        public Team Team { get; protected set; }
        public PitchLocation PitchLocation { get; set; } = null;

        public EventPut OnPut { get; protected set; }
        public EventMove OnMove { get; protected set; }

        public Player(Team team)
        {
            Team = team;
            team.AddPlayer(this);

            OnPut = new EventPut();
            OnMove = new EventMove();
        }
    }
}
