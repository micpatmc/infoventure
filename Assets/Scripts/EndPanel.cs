using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Loads the ending panel for the game
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
