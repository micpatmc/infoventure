using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookObject : MonoBehaviour
{
    private bool inRadius;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRadius && !GameManager.booksFinished)
        {
            GameManager.heldBookObjects++;
            //GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");

/*            if (GameManager.heldBookObjects == 1)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Nearly 1/5th of all Americans reported spending more than their income in the year 2020";
            }
            else if (GameManager.heldBookObjects == 2)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "A great way to accumulate money for your future is to invest in a stable index fund like the S&P 500";
            }
            else if (GameManager.heldBookObjects == 3)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Saving money for financial emergencies is very important, some suggest that you should save for at least 3-months of living expenses";
            }
            else if (GameManager.heldBookObjects == 4)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "Credit is the measure of your ability to borrow money that you will have to pay back at a later time. (often with interest) Building good credit is key to solid financials!";
            }
            else if (GameManager.heldBookObjects == 5)
            {
                GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "As of 2022 Americans owe $800 billion in credit card debt";
            }*/

            if (GameManager.heldBookObjects >= 9)
                GameManager.booksFinished = true;

            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRadius = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Terrain"))
        {
            Instantiate(gameObject, new Vector2(Random.Range(-70, 70), Random.Range(-70, 70)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRadius = false;
        }
    }
}
