namespace Assets.Model
{
    public class Ball
    {
        public PitchLocation PitchLocation { get; set; } = null;

        public EventPut OnPut { get; protected set; }
        public EventMove OnMove { get; protected set; }

        public Ball()
        {
            OnPut = new EventPut();
            OnMove = new EventMove();
        }
    }
}
