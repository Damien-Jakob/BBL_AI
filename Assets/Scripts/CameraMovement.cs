using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    const float Speed = 10;

    const int MinY = 9;
    const int MaxY = 17;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("CameraY") != 0)
        {
            Vector3 position = Camera.main.transform.position;
            position.y += Input.GetAxis("CameraY") * Speed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, MinY, MaxY);

            Camera.main.transform.position = position;
        }
    }
}
