using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Premiu : MonoBehaviour
{
    public GameObject message;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(premiu());
        }
    }
    private IEnumerator premiu()
    {
        message.SetActive(true); 
        yield return new WaitForSeconds(5);
        message.SetActive(false);
    }
}
