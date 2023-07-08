using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //ref
    public Transform player;
    public Vector3 offset;


    void Update()
    {
        transform.position = player.position + offset;
    }
}
