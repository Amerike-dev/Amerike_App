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
     None,
     SevenToNine_AM,
     NineToEleven_AM,
     ElevenToOne_AM,
     OneToThree_PM,
     ThreeToFive_PM,
     FiveToSeven_PM,
     SevenToNine_PM
     
}