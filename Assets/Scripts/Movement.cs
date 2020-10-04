using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    Tilemap tilemap;

    float speed = 1f;

    public void Initialize()
    {
        tilemap = GameObject.FindGameObjectWithTag("GroundTilemap").GetComponent<Tilemap>();
    }

    public void Put(Vector2Int position)
    {
        Vector3Int position3D = Position3D(position);
        Vector3 target = tilemap.CellToWorld(position3D);
        transform.position = target;
    }

    public void StartMovingTo(Vector2Int position)
    {
        Vector3Int position3D = Position3D(position);
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

    protected Vector3Int Position3D(Vector2Int position)
    {
        return new Vector3Int(position.x, position.y, 0);
    }
}
