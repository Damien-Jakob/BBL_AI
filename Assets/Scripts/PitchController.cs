using UnityEngine;

public class PitchController : MonoBehaviour
{
    protected static readonly string PitchLocationPrefabPath = "prefabs/Pitch Location";

    protected Pitch pitch = new Pitch();

    protected GameObject pitchLocationPrefab;
    protected float pitchLocationSize;

    void Start()
    {
        pitchLocationPrefab = Resources.Load<GameObject>(PitchLocationPrefabPath);
        for(int x = 0; x < Pitch.Width; x++)
        {
            for(int y = 0; y < Pitch.Height; y++)
            {
                GameObject pitchLocation = Instantiate(pitchLocationPrefab, transform);
                pitchLocation.GetComponent<PitchLocationController>().Initialize(pitch.Locations[x, y]);
            }
        }
    }
}
