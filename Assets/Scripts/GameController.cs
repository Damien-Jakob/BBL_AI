using Assets.Model;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Game Game { get; protected set; }

    void Start()
    {
        // Initialize Model
        // Temp game data
        Coach coach = new HumanCoach();
        Team team = new Team(coach);
        Player testplayer1 = new Player(team);
        Player testplayer2 = new Player(team);

        // Initialize Game
        Game = new Game(team);

        // Initialize View
        // Initialize Pitch
        GameObject.FindGameObjectWithTag("Pitch").GetComponent<PitchController>().Initialize(Game.Pitch);

        // Initialize ball
        BallController ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        ballController.Initialize(Game.Pitch.Ball);

        // Initialize players
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        foreach (Player player in team.Players)
        {
            GameObject playerRepresentation = Instantiate(playerPrefab);
            PlayerController playerController = playerRepresentation.GetComponent<PlayerController>();
            playerController.Initialize(player);
        }

        // Test Player Movement
        Game.PutPlayer(testplayer1, 0, 3);
        Game.PutPlayer(testplayer2, 10, 10);
        Game.PutBall(5, 5);

        Game.SetActivePlayerAction(testplayer1);
        Game.MovePlayerAction(1, 1);
        Game.SetActivePlayerAction(testplayer2);
        Game.MovePlayerAction(-1, -1);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO actions to move players
    }
}
