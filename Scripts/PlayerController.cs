using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Instantiat fields
    private Rigidbody2D rb2D;

    private float moveSpeed;

    private float jumpForce;
    private bool isJumping; 
    private bool canJump;

    private float moveHorizontal;

    // This is where the player will respawn if they fall
    private Vector3 respawnPoint;
   



    // Start is called before the first frame update
    void Start()
    {
        // Asigns values to all instantiated variables
        
        // Calls the rigid body of the player
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        // Jumping and moving variables
        moveSpeed = 1.8f;
        jumpForce = 35f;
        isJumping = false;
        canJump = false;
    

        // Sets the player's respawn point to where they originally start
        respawnPoint = transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        // Both of these return values between -1 and 1:
        // Checks if the player has pressed A, D, -> or <-
        moveHorizontal = Input.GetAxisRaw("Horizontal");


        // Flips the character depending on if they are facing left or right
        if(moveHorizontal > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(moveHorizontal < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Checks if jump button is already held down, prevents player from holding the jump button and makes the game feel nicer
        if (!isJumping && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            canJump = true;
        }

    }

    // Constantly checks physics engine
    void FixedUpdate()
    {
        // Checks if player is moving left or right, we use 0.1 due to margin of error as 0 might very occasionally
        // be slightly smaller or bigger than 0
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            // This makes the player move, it takes in the x and y axis as parameters.
            // Normally, moveHorizontal is -1 or 1, which won't move our character by that much. To combat this,
            // we multiply it by "moveSpeed". So if we get 1, we get 3 as input (as 1 * 3 = 3)
            // Impulse makes the character have an instantaneous force applied to it.
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        // Checks if player is jumping/pressing the jump button
        if(!isJumping && canJump == true)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }


    }

    // Returns False if the player is unable to summon a fireball (while moving, if they're in the air and or if the cooldown hasnt finished)
    // The player also cannot use the fireball spell before getting the magic rock
    public bool canFireball()
    {
        return moveHorizontal == 0f && !isJumping; // && camera cooldown is not finished && has_obtained_the_rock == false
    }



    // a method that checks if a collider is hitting into something
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

        if(collision.tag == "Death")
        {
            transform.position = respawnPoint;
        }
    }

    // a method that checks if a collider is no longer hitting into something
   void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
