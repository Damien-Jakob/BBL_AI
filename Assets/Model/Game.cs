using System;
using UnityEngine;

namespace Assets.Model
{
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

            PutPlayer(player, startingCoordinates.x + movementX, startingCoordinates.y);
            return true;
        }

        public void PutPlayer(Player player, int destinationX, int destinationY)
        {
            if(player.PitchLocation != null)
            {
                player.PitchLocation.Player = null;
            }
            player.PitchLocation = Pitch.Locations[destinationX, destinationY];
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
