using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayBlock : MonoBehaviour
{

    [SerializeField] private Text dayWeekTxt;
    [SerializeField] private Text dayNumberTxt;


    public void SetData(string dayWeek, string dayNumber)
    {
        dayWeekTxt.text = dayWeek;
        dayNumberTxt.text = dayNumber;
    }
    
}
