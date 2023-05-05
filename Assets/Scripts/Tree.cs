using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Randomly sets the size of trees
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    private void Start()
    {
        int ran = Random.Range(25, 35);
        transform.localScale = new Vector2(ran, ran);
    }
}
