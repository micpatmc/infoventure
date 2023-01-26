using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool startingScreen;
    public bool starterConvo;

    Vector2 movement;

    private Animator anim;
    public int direction;

    private void Start()
    {
        startingScreen = true;
        direction = 3;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!startingScreen)
        {
            if (movement.y == 0)
                movement.x = Input.GetAxisRaw("Horizontal");

            if (movement.x == 0)
                movement.y = Input.GetAxisRaw("Vertical");
        }


        if (movement.x > 0)
            direction = 2;
        else if (movement.x < 0)
            direction = 1;
        else if (movement.y > 0)
            direction = 3;
        else if (movement.y < 0)
            direction = 0;

        anim.SetFloat("velocityX", movement.x);
        anim.SetFloat("velocityY", movement.y);

        if (movement.x == 0 && movement.y == 0)
            anim.SetBool("idleState", true);
        else
            anim.SetBool("idleState", false);

        anim.SetInteger("direction", direction);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
