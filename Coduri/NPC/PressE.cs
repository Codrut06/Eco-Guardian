using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE : MonoBehaviour
{

    public GameObject Message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Message.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Message.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Message.SetActive(false);
        }
    }
}
