using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecycleObject : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Creates the informational statements for the player when they pick
    // up a bottle off the ground
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
        // If conditions are met, grab the trash and show an informational statement
        if (Input.GetKeyDown(KeyCode.E) && inRadius && !GameManager.recyclingFinished)
        {
            GameManager.heldTrashObjects++;
            GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");

            if (GameManager.heldTrashObjects == 1)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Recycling can help combat pollution by reducing the need for new materials";
            }
            else if (GameManager.heldTrashObjects == 2)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Discarded glass can take thousands of years to disintegrate";
            }
            else if (GameManager.heldTrashObjects == 3)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Recycling can cut down on waste sent to landfills";
            }
            else if (GameManager.heldTrashObjects == 4)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Plastic waste accounts for 10% of the words waste";
            }
            else if (GameManager.heldTrashObjects == 5)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Recycling creates thousands of jobs every year";
            }

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

    // Randomly generates trash around the map
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Terrain"))
        {
            Instantiate(gameObject, new Vector2(Random.Range(-70, 70), Random.Range(-70, 70)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
    }
}
