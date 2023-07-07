using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //caseta de text
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;

    void Update()
    {
        //cand apesi E apare caseta de text si incepe dialogul cu NPC-ul
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) 
        {
            if(dialoguePanel.activeInHierarchy) 
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index]) 
        {
            contButton.SetActive(true);
        }
    }

    //elimina tot textul
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    //apare textul in caseta de text - in functie de wordSpeed
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    //butonul care trece la urmatoarea caseta
    public void NextLine()
    {
        contButton.SetActive(false);

        if(index < dialogue.Length - 1) 
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    //cand te apropii de NPC
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    //cand te indepartezi de NPC
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
