using System;
using UnityEngine;

namespace Assets.Model
{
    public class Game
    {
        public Pitch Pitch { get; set; }
        public Team Team { get; set; }

        public Game(Team team)
        {
            Pitch = new Pitch();
            Team = team;
        }

        public bool MovePlayer(Player player, int movementX, int movementY)
        {
            // Invalid movement
            if (movementX > 1 || movementX < -1
                || movementY > 1 || movementY < -1)
            {
                throw new TooBigMovementException();
            }

            // Useless movement
            if (movementX == 0 && movementY == 0)
            {
                return false;
            }

            Vector2Int startingCoordinates = player.PitchLocation.Coordinates;
            int destinationX = startingCoordinates.x + movementX;
            int destinationY = startingCoordinates.y + movementY;

            // Invalid destination
            if (!Pitch.ValidateCoordonates(destinationX, destinationY))
            {
                return false;
            }

            PutPlayer(player, destinationX, destinationY, false);
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

            if (sendEvent)
            {
                player.OnPut.Invoke(player.PitchLocation.Coordinates);
            }
        }

        public void PutPlayer(Player player, int destinationX, int destinationY)
        {
            PutPlayer(player, destinationX, destinationY, true);
        }

        public void PutBall(Vector2Int destination)
        {
            Pitch.Ball.PitchLocation = Pitch.Locations[destination.x, destination.y];
            Pitch.Ball.OnPut.Invoke(destination);
        }

        // TODO set protected once it has been tested
        public void MoveBall(Vector2Int destination)
        {
            Pitch.Ball.PitchLocation = Pitch.Locations[destination.x, destination.y];
            Pitch.Ball.OnMove.Invoke(destination);
        }
    }

    public class TooBigMovementException : Exception
    {

    }
}
