using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scr_FinishWall : MonoBehaviour
{
    private bool isTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            this.gameObject.transform.DOMoveZ(this.transform.position.z + .05f, .5f);


        }
            
            
    }
}
