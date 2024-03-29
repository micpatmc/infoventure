using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // The overall game manager, handling all the text, sliders, main
    // values, and more
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public GameObject bottle;
    public GameObject binText;
    public GameObject bookText;
    public GameObject moneyText;

    public TextMeshProUGUI heldObjectDisplay;
    public TextMeshProUGUI coinsObjectDisplay;
    public TextMeshProUGUI booksObjectDisplay;
    public TextMeshProUGUI moneyObjectDisplay;

    public static int moneyCount;
    public static int heldTrashObjects;
    public static int heldCoinObjects;
    public static int heldBookObjects;

    public static bool recyclingFinished;
    public static bool changeFinished;
    public static bool booksFinished;

    public Slider moneySlider;
    public Slider coinSlider;
    public Slider bookSlider;

    private void Start()
    {
        // Starting values
        moneySlider.maxValue = 2;
        moneySlider.minValue = 0;

        coinSlider.maxValue = 5;
        coinSlider.minValue = 0;

        bookSlider.maxValue = 9;
        bookSlider.minValue = 0;

        moneyCount = 0;

        changeFinished = false;
        recyclingFinished = false;

    }
    private void Update()
    {
        // Toggle sprites dependent on conditions
        if (heldTrashObjects > 0)
            binText.SetActive(true);
        else
            binText.SetActive(false);

        if (heldCoinObjects > 0)
            moneyText.SetActive(true);
        else
            moneyText.SetActive(false);

        if (heldBookObjects > 0)
            bookText.SetActive(true);
        else
            bookText.SetActive(false);

        // Sets the counts of items
        heldObjectDisplay.text = "x" + heldTrashObjects.ToString();
        moneyObjectDisplay.text = "x" + moneyCount.ToString();
        coinsObjectDisplay.text = "x" + heldCoinObjects.ToString();
        booksObjectDisplay.text = "x" + heldBookObjects.ToString();

        // Sets the counts of items in sliders
        moneySlider.value = moneyCount;
        coinSlider.value = heldCoinObjects;
        bookSlider.value = heldBookObjects;
    }
}
