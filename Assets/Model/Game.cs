﻿using System;
using UnityEngine;

namespace Assets.Model
{
    // TODO ball events
    public class Game
    {
        public Pitch Pitch { get; set; }
        public Team Team { get; set; }
        public Ball Ball { get; set; }

        public Game(Team team)
        {
            Pitch = new Pitch();
            Ball = new Ball();
            Team = team;
        }

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

        public void PutBall(Vector2Int destination)
        {
            Ball.PitchLocation = Pitch.Locations[destination.x, destination.y];
            Ball.OnPut.Invoke(destination);
        }

        // TODO delete, just there for test
        public void MoveBall(Vector2Int destination)
        {
            Ball.PitchLocation = Pitch.Locations[destination.x, destination.y];
            Ball.OnMove.Invoke(destination);
        }
    }

    public class TooBigMovementException : Exception
    {

    }
}
