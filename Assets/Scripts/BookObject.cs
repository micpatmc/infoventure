using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookObject : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Handles the amount of books the player holds and the actions related 
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    private bool inRadius;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
    private void Update()
    {
        // When the key is pressed and conditions are met, increase book count
        // and check for if all books are collected
        if (Input.GetKeyDown(KeyCode.E) && inRadius && !GameManager.booksFinished)
        {
            GameManager.heldBookObjects++;

            if (GameManager.heldBookObjects >= 9)
                GameManager.booksFinished = true;

            Destroy(gameObject);
        }
    }

    // Checks if the the player is in radius
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRadius = true;
        }
    }

    // Says the player is no longer in radius
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRadius = false;
        }
    }

    // Randomly generates books around the map
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Terrain"))
        {
            Instantiate(gameObject, new Vector2(Random.Range(-70, 70), Random.Range(-70, 70)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
    }
}
