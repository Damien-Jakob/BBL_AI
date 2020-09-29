using UnityEngine;
using UnityEngine.Tilemaps;

public class PitchLocationController : MonoBehaviour
{
    protected PitchLocation pitchLocation;

    protected static Tilemap groundTilemap;
    // TODO Array
    protected static Tilemap groundDecorationTilemap1;
    protected static Tilemap groundDecorationTilemap2;
    protected static Tile groundTile;
    protected static Tile lineTile;

    protected static readonly Color green1 = new Color(0.2f, 0.5f, 0.25f);
    protected static readonly Color green2 = new Color(0.35f, 0.9f, 0.43f);
    protected static readonly Color green3 = new Color(0.4f, 1f, 0.5f);
    protected static readonly Color green4 = new Color(0.3f, 0.75f, 0.36f);

    protected static readonly Color green5 = new Color(0.1f, 0.25f, 0.12f);

    protected static readonly Color brown = new Color(0.45f, 0.3f, 0.3f);

    protected static readonly Color[,] colorMap = new Color[2, 2] {
        { green1, green2 },
        { green3, green4 }
    };


    private void Awake()
    {
        if (!groundTilemap)
        {
            groundTilemap = GameObject.FindGameObjectWithTag("GroundTilemap")
                .GetComponent<Tilemap>();
            print(groundTilemap);
            groundDecorationTilemap1 = GameObject.FindGameObjectWithTag("GroundDecorationTilemap1")
                .GetComponent<Tilemap>();
            print(groundTilemap);
            groundDecorationTilemap2 = GameObject.FindGameObjectWithTag("GroundDecorationTilemap2")
                .GetComponent<Tilemap>();
            print(groundTilemap);
            groundTile = Resources.Load<Tile>("Tiles/Square");
            lineTile = Resources.Load<Tile>("Tiles/PitchLine");
        }
    }

    public void Initialize(PitchLocation pitchLocation)
    {
        this.pitchLocation = pitchLocation;

        AddTile();
    }

    protected void AddTile()
    {
        Vector2Int coordinates = pitchLocation.Coordinates;
        Vector3Int coordinates3d = new Vector3Int(coordinates.x, coordinates.y, 0);

        groundTilemap.SetTile(coordinates3d, groundTile);
        groundTilemap.SetTileFlags(coordinates3d, TileFlags.None);
        groundTilemap.SetColor(coordinates3d, colorMap[coordinates.x % 2, coordinates.y % 2]);

        // TODO LOS
        // TODO endzones
        // TODO angles -> 2 layers
        // TODO hardcode -> const, calculées
        if (pitchLocation.Coordinates.x == 3 ||
            pitchLocation.Coordinates.x == 4 ||
            pitchLocation.Coordinates.x == 10 ||
            pitchLocation.Coordinates.x == 11)
        {
            groundDecorationTilemap1.SetTile(coordinates3d, lineTile);
            groundDecorationTilemap1.SetTileFlags(coordinates3d, TileFlags.None);

            if (pitchLocation.Coordinates.x == 4 ||
                pitchLocation.Coordinates.x == 11)
            {
                rotateTile(groundDecorationTilemap1, coordinates3d, 180);
            }
        }


        if (pitchLocation.BelongsEndZone ||
            pitchLocation.Coordinates.y == 1 ||
            pitchLocation.Coordinates.y == 12 ||
            pitchLocation.Coordinates.y == 13 ||
            pitchLocation.Coordinates.y == 24)
        {
            groundDecorationTilemap2.SetTile(coordinates3d, lineTile);
            groundDecorationTilemap2.SetTileFlags(coordinates3d, TileFlags.None);

            if (pitchLocation.BelongsEndZoneBottom ||
                pitchLocation.Coordinates.y == 12 ||
                pitchLocation.Coordinates.y == 24)
            {
                rotateTile(groundDecorationTilemap2, coordinates3d, 90);
            }
            else
            {
                rotateTile(groundDecorationTilemap2, coordinates3d, 270);
            }

        }


        if (pitchLocation.HasTrapDoor)
        {
            // TODO trapdoor sprite
            groundDecorationTilemap1.SetTile(coordinates3d, groundTile);
            groundDecorationTilemap1.SetTileFlags(coordinates3d, TileFlags.None);
            groundDecorationTilemap1.SetColor(coordinates3d, brown);
        }
    }

    protected void rotateTile(Tilemap tilemapContainer, Vector3Int tileCoordonates, float rotationDegree)
    {
        tilemapContainer.SetTransformMatrix(tileCoordonates, Matrix4x4.TRS(
                    Vector3.zero, Quaternion.Euler(0, 0, rotationDegree), Vector3.one));
    }
}
