using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Creates an indicator for the player to follow
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public GameObject indicator;
    public GameObject target;

    Renderer rd;

    private void Start()
    {
        rd = GetComponent<Renderer>();
        target = GameObject.Find("Player");
    }

    private void Update()
    {
        // Using raycast, create an indicator to indicate where to go next
        if (rd.isVisible == false)
        {
            if (indicator.activeSelf == false)
            {
                indicator.SetActive(true);
            }

            Vector2 direction = target.transform.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);

            if (ray.collider != null)
            {
                indicator.transform.position = ray.point;
            }
            else
            {
                if (indicator.activeSelf == true)
                {
                    indicator.SetActive(false);
                }
            }
        }
    }
}
