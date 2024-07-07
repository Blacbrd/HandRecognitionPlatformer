using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private Transform position1, position2;
    private float speed;
    private Vector3 targetPosition;
    private bool appear = false;

    
    void Start()
    {
        targetPosition = position1.position;
    }
    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.K) || appear == true) // add cooldown timer
        {
            // Sets a flag so that the platform stays appeared even when K is not pressed
            appear = true;

            // If the platform is close to the first position, it moves to the second position
            if (Vector2.Distance(transform.position, position1.position) < 0.05f)
            {
                targetPosition = position2.position;
            }
            // If the platform is close to the second position, it moves to the first position
            if (Vector2.Distance(transform.position, position2.position) < 0.05f)
            {
                targetPosition = position1.position;
                appear = false;
            }
        }
        
        // Moves platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
