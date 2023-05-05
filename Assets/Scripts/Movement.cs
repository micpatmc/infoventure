using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Handles the player movement
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------
    
    private Rigidbody2D rb;
    Vector2 movement;
    private Animator anim;

    public float speed;
    public int direction;

    public bool startingScreen;
    public bool starterConvo;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startingScreen = true;
        direction = 3;
    }

    private void Update()
    {
        // If not in the starting screen, correctly assign input values
        if (!startingScreen)
        {
            if (movement.y == 0)
                movement.x = Input.GetAxisRaw("Horizontal");

            if (movement.x == 0)
                movement.y = Input.GetAxisRaw("Vertical");
        }

        // Handles which direction the player is facing
        if (movement.x > 0)
            direction = 2;
        else if (movement.x < 0)
            direction = 1;
        else if (movement.y > 0)
            direction = 3;
        else if (movement.y < 0)
            direction = 0;

        // Set the animator velocity
        anim.SetFloat("velocityX", movement.x);
        anim.SetFloat("velocityY", movement.y);

        // Check if idle in animator
        if (movement.x == 0 && movement.y == 0)
            anim.SetBool("idleState", true);
        else
            anim.SetBool("idleState", false);

        // Set animator direction
        anim.SetInteger("direction", direction);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
