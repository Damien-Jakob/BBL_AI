using System;
using UnityEngine;

namespace Assets.Model
{
    // TODO ball events
    public class Game
    {
        public Team Team { get; set; }
        public Pitch Pitch { get; set; }

        public bool MovePlayer(Player player, int movementX)
        {
            if (movementX > 1 || movementX < -1)
            {
                throw new TooBigMovementException();
            }

            Vector2Int startingCoordinates = player.PitchLocation.Coordinates;
            int destinationX = startingCoordinates.x + movementX;
            int destinationY = startingCoordinates.y;

            if (!Pitch.ValidateCoordonates(destinationX, destinationY))
            {
                return false;
            }

            PutPlayer(player, startingCoordinates.x + movementX, startingCoordinates.y, false);
            player.OnMove.Invoke(player.PitchLocation.Coordinates);

            return true;
        }

        protected void PutPlayer(Player player, int destinationX, int destinationY, bool sendEvent)
        {
            if (player.PitchLocation != null)
            {
                player.PitchLocation.Player = null;
            }
            player.PitchLocation = Pitch.Locations[destinationX, destinationY];

            if(sendEvent)
            {
                player.OnPut.Invoke(player.PitchLocation.Coordinates);
            }
        }

        public void PutPlayer(Player player, int destinationX, int destinationY)
        {
            PutPlayer(player, destinationX, destinationY, true);
        }

        public void PutBall(int destinationX, int destinationY)
        {
            Pitch.BallLocation = Pitch.Locations[destinationX, destinationY];
        }
    }

    public class TooBigMovementException : Exception
    {

    }
}
