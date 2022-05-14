using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class scr_Obstacle : MonoBehaviour
{
    private bool _isTriggered;
    
    [SerializeField] private bool obstacleJump;
    [SerializeField] private bool obstacleHand;

    void Start()
    {
        if (obstacleHand)
        {
            //transform.DOLocalMoveX(-.4f, 2f).OnComplete(() => transform.DOLocalMoveX(0.3f, 2f)
              //  .SetLoops(-1, LoopType.Yoyo));
            
            
            transform.DOLocalMoveX(-.4f,2f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
        }

        if (obstacleJump)
        {
            transform.DOLocalMoveX(-1.65f,.25f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && obstacleJump && !_isTriggered)
        {
            scr_GameManager.Instance.money = 0;
            scr_DataManager.Instance.RemoveNut();
            Debug.Log("Engele Çarptın");
        }

        else if (other.CompareTag("Player") && obstacleHand && !_isTriggered &&  other.GetComponent<scr_NutObject>()!=null)
        {
            _isTriggered = true;
            other.transform.parent = transform;
            other.GetComponent<scr_NutObject>().FollowObject = null;
            other.transform.localPosition = new Vector3(.06f, -.062f, 0);
            scr_DataManager.Instance.ObstacleHand(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            scr_DataManager.Instance.deneme = false;
    }

   

}