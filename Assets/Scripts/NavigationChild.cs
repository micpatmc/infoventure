using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationChild : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Navigation script child for using physics on the navigation
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    private Rigidbody2D rb;
    public GameObject player;
    public Transform target;

    public float speed;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position;
    }
    private void Update()
    {
        // Makes the particle effect move towards the target
        rb.velocity = Vector2.MoveTowards(player.transform.position, target.position, speed);
    }
}
