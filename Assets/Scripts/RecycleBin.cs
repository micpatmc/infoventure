using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecycleBin : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Handles the count of recycling bottles in the recycling bin
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public Slider slider;
    public Sprite fullBin;

    public int bottlesInBin;

    private bool inRadius;

    private void Start()
    {
        slider.maxValue = 5;
        slider.minValue = 0;
    }
    private void Update()
    {
        // If bin is full, change sprite to resemble that
        if (bottlesInBin >= 5)
        {
            GetComponent<SpriteRenderer>().sprite = fullBin;
        }

        // If conditions are met, recycle the bottle and check if it has reached its threshold
        if (Input.GetKeyDown(KeyCode.E) && inRadius && GameManager.heldTrashObjects > 0)
        {
            GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");
            GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "The bottles have been recycled!";

            bottlesInBin += GameManager.heldTrashObjects;
            GameManager.heldTrashObjects = 0;

            slider.value = bottlesInBin;

            if (bottlesInBin >= 5)
            {
                GameManager.recyclingFinished = true;
            }
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
}
