using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Tilemap tilemap;

    float speed = 1f;

    protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GameObject.FindGameObjectWithTag("GroundTilemap").GetComponent<Tilemap>();
    }

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
