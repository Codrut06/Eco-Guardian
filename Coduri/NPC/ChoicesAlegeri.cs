using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesAlegeri : MonoBehaviour  //pentru EldorNPC
{ 
    //caseta de text in care apare textul
    public GameObject TextBox;

    //alegerile
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public GameObject Choice04;


    public GameObject ReturnButton; // new return button object
    public int ChoiceMade;

    //alegerea 1
    public void ChoiceOption1()
    {
        TextBox.GetComponent<Text>().text = "După cum ştii, una dintre probleme majore cu care se confruntă lumea este poluarea. Astfel, reciclarea este un proces important în susținerea unui mod de viață mai responsabil față de mediul înconjurător. Reciclarea este procesul de transformare în ceva nou a lucrurilor care nu ne mai sunt de folos. Spre exemplu, când termini de citit un ziar și îl arunci într-un tomberon pentru reciclat, el este dus într-o fabrică și transformat în hârtie nouă care poate fi folosită pentru ceva nou.";
        ChoiceMade = 1;
        ShowReturnButton();
    }

    //alegerea 2
    public void ChoiceOption2()
    {
        TextBox.GetComponent<Text>().text = " Beneficiile reciclării sunt multiple, aceasta având un impact atât asupra mediului înconjurător, cât și asupra economiei țării. Printre beneficiile reciclării pentru mediu se numără: \r\n        ~prin reciclare se diminuează considerabil depunerea deșeurilor care nu numai că poluează mediul înconjurător, dar și afectează sănătatea celor care locuiesc in preajma lor;\r\n        ~reciclând, se reduc poluanții eliberați de obicei în apă și aer prin depunerea deșeurilor la gropile de gunoi;\r\n        ~reciclarea ajută la economisirea consumului de energie;\r\n        ~prin reciclare se conserva resursele naturale ale Pământului.\r\n        ~sunt reduse gazele cu efect de seră, minimizând efectele încălzirii globale;\r\n        ~are efecte benefice asupra reducerii amprentei de carbon;\r\n        ~oferă crearea unei noi industrii, implicit a unor noi locuri de muncă";
        ChoiceMade = 2;
        ShowReturnButton();
    }

    //alegerea 3
    public void ChoiceOption3()
    {
        TextBox.GetComponent<Text>().text = "Colectarea selectivă reprezintă o parte a procesului de reciclare, prin care materialele reciclabile sunt adunate și transportate spre centre de recilare. Procesul de reciclare presupune compostarea deșeurilor, colectarea separată și tratarea deșeurilor pentru reintroducerea lor în circuitul economic. Colectarea selectivă are ca scop protejarea mediului înconjurător. De asemenea, contribuie la o eficiență sporită de utilizarea resurselor.";
        ChoiceMade = 3;
        ShowReturnButton();
    }

    //alegerea 4
    public void ChoiceOption4()
    {
        TextBox.GetComponent<Text>().text = "Mă bucur că ai întrebat călatorule! Va trebui să părăseşti zona 1 şi să îl ajuti pe Ernie. Îl vei găsi la intrarea în zona 2. Pentru orice eventualitate ţi-am pregătit în lobby o hartă a planetei pentru a înţelege zonele noastre şi pentru a te deplasa cât mai uşor. Succes călătorule! Aştept veşti bune!";
        ChoiceMade = 4;
        ShowReturnButton();
    }

    //butonul de retunrn care te intoarce inapoi la selectii
    public void ReturnToOptions()
    {
        Choice01.SetActive(true);
        Choice02.SetActive(true);
        Choice03.SetActive(true);
        Choice04.SetActive(true);
        ReturnButton.SetActive(false);
        ChoiceMade = 0;
        TextBox.GetComponent<Text>().text = ""; // reset the text
    }

    //afisare buton de return
    private void ShowReturnButton()
    {
        ReturnButton.SetActive(true);
        Choice01.SetActive(false);
        Choice02.SetActive(false);
        Choice03.SetActive(false);
        Choice04.SetActive(false);
    }

    void Update()
    {
        if (ChoiceMade >= 1)
        {
            ShowReturnButton();
        }
    }
}