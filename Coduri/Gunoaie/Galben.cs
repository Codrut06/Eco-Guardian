using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Galben : MonoBehaviour
{
    //public Image image;
    public GameObject corect;
    public GameObject gresit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("galben"))
        { 
            StartCoroutine(raspunsCorect());
        }
        else if(other.gameObject.CompareTag("player") == false)
        {
            StartCoroutine(raspunsGresit());
        }
    }

    private IEnumerator raspunsCorect()
    {
        corect.SetActive(true);
        yield return new WaitForSeconds(2);
        corect.SetActive(false);
    }
    private IEnumerator raspunsGresit()
    {
        gresit.SetActive(true);
        yield return new WaitForSeconds(2);
        gresit.SetActive(false);
    }
}
