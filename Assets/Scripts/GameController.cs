using Assets.Model;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Game game;

    void Start()
    {
        // Temp game data
        Coach coach = new HumanCoach();
        Team team = new Team(coach);
        Player testplayer1 = new Player(team);
        Player testplayer2 = new Player(team);

        // Initialize game
        game = new Game();
        game.Team = team;
        game.Pitch = GameObject.FindGameObjectWithTag("Pitch").GetComponent<PitchController>().Pitch;

        // Initialize ball
        BallController ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        ballController.Initialize(game);

        // Initialize players
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        foreach(Player player in team.Players)
        {
            GameObject playerRepresentation = Instantiate(playerPrefab);
            PlayerController playerController = playerRepresentation.GetComponent<PlayerController>();
            playerController.Initialize(player);
        }

        // Test Movement
        game.PutPlayer(testplayer1, 0, 3);
        game.PutPlayer(testplayer2, 10, 10);
        game.MovePlayer(testplayer1, 1);
        game.MovePlayer(testplayer2, -1);

        // Ball test
        // TODO should be subscibed to event
        Movement ballMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<Movement>();
        ballMovement.Put(new Vector2Int(0, 1));
        ballMovement.StartMovingTo(new Vector2Int(1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        // TODO actions to move players
    }
}
