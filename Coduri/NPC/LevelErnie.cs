using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelErnie : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public GameObject Choice04;
    public GameObject Choice05;
    public GameObject ReturnButton; // new return button object
    public int ChoiceMade;


    public void ChoiceOption1()
    {
        TextBox.GetComponent<Text>().text = "PLASTIC/METAL\r\nExemple de deşeuri corespunzătoare coşului galben : bidoane și cutii din plastic, pungi din plastic, ambalaje de protecție din plastic, jucării de plastic, doze de băuturi, cutii de conserve, cutiile TetraPack (cutii de lapte și suc)";
        ChoiceMade = 1;
        ShowReturnButton();
    }
    public void ChoiceOption2()
    {
        TextBox.GetComponent<Text>().text = "HÂRTIE/CARTON\r\nExemple de deşeuri corespunzătoare coşului albastru : eviste, ziare, maculatură, plicuri; cutii, fotografii, cartoane de ouă, cutii de pizza (curate și uscate)";
        ChoiceMade = 2;
        ShowReturnButton();
    }
    public void ChoiceOption3()
    {
        TextBox.GetComponent<Text>().text = "STICLĂ\r\nExemple de deşeuri corespunzătoare coşului verde : ambalaje din sticlă (fără capac), borcane (fără capac), damigene, ambalaje din sticlă de la produse cosmetice.";
        ChoiceMade = 3;
        ShowReturnButton();
    }
    public void ChoiceOption4()
    {
        TextBox.GetComponent<Text>().text = "BIODEGRADABILE\r\nExemple de deşeuri corespunzătoare coşului maro : resturi de fructe şi de legume proaspete sau gătite, resturi de pâine şi cereale, zaţ de cafea/resturi de ceai inclusiv pliculețe, coji de ouă, coji de nucă, cenuşă de la sobe (când se arde numai lemn), rumeguş, fân şi paie, resturi vegetale din curte (frunze, crengi şi nuiele mărunţite, flori), plante de casă, bucăţi de lemn mărunţit, ziare, carton mărunţite - umede şi murdare, șervețele de hârtie.";
        ChoiceMade = 4;
        ShowReturnButton();
    }
    public void ChoiceOption5()
    {
        TextBox.GetComponent<Text>().text = "DEȘEURI REZIDUALE / AMESTECATED \r\n eșeurile reziduale sunt totalitatea deșeurilor care nu se pot recicla. Câteva exemple de astfel de deşeuri sunt : resturi de mâncare (carne, lactate, vegetale, ouă), scutece de unică folosință, absorbante, reziduurile/excrementele animalelor de casă, conținutul sacului de la aspirator, mucuri de țigară, șervețele folosite, ambalaje foarte murdare, cioburi de ceramică și porțelan, veselă de unică folosință foarte murdară, cenușa de la sobe (dacă în afară de lemn se ard și cărbuni), resturi vegetale din curte (dacă sunt tratate cu pesticid), lemn tratat sau vopsit.";
        ChoiceMade = 5;
        ShowReturnButton();
    }

    public void ReturnToOptions()
    {
        Choice01.SetActive(true);
        Choice02.SetActive(true);
        Choice03.SetActive(true);
        Choice04.SetActive(true);
        Choice05.SetActive(true);
        ReturnButton.SetActive(false);
        ChoiceMade = 0;
        TextBox.GetComponent<Text>().text = ""; // reset the text
    }

    private void ShowReturnButton()
    {
        ReturnButton.SetActive(true);
        Choice01.SetActive(false);
        Choice02.SetActive(false);
        Choice03.SetActive(false);
        Choice04.SetActive(false);
        Choice05.SetActive(false);
    }

    void Update()
    {
        if (ChoiceMade >= 1)
        {
            ShowReturnButton();
        }
    }
}
