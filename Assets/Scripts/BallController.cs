using Assets.Model;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // TODO subscribe to ball game events
    public void Initialize(Game game)
    {
        Movement movement = GetComponent<Movement>();
        movement.Initialize();
    }
}
