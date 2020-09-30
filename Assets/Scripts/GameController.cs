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
        Player testplayer1 = new Player(team);
        Player testplayer2 = new Player(team);

        game = new Game();
        game.Team = team;
        game.Pitch = GameObject.FindGameObjectWithTag("Pitch").GetComponent<PitchController>().Pitch;

        game.PutPlayer(testplayer1, 0, 3);
        game.PutPlayer(testplayer2, 10, 10);
        game.PutBall(0, 1);

        // ball test
        // TODO shold be called by game.putball
        ballController.Put(0, 1);
        ballController.StartMovingTo(1, 2);

        foreach(Player player in team.Players)
        {
            // TODO create player
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
