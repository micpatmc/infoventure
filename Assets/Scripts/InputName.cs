using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputName : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // The functionality for inputting your own name into the user input
    // section when the game first starts
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public GameObject button;
    public TextMeshProUGUI textDisplay;
    public TMP_InputField username;

    private float canPressButton;

    private void Start()
    {
        canPressButton = 5;
        textDisplay.text = PlayerPrefs.GetString("Username");
    }
    private void Update()
    {
        canPressButton -= Time.deltaTime;
    }

    // Uses the name input into the text box as your username
    public void Username()
    {
        textDisplay.text = username.text;
        PlayerPrefs.SetString("Username", textDisplay.text);
    }

    // Pauses the game by freezing time
    public void Pause()
    {
        Time.timeScale = 0;
    }

    // Unpauses the game
    public void UnPause()
    {
        if (canPressButton <= 0)
        {
            if (username.text.Length > 0)
            {
                Time.timeScale = 1;
            }

            button.SetActive(false);
            username.gameObject.SetActive(false);
        }
    }

}
