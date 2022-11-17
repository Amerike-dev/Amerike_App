using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayBlock : MonoBehaviour
{
    [SerializeField] private Text dayWeekTxt;
    [SerializeField] private Text dayNumberTxt;
    [SerializeField] private List<HourBlock> hourButtons;
    [SerializeField] private GameObject disableFilter;

    private DayOfWeek _dayOfWeek;

    public void SetData(DayOfWeek day ,string dayWeek, string dayNumber)
    {
        disableFilter.SetActive(false);

        dayWeekTxt.text = dayWeek;
        dayNumberTxt.text = dayNumber;
        _dayOfWeek = day;

        if (_dayOfWeek == DayOfWeek.Sunday)
        {
            disableFilter.SetActive(true);
            foreach (HourBlock block in hourButtons)
            {
                block.Button.interactable = false;
            }
        }
    }
    
}
