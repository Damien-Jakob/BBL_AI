using Assets.Model;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player Player { get; set; }

    protected GameController GameController { get; set; }

    public void Initialize(Player player)
    {
        GameController = Camera.main.GetComponent<GameController>();

        Player = player;
        
        Movement movement = GetComponent<Movement>();
        movement.Initialize();
        Player.OnPut.AddListener(movement.Put);
        Player.OnMove.AddListener(movement.StartMovingTo);

        if(player.PitchLocation != null)
        {
            movement.Put(Player.PitchLocation.Coordinates);
        }

        // TODO subscribe to active/inactive events
    }

    private void OnMouseDown()
    {
        GameController.Game.SetActivePlayerAction(Player);
    }

    private void SetActive()
    {
        // TODO logic
        print("Activating");
    }

    private void SetInactive()
    {
        // TODO logic
        print("Deactivating");
    }
}
