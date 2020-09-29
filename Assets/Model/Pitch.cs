using UnityEngine;

public class Pitch
{
    public static readonly int Width = 15;
    public static readonly int Height = 26;
    public static readonly int WideZoneWidth = 4;
    // TODO WidezoneLeftEnd, WidezoneRightStart

    public static readonly Vector2Int TrapDoor1Location = new Vector2Int(1, 6);
    public static readonly Vector2Int TrapDoor2Location = new Vector2Int(13, 19);

    protected readonly PitchLocation[,] locations = new PitchLocation[Width, Height];

    public Pitch()
    {
        for(int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                locations[x, y] = new PitchLocation(x, y, this);
            }
        }
    }

    public PitchLocation[,] Locations
    {
        get
        {
            return locations;
        }
    }
}
