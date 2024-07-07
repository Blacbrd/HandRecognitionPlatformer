using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    
    private float speed;
    private float currentPositionX;
    private Vector3 velocity = Vector3.zero;

    // Checks each frame to see if the player has interacted with the door object
    public void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    // Sets the current position of the camera to the new room
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPositionX = _newRoom.position.x;
    }
}
