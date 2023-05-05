using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Randomly sets the size of turtles
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    private void Start()
    {
        int ran = Random.Range(10, 20);
        transform.localScale = new Vector2(ran, ran);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
}
