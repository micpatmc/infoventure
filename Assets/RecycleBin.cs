using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecycleBin : MonoBehaviour
{
    public Slider slider;
    private bool inRadius;
    public int bottlesInBin;
    public Sprite fullBin;

    private void Start()
    {
        slider.maxValue = 5;
        slider.minValue = 0;
    }
    private void Update()
    {
        if (bottlesInBin >= 5)
            GetComponent<SpriteRenderer>().sprite = fullBin;

        if (Input.GetKeyDown(KeyCode.E) && inRadius && GameManager.heldTrashObjects > 0)
        {
            GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");
            GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "The bottles have been recycled!";

            bottlesInBin += GameManager.heldTrashObjects;
            GameManager.heldTrashObjects = 0;

            slider.value = bottlesInBin;

            if (bottlesInBin >= 5)
            {
                //GameObject.Find("CompletedTask").GetComponent<Animator>().SetTrigger("CompletedTask");
                GameManager.recyclingFinished = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRadius = true;
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
