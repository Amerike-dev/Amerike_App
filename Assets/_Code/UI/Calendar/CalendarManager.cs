using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class CalendarManager : MonoBehaviour
{
    public static CalendarManager Instance;
    
    #region private var

    [SerializeField] private CalendarUI _calendarUI;
    private DateTime _currentDay;
    private DateTime[] _weekDisplay = new DateTime[7];
    private DayOfWeek[] _daysOfWeek = new DayOfWeek[7];
    
    private int _weekOfTheYear;
    private Calendar _calendar;
    private CultureInfo myCI = new CultureInfo("en-US");
    private CalendarWeekRule myCWR;
    private DayOfWeek myFirstDOW;
  

    #endregion

    #region public var

    public DateTime CurrentDay
    {

        get => _currentDay;
    }

    public DayOfWeek[] DaysOfWeek
    {
        get => _daysOfWeek;
    }

    public DateTime[] WeekDisplay
    {
        get => _weekDisplay;
    }
    
    public Action OnFinishedLoading;
    #endregion
    void Awake()
    {
        Instance = this;
        Initialize();
    }
    
    void Initialize()
    {
        //Get current Day info
        _currentDay = DateTime.Today;
        // _dayOfWeek = _currentDay.DayOfWeek;
       
        //Get week of the year
        _calendar = myCI.Calendar;
        myCWR = myCI.DateTimeFormat.CalendarWeekRule;
        myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
        _weekOfTheYear = _calendar.GetWeekOfYear(_currentDay, myCWR, myFirstDOW);
        // Debug.Log(_weekOfTheYear);
        
        HandleDays(0, _currentDay);
        
        _calendarUI.InitializeUI();
        OnFinishedLoading?.Invoke();
        
    }

    private void HandleDays(int index, DateTime currentDay)
    {
        if (index < _weekDisplay.Length)
        {
            DateTime nextDay = currentDay.AddDays(1);
            _weekDisplay[index] = nextDay;
            _daysOfWeek[index] = _weekDisplay[index].DayOfWeek;
            
            if (index == 0)
            {
                _weekDisplay[0] = _currentDay;
                _daysOfWeek[0] = _currentDay.DayOfWeek;
            }
            // Debug.Log(_daysOfWeek[index]);
            HandleDays(index + 1, _weekDisplay[index]);
        }
        
    }
    
}
