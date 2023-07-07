using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogManager;
    private bool mouseOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //buton controlat de mouse
        if (mouseOver && Input.GetMouseButtonDown(0)) 
        { 
            dialogManager.SetActive(true);
        }
    }
    void OnMouseEnter()
    {
        mouseOver = true;
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }


}
