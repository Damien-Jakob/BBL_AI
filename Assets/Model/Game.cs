using System;
using UnityEngine;

namespace Assets.Model
{
    public class Game
    {
        public Pitch Pitch { get; set; }
        public Team Team { get; set; }

        protected Player activePlayer;
        public Player ActivePlayer
        {
            get
            {
                return activePlayer;
            }

            protected set
            {
                if(ActivePlayer != value)
                {
                    if(ActivePlayer != null)
                    {
                        ActivePlayer.OnSetInactive.Invoke();
                    }
                    activePlayer = value;
                    OnSetActivePlayer.Invoke(ActivePlayer);
                    ActivePlayer.OnSetActive.Invoke();
                }
            }
        }

        public EventSelectPlayer OnSetActivePlayer { get; protected set; }

        public Game(Team team)
        {
            Pitch = new Pitch();
            Team = team;

            OnSetActivePlayer = new EventSelectPlayer();
        }

        public void SetActivePlayerAction(Player player)
        {
            ActivePlayer = player;
        }

        public bool MovePlayerAction(int movementX, int movementY)
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

            Vector2Int startingCoordinates = ActivePlayer.PitchLocation.Coordinates;
            int destinationX = startingCoordinates.x + movementX;
            int destinationY = startingCoordinates.y + movementY;

            // Invalid destination
            if (!Pitch.ValidateCoordonates(destinationX, destinationY))
            {
                return false;
            }

            bool hasBall = ActivePlayer.HasBall;
            MovePlayer(ActivePlayer, destinationX, destinationY);
            if(hasBall)
            {
                MoveBall(ActivePlayer.PitchLocation.Coordinates);
            }
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

        protected void MovePlayer(Player player, int destinationX, int destinationY)
        {
            PutPlayer(player, destinationX, destinationY, false);
            player.OnMove.Invoke(player.PitchLocation.Coordinates);
        }

        public void PutBall(int destinationX, int destinationY)
        {
            Pitch.Ball.PitchLocation = Pitch.Locations[destinationX, destinationY];
            Pitch.Ball.OnPut.Invoke(Pitch.Ball.PitchLocation.Coordinates);
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
