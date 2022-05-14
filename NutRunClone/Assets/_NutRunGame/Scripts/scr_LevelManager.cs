using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class scr_LevelManager : MonoBehaviour
{
    public static scr_LevelManager Instance;
    
    
    public List<GameObject> LevelPrefabs;
    int level;
    public GameObject garbageObject;

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
        
        
        
        level = PlayerPrefs.GetInt("level");

        if (level<LevelPrefabs.Count)
        {
            Instantiate(LevelPrefabs[level],garbageObject.transform);
        }
        else
        {
              Instantiate(LevelPrefabs[Random.Range(0, LevelPrefabs.Count)],garbageObject.transform);
        }
    }



    public void DestroyTheLevel()
    {
 
        scr_PlayerController.Instance.playerSplineFollower.SetPercent(0);
        scr_PlayerController.Instance.playerSplineFollower.followSpeed = 0;
        scr_PlayerController.Instance.transform.position = Vector3.zero;
        scr_PlayerController.Instance.playerSplineFollower.enabled = true;
      
        
        for (int i = 0; i < garbageObject.transform.childCount; i++)
        {
            GameObject _destroyedObject = garbageObject.transform.GetChild(i).gameObject;
            Destroy(_destroyedObject);
        }
        
    }

    public void NextLevel()
    {
        DestroyTheLevel();
        Awake();
        
    }
}
