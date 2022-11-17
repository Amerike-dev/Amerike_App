using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourBlock : MonoBehaviour
{
    [SerializeField] private HourSelected myHour;
    [SerializeField]  private Button _button;

    public Button Button
    {
        get => _button;
    }
    // private void Start()
    // {
    //     _button = GetComponent<Button>();
    // }

    public void SelectHour()
  {
    
  }
  
  
}

public enum HourSelected
{
     None = 0,
     SevenToNine_AM = 1,
     NineToEleven_AM = 2,
     ElevenToOne_AM = 3,
     OneToThree_PM = 4,
     ThreeToFive_PM = 5,
     FiveToSeven_PM = 6,
     SevenToNine_PM = 7
     
}