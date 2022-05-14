using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;

public class scr_Finish : MonoBehaviour
{ 
    [SerializeField] private SplineFollower _splineFollower; 
    private int lastScore;


    private void OnEnable()
    {
        _splineFollower = scr_PlayerController.Instance.GetComponent<SplineFollower>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Finish"); 
            _splineFollower.followSpeed = 0;
            _splineFollower.enabled = false;
           
            scr_PlayerController.Instance.transform.DOLocalMoveY(scr_DataManager.Instance.nutStackCount*.08f, 1f).OnComplete(() =>
            {
                lastScore = ((scr_DataManager.Instance.nutStackCount -1) * 100) + scr_GameManager.Instance.money;
                scr_GameManager.Instance.txt_Price.text = lastScore.ToString();
                scr_GameManager.Instance.FinishGame(); 
            });
            int totalMoney = scr_DataManager.Instance.nutStackCount * 100;
            scr_GameManager.Instance.FinalGameMoneyCalculate();

        }
    }
}
