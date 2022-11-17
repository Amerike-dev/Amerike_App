using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarUI : MonoBehaviour
{
    [SerializeField] private string[] daysName;
    // [SerializeField] private DateTime[] _daysDisplays;
    [SerializeField] private DayBlock[] _blocks;

    private DayOfWeek[] _dayOfWeeks;

    public void InitializeUI()
    {
        _dayOfWeeks = CalendarManager.Instance.DaysOfWeek;
        SetDays();
    }

    void SetDays()
    {

        
        
        for (int i = 0; i < _dayOfWeeks.Length; i++)
        {
            // if ()
            // {
                
            // }
        }
        // foreach (DayBlock dayBlock in _blocks)
        // {
            // dayBlock.SetData(, null);
        // }
    }
    
    
    
}
