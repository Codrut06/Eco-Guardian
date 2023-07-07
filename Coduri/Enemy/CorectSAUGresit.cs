using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorectSAUGresit : MonoBehaviour
{
    public bool raspuns;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Maro" || other.gameObject.tag == "Galben" || other.gameObject.tag == "Negru" || other.gameObject.tag == "Verde" || other.gameObject.tag == "Albastru")
        {
            raspuns = true;
        }
        else
        {
            raspuns = false;
        }
    }
}
