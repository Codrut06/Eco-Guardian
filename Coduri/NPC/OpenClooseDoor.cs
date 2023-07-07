using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClooseDoor : MonoBehaviour
{
    private Animator anim;
    private bool Deschis;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Deschis", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Deschis == true)
        {
            anim.SetBool("Deschis", true);

        }
        else
        {
            anim.SetBool("Deschis", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Deschis = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Deschis = false;
        }
    }
}
