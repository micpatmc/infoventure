using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // ---------------------------------------------------------------------
    // Summary:
    // Handles all of the dialogue between the player and NPC's
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    private Queue<string> sentences;

    public GameObject[] tasks;
    public GameObject pressSpace;
    public GameObject coins;
    public GameObject money;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator endPanelAnim;
    public Animator dialogueAnim;

    public bool inDialogue;
    public bool sentenceDone;
    public bool talkedToNPC2;
    public bool talkedToNPC3;
    public bool talkedToNPC4;
    public bool endPanel;

    private void Start()
    {
        sentences = new Queue<string>();

        talkedToNPC2 = false;
        talkedToNPC3 = false;
        talkedToNPC4 = false;
        sentenceDone = false;
    }

    private void Update()
    {
        if (talkedToNPC2)
            coins.SetActive(true);

        if (inDialogue)
        {
            GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        }
        else 
        {
            GameObject.Find("Player").GetComponent<Movement>().enabled = true;
        }

        if (sentenceDone)
        {
            pressSpace.SetActive(true);
        }
        else
        {
            pressSpace.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && inDialogue && sentenceDone)
        {
            DisplayNextSentence();
        }
    }

    // Starts dialogue with the NPC
    public void StartDialogue(Dialogue dialogue)
    {
        inDialogue = true;

        money.SetActive(false);
        dialogueAnim.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Displays the next sentence in dialogue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Types out the sentence in runtime when in dialogue
    IEnumerator TypeSentence(string sentence)
    {
        sentenceDone = false;

        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.025f);
        }

        sentenceDone = true;
    }

    // Ends dialogue with the NPC
    public void EndDialogue()
    {
        inDialogue = false;
        dialogueAnim.SetBool("isOpen", false);

        tasks[0].SetActive(true);

        if (!GameManager.recyclingFinished)
        {
            tasks[1].SetActive(true);
        }
        else
        {
            tasks[1].SetActive(false);
        }

        if (GameManager.recyclingFinished && !GameManager.changeFinished && talkedToNPC2)
        {
            tasks[2].SetActive(true);
        }
        else if (GameManager.recyclingFinished && GameManager.changeFinished && talkedToNPC2)
        {
            tasks[2].SetActive(false);
        }

        if (!GameManager.booksFinished && talkedToNPC3)
        {
            tasks[3].SetActive(true);
        }
        else if (GameManager.booksFinished && talkedToNPC3)
        {
            tasks[3].SetActive(false);
        }

        if (endPanel)
        {
            endPanelAnim.SetTrigger("EndPanel");
        }

        money.SetActive(true);
    }
}
