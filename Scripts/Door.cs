using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   private Transform previousRoom;
   private Transform nextRoom;
   public CameraMovement camera;

   // Checks if the player object has collided with the door object
   public void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.tag == "Player")
      {
         // If player enters from the left, move camera to the right room
         if(collision.transform.position.x < transform.position.x)
         
            camera.MoveToNewRoom(nextRoom);
         // If player enters from the right, move camera to the left room
         else
         
            camera.MoveToNewRoom(previousRoom);
         
      }
   }
}
