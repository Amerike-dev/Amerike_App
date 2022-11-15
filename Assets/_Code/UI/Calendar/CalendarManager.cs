using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class CalendarManager : MonoBehaviour
{
    public static CalendarManager Instance;

    #region private var

    private DateTime _currentDay;
    private DateTime[] _weekDisplay;
    private DayOfWeek _dayOfWeek;
    
    private int _weekOfTheYear;
    private Calendar _calendar;
    CultureInfo myCI = new CultureInfo("en-US");
    private CalendarWeekRule myCWR;
    private DayOfWeek myFirstDOW;
  

    #endregion

    #region public var

    public DateTime CurrentDay
    {

        get => _currentDay;
    }

    public DayOfWeek DayOfWeek
    {
        get => _dayOfWeek;
    }
    
    public Action OnFinishedLoading;
    #endregion
    void Awake()
    {
        Instance = this;
        Initialize();
    }

    void Update()
    {
        
    }

    void Initialize()
    {
        //Get current Day info
        _currentDay = DateTime.Today;
        _dayOfWeek = _currentDay.DayOfWeek;
       
        //Get week of the year
        _calendar = myCI.Calendar;
        myCWR = myCI.DateTimeFormat.CalendarWeekRule;
        myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
        _weekOfTheYear = _calendar.GetWeekOfYear(_currentDay, myCWR, myFirstDOW);
        Debug.Log(_weekOfTheYear);
        
        
        OnFinishedLoading?.Invoke();
        
    }
    
}
