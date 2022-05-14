using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class scr_GameManager : MonoBehaviour
{ 
    public int money;
    public static scr_GameManager Instance;
    [SerializeField] bool isGameActive;
    [SerializeField] private bool isLevelFinished;
    public TextMeshProUGUI txt_Price;
    
    [SerializeField] GameObject levelStart;
    [SerializeField] GameObject levelNext;
    [SerializeField] private TextMeshProUGUI txt_Money;
    
   
    
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        
        
    }

    public void StartGame()
    {
        isGameActive = true;
        levelStart.gameObject.SetActive(false);
        scr_PlayerController.Instance.GameStart();
    }

    public void FinishGame()
    {
        isGameActive = false;
        
        int level = PlayerPrefs.GetInt("level");
        level++;
        PlayerPrefs.SetInt("level",level);
        levelNext.gameObject.SetActive(true); 

    }
    

    public void InGameMoneyCalculate()
    {
        money = 0;
        txt_Price.text = money + "";
        for (int i =scr_DataManager.Instance.NutList.Count-1; i > 0; i-- )
        {
            if (scr_DataManager.Instance.NutList[i].GetComponent<scr_NutIdentity>().NutStateIndex==0)
            {
                money++;
            }
            else if (scr_DataManager.Instance.NutList[i].GetComponent<scr_NutIdentity>().NutStateIndex==1)
            {
                money += 2;
            }
            else if (scr_DataManager.Instance.NutList[i].GetComponent<scr_NutIdentity>().NutStateIndex==2)
            {
                money += 3;
            }
            else if (scr_DataManager.Instance.NutList[i].GetComponent<scr_NutIdentity>().NutStateIndex==3)
            {
                money += 4;
            }
            else 
            {
                money += 10;
            }
            txt_Price.text = money + ""; 
        }
        
        
    }

    public void FinalGameMoneyCalculate()
    {
        money = scr_DataManager.Instance._finalCount * 10;
       
        txt_Price.text = money + "";
        
    }


}
