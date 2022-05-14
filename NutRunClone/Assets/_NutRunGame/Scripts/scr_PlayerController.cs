using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class scr_PlayerController : MonoBehaviour
{
    public static scr_PlayerController Instance;
    public SplineFollower playerSplineFollower;
    [SerializeField] int playerSpeed;

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
    
    public void GameStart()
    {
        playerSplineFollower.followSpeed = playerSpeed;
        
        Debug.Log("Oyun Başladı");
    }

 

    
}
