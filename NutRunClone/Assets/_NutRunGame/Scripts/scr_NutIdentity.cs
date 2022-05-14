using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NutIdentity : MonoBehaviour
{
  public int NutStateIndex = 0; 
 
  public void NutFormChange()
  {
    NutStateIndex++;
    
    switch (NutStateIndex)
    {
      case 1:
        transform.GetChild(0).gameObject.SetActive((false));
        transform.GetChild(1).gameObject.SetActive((true));
        transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>().Play();
        break;

      case 2:
        transform.GetChild(0).gameObject.SetActive((false));
        transform.GetChild(1).gameObject.SetActive((false));
        transform.GetChild(2).gameObject.SetActive((true));
        break;
      
      case 3:
        transform.GetChild(0).gameObject.SetActive((false));
        transform.GetChild(1).gameObject.SetActive((false));
        transform.GetChild(2).gameObject.SetActive((false));
        transform.GetChild(3).gameObject.SetActive((true));
        break;

      default:
        break;
    }
  }

  public void NutMakePackage()
  {
    transform.GetChild(0).gameObject.SetActive((false));
    transform.GetChild(1).gameObject.SetActive((false));
    transform.GetChild(2).gameObject.SetActive((false));
    transform.GetChild(3).gameObject.SetActive((false));
    transform.GetChild(4).gameObject.SetActive((true));
    NutStateIndex = 4;
    
  }

  public void MakeMoney()
  {
    Debug.Log("asdeweqweasdasdas");
    transform.GetChild(0).gameObject.SetActive((false));
    transform.GetChild(1).gameObject.SetActive((false));
    transform.GetChild(2).gameObject.SetActive((false));
    transform.GetChild(3).gameObject.SetActive((false));
    transform.GetChild(4).gameObject.SetActive((false));
    transform.GetChild(5).gameObject.SetActive((true));
    NutStateIndex = 5;
  }
  
  
  
}
