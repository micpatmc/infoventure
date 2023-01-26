using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public GameObject player;
    public GameObject navigationEffect;
    public Transform[] locations;

    public int index;

    public float timer;
    public float timerRemember;
    public float speed;

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
