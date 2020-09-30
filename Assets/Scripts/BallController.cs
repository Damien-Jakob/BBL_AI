using UnityEngine;
using UnityEngine.Tilemaps;

public class BallController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Tilemap tilemap;

    protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GameObject.FindGameObjectWithTag("GroundTilemap").GetComponent<Tilemap>();
    }

    public void Put(int positionX, int positionY)
    {
        Vector3Int position3D = new Vector3Int(positionX, positionY, 0);
        Vector3 target = tilemap.CellToWorld(position3D);
        transform.position = target;
    }
}
