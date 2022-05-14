using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines.Primitives;

public class scr_PlayerChildController : MonoBehaviour
{
    private float _touchX;
    private float _deltaX;
    private float _touchOldPosX;
    private float _touchNewPosX;
    [SerializeField] float clampX;
    [SerializeField] float horSpeed;
    [SerializeField] float swipeSpeed;
    public static scr_PlayerChildController Instance;
    
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
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    public void Move()
    {
        _touchX = Input.GetAxis("Mouse X") * Time.deltaTime*horSpeed;
            _deltaX = _touchX - _touchOldPosX;
            _touchOldPosX = _touchNewPosX;
            
            transform.localPosition = new Vector3(transform.localPosition.x+_deltaX, transform.localPosition.y, transform.localPosition.z);
           
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -clampX, clampX),
                transform.localPosition.y, transform.localPosition.z);
    }

    
}
