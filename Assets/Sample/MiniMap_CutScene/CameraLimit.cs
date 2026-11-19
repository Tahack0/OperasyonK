using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public Transform Player;
     void LateUpdate()
    {
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }
}
