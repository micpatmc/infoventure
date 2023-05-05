using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeLocation : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Teleport the player to corresponding areas depending on where they
    // need to be
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public Transform location;
    public int whichLocation;
    
    // If the player touches a trigger and reaches certain conditions, they get teleported to the correct next area
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (whichLocation == 1)
            {
                if (GameManager.recyclingFinished && GameManager.changeFinished)
                {
                    other.transform.position = location.position;
                }
                else
                {
                    GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");
                    GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "You are not ready for this area " + PlayerPrefs.GetString("Username") + ", please progress in other areas to access this one in the future.";
                }
            }
            if (whichLocation == 2)
            {
                if (GameManager.recyclingFinished && GameManager.changeFinished && FindObjectOfType<DialogueManager>().talkedToNPC3)
                {
                    other.transform.position = location.position;
                }
                else
                {
                    GameObject.Find("Tooltip").GetComponent<Animator>().SetTrigger("Tooltip");
                    GameObject.Find("TooltipText").GetComponent<TextMeshProUGUI>().text = "You are not ready for this area " + PlayerPrefs.GetString("Username") + ", please progress in other areas to access this one in the future.";
                }
            }
            if (whichLocation == 0)
            {
                other.transform.position = location.position;
            }
        }
    }
}
