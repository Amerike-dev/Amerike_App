using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourBlock : MonoBehaviour
{
    [SerializeField] private HourSelected myHour;
  
  
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