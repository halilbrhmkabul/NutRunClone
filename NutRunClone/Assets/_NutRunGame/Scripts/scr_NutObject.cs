using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_NutObject : MonoBehaviour
{
    public bool _isAdded;

    public GameObject FollowObject;
    public static scr_NutObject Instance;
    

    private int _nutIndex;
    private int money=0;
    private void Update()
    {
        if (_isAdded && FollowObject!=null)
        {
            transform.localPosition= Vector3.Lerp(transform.localPosition, FollowObject.transform.localPosition+ new Vector3(0,0,1*.125f), .2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !_isAdded)
        {
            _isAdded = true;
            _nutIndex = scr_DataManager.Instance.AddNut(gameObject);
           gameObject.tag = "Player";
           transform.parent = scr_PlayerController.Instance.transform;
           
           MakeObjectBigger();
        }
    }
    
    public void MakeObjectBigger()
    {
            Vector3 scaleObj = new Vector3(1f , 1f, 1f);
            scaleObj *= 1.5f;
            transform.DOScale(scaleObj, 0.06f)
                .OnComplete(() =>
                {
                    if (FollowObject.GetComponent<scr_NutObject>() != null)
                        FollowObject.GetComponent<scr_NutObject>().MakeObjectBigger();

                    transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
                });
    }

}
