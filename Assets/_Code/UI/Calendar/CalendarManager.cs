using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
    public static CalendarManager Instance;

    #region private var

    private DateTime _currentDay;
    private DateTime[] _weekDisplay;
    private DayOfWeek _dayOfWeek;

    #endregion

    #region public var

    public DateTime CurrentDay
    {
        get
        {
           return _currentDay = DateTime.Today;
        }
    }

    public DayOfWeek DayOfWeek
    {
        get
        {
            return _dayOfWeek = CurrentDay.DayOfWeek;
        }
    }

    #endregion
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        
    }

    void Initialize()
    {
        // _currentDay = DateTime.Today;
        // _dayOfWeek = _currentDay.DayOfWeek;
    }
}
