using Assets.Model;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Game game;
    BallController ballController;

    void Start()
    {
        ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();

        // Temp data
        Coach coach = new HumanCoach();
        Team team = new Team(coach);
        Player player = new Player(team);

        game = new Game();
        game.Team = team;
        game.Pitch = GameObject.FindGameObjectWithTag("Pitch").GetComponent<PitchController>().Pitch;

        game.PutPlayer(player, 0, 3);
        game.PutBall(0, 1);
        ballController.Put(0, 1);
        ballController.StartMovingTo(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
