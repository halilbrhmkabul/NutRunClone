using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine.PlayerLoop;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class scr_DataManager : MonoBehaviour
{
    public static scr_DataManager Instance;
    public List<GameObject> NutList;
    public List<GameObject> BagList;
    public bool deneme;
    
    public int nutStackCount=1;
    public int _finalCount=1;

    [SerializeField] private SplineComputer _splineComputer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        
        NutList.Add(scr_PlayerChildController.Instance.gameObject);
        scr_PlayerController.Instance.playerSplineFollower.spline = _splineComputer;
        scr_PlayerController.Instance.playerSplineFollower.SetPercent(0);
    }

    public int AddNut(GameObject NutGameObject)
    {
        NutGameObject.GetComponent<scr_NutObject>().FollowObject = NutList[NutList.Count - 1];
        NutList.Add(NutGameObject);
        scr_GameManager.Instance.InGameMoneyCalculate();
        NutGameObject.transform.parent = scr_PlayerController.Instance.transform;
        NutGameObject.transform.localPosition
            = new Vector3(0, 0, (NutList.Count - 1) *.125f);
        return NutList.Count - 1;
    }

    public void RemoveNut()
    {
        if (deneme) return;
        deneme = true;
        for (int i = NutList.Count-1; i > 0; i--)
        {
            if (NutList[i].GetComponent<scr_NutObject>() == null)
            {
                continue;
            }
            NutList[i].GetComponent<scr_NutObject>().FollowObject = null;
            NutList[i].transform.parent = scr_LevelManager.Instance.garbageObject.transform;
            NutList[i].transform.tag = "Untagged";
            
            Vector3 Pos = NutList[i].transform.position;
              NutList[i].transform.DOJump(
                  new Vector3(Pos.x + UnityEngine.Random.Range(-0.1f, .1f),
                      Pos.y,
                      Pos.z +1.5f),
                  1f, 1, .1f);
                          
            NutList[i].GetComponent<scr_NutObject>()._isAdded = false;
            NutList.Remove(NutList[i].gameObject);
        }
        scr_GameManager.Instance.money = 0;
        scr_GameManager.Instance.InGameMoneyCalculate();
        
      }

    public void ObstacleHand(GameObject catchingObject)
    {
        int _catchingObjectIndex = NutList.IndexOf(catchingObject);
        
        for (int i = NutList.Count-1; i >_catchingObjectIndex; i--)
        {
            NutList[i].GetComponent<scr_NutObject>().FollowObject = null;
            NutList[i].transform.parent = null;
            NutList[i].transform.tag = "Untagged";
            Vector3 Pos = NutList[i].transform.position;
            NutList[i].transform.DOJump(
                new Vector3(Pos.x + UnityEngine.Random.Range(-0.2f, .1f),
                    Pos.y,
                    Pos.z +1f),
                1f, 1, .1f);
                          
            NutList[i].GetComponent<scr_NutObject>()._isAdded = false;
            NutList.Remove(NutList[i].gameObject);
        }
        NutList.Remove(NutList[_catchingObjectIndex].gameObject);
        scr_GameManager.Instance.InGameMoneyCalculate();
        Debug.Log(_catchingObjectIndex);
    }
    public void MoveBag()
    {
        if (BagList.Count > 0)
        {
            
            NutList[NutList.Count - 1].transform.DOJump(BagList[0].transform.position, 1, 1, 2);
            NutList[NutList.Count - 1].GetComponent<scr_NutObject>().FollowObject = null;
            NutList[NutList.Count - 1].transform.parent = scr_LevelManager.Instance.garbageObject.transform;
            NutList.RemoveAt(NutList.Count - 1);
            BagList.RemoveAt(0);
            _finalCount++; 
        }
        
        else
        {
            if (  NutList[NutList.Count-1].GetComponent<scr_NutIdentity>()!=null)
            {
                NutList[NutList.Count-1].GetComponent<scr_NutIdentity>().MakeMoney();
                NutStack(1);
            }
        
           
        }
    }

  
    void NutStack(int stackCount)
    {
        NutList[NutList.Count-1].GetComponent<scr_NutObject>().FollowObject = null;
        NutList[NutList.Count-1].transform.DOLocalJump(new Vector3(0, nutStackCount*.15f  +.25f, 0), 1f, 1, 2);
        NutList.RemoveAt(NutList.Count-1);
        _finalCount++; 
        nutStackCount++;
        

    }
  

    




}





    
    



