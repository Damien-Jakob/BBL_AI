using Assets.Model;
using UnityEngine;

public class PitchController : MonoBehaviour
{
    const string PitchLocationPrefabPath = "prefabs/Pitch Location";

    public void Initialize(Pitch pitch)
    {
        GameObject pitchLocationPrefab = Resources.Load<GameObject>(PitchLocationPrefabPath);
        for (int x = 0; x < Pitch.Width; x++)
        {
            for (int y = 0; y < Pitch.Height; y++)
            {
                GameObject pitchLocation = Instantiate(pitchLocationPrefab, transform);
                pitchLocation.GetComponent<PitchLocationController>().Initialize(pitch.Locations[x, y]);
            }
        }
    }
}
