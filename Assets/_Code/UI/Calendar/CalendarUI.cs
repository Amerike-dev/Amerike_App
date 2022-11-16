using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarUI : MonoBehaviour
{
    [SerializeField] private string[] daysName;
    [SerializeField] private DayBlock[] _blocks;
    private void Start()
    {
        CalendarManager.Instance.OnFinishedLoading += InitializeUI;
    }

    void InitializeUI()
    {
        SetDays();
    }

    void SetDays()
    {
        foreach (DayBlock dayBlock in _blocks)
        {
            dayBlock.SetData(null, null);
        }
    }
    
    
    
}
