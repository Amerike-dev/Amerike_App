using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text monthText;
    
    [Header("Calendar")]
    [SerializeField] private string[] daysName;
    [SerializeField] private string[] months;
    [SerializeField] private DayBlock[] _blocks;

    private DayOfWeek[] _dayOfWeeks;
    private DateTime[] _daysDisplays;
    private int _currentMonth;
    private int[] _months;


    public void InitializeUI()
    {
        _dayOfWeeks = CalendarManager.Instance.DaysOfWeek;
        _daysDisplays = CalendarManager.Instance.WeekDisplay;
        _currentMonth = CalendarManager.Instance.CurrentDay.Month;
        SetDays();
        SetMonth(_currentMonth);
    }

    void SetDays()
    {
        for (int i = 0; i < _dayOfWeeks.Length; i++)
        {
            switch (_dayOfWeeks[i])
            {
                case DayOfWeek.Monday:
                    _blocks[i].SetData(DayOfWeek.Monday,daysName[0], _daysDisplays[i].Day.ToString());
                    break;
                case DayOfWeek.Tuesday:
                    _blocks[i].SetData(DayOfWeek.Tuesday,daysName[1], _daysDisplays[i].Day.ToString());
                    break;
                case DayOfWeek.Wednesday:
                    _blocks[i].SetData(DayOfWeek.Wednesday,daysName[2], _daysDisplays[i].Day.ToString());
                    break;
                case DayOfWeek.Thursday:
                    _blocks[i].SetData(DayOfWeek.Thursday,daysName[3], _daysDisplays[i].Day.ToString());
                    break;
                case DayOfWeek.Friday:
                    _blocks[i].SetData(DayOfWeek.Friday,daysName[4], _daysDisplays[i].Day.ToString());
                    break;
                case DayOfWeek.Saturday:
                    _blocks[i].SetData(DayOfWeek.Saturday,daysName[5],_daysDisplays[i].Day.ToString());
                    break;
                case DayOfWeek.Sunday:
                    _blocks[i].SetData(DayOfWeek.Sunday,daysName[6], _daysDisplays[i].Day.ToString());
                    break;
            }

        }
    }

    void SetMonth(int month)
    {
        monthText.text = months[month - 1];
    }
    
}
