using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCool : MonoBehaviour
{

    private float FBCooldown;
    private Transform firePoint;
    private GameObject[] fireballs; // List of all the fireballs
    
    private Animator anim;
    private PlayerController PlayerController;
    private float cooldownTimer = 1000f; // (This is to make sure the player can attack from the moment they open the game)
    
    private bool fireballSent = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerController = GetComponent<PlayerController>();
    }

    // Checks if J is pressed and if enough time has passed since the last button press to prevent spamming
    private void Update()
    {
        if(((Input.GetKeyDown(KeyCode.J) || fireballSent) && cooldownTimer > FBCooldown && PlayerController.canFireball())) 
        {
            fireballSent = false;
            SummonFireball();
        }
        cooldownTimer += Time.deltaTime;
    }

    // Once the sent character is recognised (J), set fireball to true
    public void setFireballTrue()
    {
        fireballSent = true;
    }

    // This grabs the fireballs stored in the fireball array, and transforms them to the player's firepoint.
    public void SummonFireball()
    {
        anim.SetTrigger("fireball");
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<FireballProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
