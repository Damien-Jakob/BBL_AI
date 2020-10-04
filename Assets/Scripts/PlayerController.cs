using Assets.Model;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Initialize(Player player)
    {
        Player = player;

        Movement movement = GetComponent<Movement>();
        movement.Initialize();
        Player.OnPut.AddListener(movement.Put);
        Player.OnMove.AddListener(movement.StartMovingTo);

        if(player.PitchLocation != null)
        {
            movement.Put(Player.PitchLocation.Coordinates);
        }
    }

    public Player Player { get; set; }
}
