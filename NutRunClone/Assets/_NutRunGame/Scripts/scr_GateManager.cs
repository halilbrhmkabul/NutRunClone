using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_GateManager : MonoBehaviour
{
    public bool KabukKiran;
    public bool CikolataDoken;
    public bool ParcacikDoken;
    public bool Package;
   
    
    private void Start()
    {
        if (KabukKiran)
        {
            transform.DOLocalMoveY(.225f, .1f).OnComplete(() =>
                transform.DOLocalMoveY(0.404f, .1f)
                .SetLoops(-1, LoopType.Yoyo));
            
        }

        if (Package)
        {
            transform.DOLocalMoveY(0.35f,.125f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
        }

        if (ParcacikDoken)
        {
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool _isReturn = false;
            if (KabukKiran)
            {
                if (other.GetComponent<scr_NutIdentity>()!=null && other.GetComponent<scr_NutIdentity>().NutStateIndex==0)
                {
                    other.GetComponent<scr_NutIdentity>().NutFormChange();
                    scr_GameManager.Instance.InGameMoneyCalculate();
                    
                }
            }
            
            else if (CikolataDoken)
            {
                if(other.GetComponent<scr_NutIdentity>()!=null && other.GetComponent<scr_NutIdentity>().NutStateIndex==1)
                {
                    other.GetComponent<scr_NutIdentity>().NutFormChange();
                    scr_GameManager.Instance.InGameMoneyCalculate();
                    
                }
            }
            
            else if (ParcacikDoken)
            { 
                if(other.GetComponent<scr_NutIdentity>()!=null && other.GetComponent<scr_NutIdentity>().NutStateIndex==2)
                {
                    other.GetComponent<scr_NutIdentity>().NutFormChange();
                    scr_GameManager.Instance.InGameMoneyCalculate();
                }
                
            }
            
            else if(Package)
            {
                if (other.GetComponent<scr_NutIdentity>()!=null )
                {
                    other.GetComponent<scr_NutIdentity>().NutMakePackage();
                    
                    scr_PlayerChildController.Instance.enabled = false;
                    scr_PlayerChildController.Instance.transform.localPosition=new Vector3(0,0.3f,0);
                    scr_DataManager.Instance.MoveBag();
                    _isReturn = true;
                    scr_GameManager.Instance.FinalGameMoneyCalculate();
                }  
                
            } 
            
        }
        
        
    }

}
