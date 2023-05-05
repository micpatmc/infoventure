using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Creates a particle effect for the player to follow for navigation
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public GameObject player;
    public GameObject navigationEffect;
    public Transform[] locations;

    public float timer;
    public float timerRemember;
    public float speed;

    public int index;

    private void Start()
    {
        timer = timerRemember;
    }
    private void Update()
    {
        if (timer <= 0)
        {
            GameObject var = Instantiate(navigationEffect, player.transform.position, Quaternion.identity);
            var.GetComponent<NavigationChild>().target = locations[index];
            timer = timerRemember;
        }

        if (!FindObjectOfType<DialogueManager>().inDialogue && !FindObjectOfType<Movement>().startingScreen)
            timer -= Time.deltaTime;
    }
}
