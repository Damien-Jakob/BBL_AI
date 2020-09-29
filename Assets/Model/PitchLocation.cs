using UnityEngine;

namespace Assets.Model
{
    public class PitchLocation
    {
        protected readonly Vector2Int coordinates;
        protected readonly bool hasTrapDoor;

        protected Pitch pitch;

        public PitchLocation(int x, int y, Pitch pitch)
        {
            coordinates = new Vector2Int(x, y);
            hasTrapDoor = (coordinates == Pitch.TrapDoor1Location)
                || (coordinates == Pitch.TrapDoor2Location);
            this.pitch = pitch;
        }

        public Vector2Int Coordinates
        {
            get { return coordinates; }
        }

        public bool BelongsBottom
        {
            get { return Coordinates.x < 13; }
        }

        public bool BelongsTop
        {
            get { return !BelongsBottom; }
        }

        public bool BelongsEndZoneBottom
        {
            get { return Coordinates.y == 0; }
        }

        public bool BelongsEndZoneTop
        {
            get { return Coordinates.y == Pitch.Height - 1; }
        }

        public bool BelongsEndZone
        {
            get { return BelongsEndZoneBottom || BelongsEndZoneTop; }
        }

        public bool BelongsWideZoneRight
        {
            get { return Coordinates.x < Pitch.WideZoneWidth; }
        }

        public bool BelongsWideZoneLeft
        {
            get { return Coordinates.x >= 11; }
        }

        public bool BelongsWideZone
        {
            get { return BelongsWideZoneLeft || BelongsWideZoneRight; }
        }

        public bool BelongsWideZoneBottom
        {
            get { return BelongsWideZone && BelongsBottom; }
        }

        public bool BelongsWideZoneTop
        {
            get { return BelongsWideZone && BelongsTop; }
        }

        public bool BelongsWideZoneBottomRight
        {
            get { return BelongsWideZoneRight && BelongsBottom; }
        }

        public bool BelongsWideZoneTopight
        {
            get { return BelongsWideZoneRight && BelongsTop; }
        }

        public bool BelongsWideZoneBottomLeft
        {
            get { return BelongsWideZoneLeft && BelongsBottom; }
        }

        public bool BelongsWideZoneTopLeft
        {
            get { return BelongsWideZoneLeft && BelongsTop; }
        }

        public bool HasTrapDoor
        {
            get { return hasTrapDoor; }
        }
    }
}
