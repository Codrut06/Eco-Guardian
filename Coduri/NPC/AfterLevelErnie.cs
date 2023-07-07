using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterLevelErnie : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject ReturnButton; // new return button object
    public int ChoiceMade;


    public void ChoiceOption1()
    {
        TextBox.GetComponent<Text>().text = "Pentru început vei intra în subsol...unde se ascund deşeurile (inamicii). Dacă reuşeşti să îi înfrunţi colectează elementele din urma lor şi asteaptă-mă în camera cu gunoaiele colorate. Destulă vorbă...vreau sa văd fapte! În stânga mea este intrarea către luptă. Succes!.";
        ChoiceMade = 1;
        ShowReturnButton();
    }


    public void ReturnToOptions()
    {
        Choice01.SetActive(true);
        ReturnButton.SetActive(false);
        ChoiceMade = 0;
        TextBox.GetComponent<Text>().text = ""; // reset the text
    }

    private void ShowReturnButton()
    {
        ReturnButton.SetActive(true);
        Choice01.SetActive(false);
    }

    void Update()
    {
        if (ChoiceMade >= 1)
        {
            ShowReturnButton();
        }
    }
}
