namespace Assets.Model
{
    public class Player
    {
        public Team Team { get; protected set; }
        public PitchLocation PitchLocation { get; set; } = null;

        protected Pitch Pitch
        {
            get
            {
                return PitchLocation.Pitch;
            }
        }

        public bool HasBall
        {
            get
            {
                return PitchLocation == Pitch.Ball.PitchLocation;
            }
        }

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
