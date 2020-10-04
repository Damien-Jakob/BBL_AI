using Assets.Model;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public void Initialize(Ball ball)
    {
        Movement movement = GetComponent<Movement>();
        movement.Initialize();
        ball.OnPut.AddListener(movement.Put);
        ball.OnMove.AddListener(movement.StartMovingTo);
    }
}
