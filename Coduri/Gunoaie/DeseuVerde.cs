using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeseuVerde : MonoBehaviour
{
    public GameObject casetaCorect;
    public GameObject casetaGresit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Verde")
        {
            StartCoroutine(corect());
        }
        else if (other.gameObject.tag != "Player")
        {
            StartCoroutine(gresit());
        }
    }

    private IEnumerator corect()
    {
        casetaCorect.SetActive(true);
        yield return new WaitForSeconds(2);
        casetaCorect.SetActive(false);
    }
    private IEnumerator gresit()
    {
        casetaGresit.SetActive(true);
        yield return new WaitForSeconds(2);
        casetaGresit.SetActive(false);
    }
}
