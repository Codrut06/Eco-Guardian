using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public GameObject player;
    //public Rigidbody2D rb;

    private bool playerTouch;
    void Start()
    {
        //` rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerTouch)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("FIGHTLEVEL1");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouch = false;
        }
    }
}
