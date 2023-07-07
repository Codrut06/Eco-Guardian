using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{
    //bara de viata
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

    void Start()
    {
        //in cazul in care nu au fist asignate
        if(healthBarRect == null)
        {
            Debug.LogError("STATUS INDICATOR: No health bar object referrencecd!");
        }
        if (healthText == null)
        {
            Debug.LogError("STATUS INDICATOR: No health text object referrencecd!");
        }
    }

    //seteaza viata
    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);  //setez viata in functia de valoare curenta
        healthText.text = _cur + "/" + _max + " HP";


    }
}
