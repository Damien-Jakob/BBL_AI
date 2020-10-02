using Assets.Model;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Tilemap tilemap;

    float speed = 1f;

    public void Initialize(Player player)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GameObject.FindGameObjectWithTag("GroundTilemap").GetComponent<Tilemap>();

        Player = player;

        Put(Player.PitchLocation.Coordinates.x, Player.PitchLocation.Coordinates.y);
    }

    public Player Player { get; set; }

    public void Put(int positionX, int positionY)
    {
        Vector3Int position3D = Position3D(positionX, positionY);
        Vector3 target = tilemap.CellToWorld(position3D);
        transform.position = target;
    }

    public void StartMovingTo(int positionX, int positionY)
    {
        Vector3Int position3D = Position3D(positionX, positionY);
        Vector3 target = tilemap.CellToWorld(position3D);
        StartCoroutine(MoveTo(target));
    }

    IEnumerator MoveTo(Vector3 target)
    {
        while ((transform.position - target).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    protected Vector3Int Position3D(int positionX, int positionY)
    {
        return new Vector3Int(positionX, positionY, 0);
    }
}
