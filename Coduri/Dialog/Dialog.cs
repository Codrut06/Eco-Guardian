using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private string[] sentences;  //propozitii
    private GameObject[] answers;  //raspuns


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sentences.Length; i++)
        {
            answers[i].SetActive(true);
        }
    }

}
