using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool inNPCRadius;

    public int whichNPC;

    public GameObject exclamation;


    private void Start()
    {
        StartCoroutine(StartingConversation());
    }

    public IEnumerator StartingConversation()
    {
        yield return new WaitForSeconds(7f);

        dialogue.sentences[0] = "Hello " + PlayerPrefs.GetString("Username") + "! I hate to ask this of you but this town needs your help. You see… this once beautiful town is now plagued with littered trash. I would clean it all up myself but in my old age it seems far from possible at this rate.";
        dialogue.sentences[1] = "Would you be a dear and help me out? [Interact with items using the E key]";

        yield return new WaitForSeconds(3f);

        if (whichNPC == 1)
        {
            TriggerDialogue();
            FindObjectOfType<Movement>().startingScreen = false;
        }
    }

    private void Update()
    {
        if (!FindObjectOfType<DialogueManager>().inDialogue)
        {
            if ((Input.GetKeyDown(KeyCode.E) && inNPCRadius && whichNPC == 3 && FindObjectOfType<DialogueManager>().talkedToNPC4))
            {
                dialogue.sentences[0] = "Thank you so much " + PlayerPrefs.GetString("Username") + "! This means a lot to me and my kids here.";
                dialogue.sentences[1] = "I wish you the best of luck in your future journey and wish to see you again!";

                GameManager.heldBookObjects = 0;

                if (whichNPC == 3)
                {
                    exclamation.SetActive(false);
                }

                FindObjectOfType<Movement>().startingScreen = true;
                FindObjectOfType<DialogueManager>().endPanel = true;
                TriggerDialogue();
            }

            if ((Input.GetKeyDown(KeyCode.E) && !GameManager.booksFinished && inNPCRadius && whichNPC == 4 && FindObjectOfType<DialogueManager>().talkedToNPC3))
            {
                dialogue.sentences[0] = "Thanks " + PlayerPrefs.GetString("Username") + ", I heard what you were doing for the children and that sounds wonderful, there should be more people like you!";
                dialogue.sentences[1] = "*Uses all of the money to buy books for the children*";

                GameManager.moneyCount = 0;

                if (!GameManager.booksFinished && whichNPC == 4)
                {
                    exclamation.SetActive(false);
                }

                FindObjectOfType<DialogueManager>().talkedToNPC4 = true;
                GameManager.heldBookObjects += 9;

                TriggerDialogue();
            }

            if ((Input.GetKeyDown(KeyCode.E) && GameManager.booksFinished && inNPCRadius && whichNPC == 3))
            {
                dialogue.sentences[0] = PlayerPrefs.GetString("Username") + ", you helped us more than you know. Students at this school will be able to use the books for years to come! Although the situation with schooling in the U.S. isn’t the greatest right now, people like you give me hope for the future of education.";
                dialogue.sentences[1] = "THank you so much";
                GameManager.moneyCount++;

                if (GameManager.booksFinished && whichNPC == 3)
                {
                    exclamation.SetActive(false);
                }

                TriggerDialogue();
            }

            if ((Input.GetKeyDown(KeyCode.E) && GameManager.changeFinished && inNPCRadius && whichNPC == 2))
            {
                dialogue.sentences[0] = "Thanks " + PlayerPrefs.GetString("Username") + ", I really couldn’t have done it without you. Now I can finally pay my rent! Clearly, being financially responsible is really important. Remember, Saving up emergency money, making wise investments and understanding how to develop your credit will lead you to financial success!";
                dialogue.sentences[1] = "Do with this information what you want, but I know there are kids who are in desperate need of books, they're located inside the school SOUTH of here.";
                GameManager.moneyCount++;

                if (GameManager.recyclingFinished && GameManager.changeFinished && whichNPC == 2)
                {
                    exclamation.SetActive(false);
                }

                TriggerDialogue();
            }
            else if ((Input.GetKeyDown(KeyCode.E) && GameManager.recyclingFinished && inNPCRadius && whichNPC == 1))
            {
                dialogue.sentences[0] = "Thank you for your help " + PlayerPrefs.GetString("Username") + ", preserving the environment is important not only for ourselves but also for all the humans who come after us! The only way to protect the environment we all share is to work together. Remember that we are just as much a part of the planet as the trees or the oceans, and by helping to save the planet we are helping to save ourselves!";
                dialogue.sentences[1] = "Now I heard there was a man in need of financial help, he is NORTHWEST of us and I believe you're the person to help him, hope all goes well!";
                GameManager.moneyCount++;

                if (GameManager.recyclingFinished && whichNPC == 1)
                {
                    exclamation.SetActive(false);
                }

                TriggerDialogue();
            }
            else if (Input.GetKeyDown(KeyCode.E) && inNPCRadius)
            {
                TriggerDialogue();
            }

            if (GameManager.recyclingFinished && !GameManager.changeFinished && whichNPC == 2)
            {
                exclamation.SetActive(true);
            }
        }
    }

    public void TriggerDialogue()
    {


        if (whichNPC == 3 && !GameManager.booksFinished && !FindObjectOfType<DialogueManager>().talkedToNPC4)
        {
            dialogue.sentences[0] = "Hello " + PlayerPrefs.GetString("Username") + ", it’s so kind of you to pay your old teacher a visit. How have you been?";
            dialogue.sentences[1] = "You know " + PlayerPrefs.GetString("Username") + ", our class hasn’t had a fresh set of textbooks since you graduated, so most of the students have to share and it’s been really hurting their test grades… if you could pick up some extra textbooks from the store NORTHEAST of here, that would be really helpful!";

            FindObjectOfType<DialogueManager>().talkedToNPC3 = true;
        }

        if (whichNPC == 2 && !GameManager.changeFinished)
        {
            dialogue.sentences[0] = "Hey " + PlayerPrefs.GetString("Username") + ", bad news! I lost all my money… again. My rent is past due and it's reeeaaally not looking good maannnn. I need your help.";
            dialogue.sentences[1] = "I’m pretty sure it's all scattered throughout SOUTH of where I am now, can you help me find it?";
            FindObjectOfType<DialogueManager>().talkedToNPC2 = true;
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inNPCRadius = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inNPCRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inNPCRadius = false;
        }
    }
}
