using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyObject : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Creates the informational statements for the player when they pick
    // up money off the ground
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
        // If conditions are met, grab the coin object and display an informational statement
        if (Input.GetKeyDown(KeyCode.E) && inRadius && !GameManager.changeFinished)
        {
            GameManager.heldCoinObjects++;
            GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");

            if (GameManager.heldCoinObjects == 1)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Nearly 1/5th of all Americans reported spending more than their income in the year 2020";
            }
            else if (GameManager.heldCoinObjects == 2)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "A great way to accumulate money for your future is to invest in a stable index fund like the S&P 500";
            }
            else if (GameManager.heldCoinObjects == 3)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Saving money for financial emergencies is very important, some suggest that you should save for at least 3-months of living expenses";
            }
            else if (GameManager.heldCoinObjects == 4)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Credit is the measure of your ability to borrow money that you will have to pay back at a later time. (often with interest) Building good credit is key to solid financials!";
            }
            else if (GameManager.heldCoinObjects == 5)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "As of 2022 Americans owe $800 billion in credit card debt";
            }
    
            if (GameManager.heldCoinObjects >= 5)
                GameManager.changeFinished = true;

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

    // Randomly generates coins around the map
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Terrain"))
        {
            Instantiate(gameObject, new Vector2(Random.Range(-70, 70), Random.Range(-70, 70)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
    }
}
