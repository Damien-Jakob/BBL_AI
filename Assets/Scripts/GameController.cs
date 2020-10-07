using Assets.Model;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Game game;

    void Start()
    {
        // Initialize Model
        // Temp game data
        Coach coach = new HumanCoach();
        Team team = new Team(coach);
        Player testplayer1 = new Player(team);
        Player testplayer2 = new Player(team);

        // Initialize Game
        game = new Game(team);

        // Initialize View
        // Initialize Pitch
        GameObject.FindGameObjectWithTag("Pitch").GetComponent<PitchController>().Initialize(game.Pitch);

        // Initialize ball
        BallController ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        ballController.Initialize(game.Pitch.Ball);

        // Initialize players
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        foreach(Player player in team.Players)
        {
            GameObject playerRepresentation = Instantiate(playerPrefab);
            PlayerController playerController = playerRepresentation.GetComponent<PlayerController>();
            playerController.Initialize(player);
        }


        // Test Player Movement
        game.PutPlayer(testplayer1, 0, 3);
        game.PutPlayer(testplayer2, 10, 10);
        game.PutBall(new Vector2Int(10, 10));

        game.MovePlayerAction(testplayer1, 1, 1);
        game.MovePlayerAction(testplayer2, -1, -1);        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO actions to move players
    }
}
