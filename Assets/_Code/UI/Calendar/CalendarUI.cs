using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarUI : MonoBehaviour
{

    [SerializeField] private Text day;
    [SerializeField] private Text dayOfWeek;


    private void Start()
    {
        CalendarManager.Instance.OnFinishedLoading += InitializeUI;
    }

    void InitializeUI()
    {
        day.text = CalendarManager.Instance.CurrentDay.ToString();
        dayOfWeek.text = CalendarManager.Instance.DayOfWeek.ToString();
    }
    
    
    
    
}
