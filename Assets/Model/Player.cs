using UnityEngine.Events;

namespace Assets.Model
{
    public class Player
    {
        public Team Team { get; protected set; }
        public PitchLocation PitchLocation { get; set; } = null;

        public bool HasBall
        {
            get
            {
                return PitchLocation == Pitch.Ball.PitchLocation;
            }
        }
        public UnityEvent OnSetActive { get; protected set; }
        public UnityEvent OnSetInactive { get; protected set; }
        public EventPut OnPut { get; protected set; }
        public EventMove OnMove { get; protected set; }

        public Player(Team team)
        {
            Team = team;
            team.AddPlayer(this);

            OnSetActive = new UnityEvent();
            OnSetInactive = new UnityEvent();
            OnPut = new EventPut();
            OnMove = new EventMove();
        }

        protected Pitch Pitch
        {
            get
            {
                return PitchLocation.Pitch;
            }
        }
    }
}
