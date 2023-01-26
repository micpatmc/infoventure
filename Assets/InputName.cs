using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputName : MonoBehaviour
{
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
    public void Username()
    {
        textDisplay.text = username.text;
        PlayerPrefs.SetString("Username", textDisplay.text);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

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
