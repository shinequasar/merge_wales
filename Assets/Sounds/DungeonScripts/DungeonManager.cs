using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    private static DungeonManager instance; 


// DungeonManager 싱글톤화.
    public static DungeonManager Instance
    {
        get
        {
            if (instance == null)
        
            {
        
                instance = FindObjectOfType<DungeonManager>();
        
                if (instance == null)
            
                {
                    GameObject container = new GameObject("DungeonManager");
            
                    instance = container.AddComponent<DungeonManager>();
            
                }
            }
            return instance;
        }
    }
    
    
    public int dungeonLevel // 던전 레벨
    {
        get
        {
            // 만약 dungeonLevel에 아무 값도 없으면 return 1;
            if(!PlayerPrefs.HasKey("dungeonLevel"))
            {
                return 1;
            }
            return dungeonLevel;
        }
        set
        {
            PlayerPrefs.SetInt("dungeonLevel", value);
        }

    }

    public int step // 스텝단계 레벨
    {
        get
        {
            // 만약 step에 아무  아무 값도 없으면 return 1;
            if(!PlayerPrefs.HasKey("step"))
            {
                return 1;
            }
            return step;
        }
        set
        {
            PlayerPrefs.SetInt("step", value);
        }

    }

    public void addLevel()
    {
        if (step == 1 && DataController.Instance.depth>0) 
        {
            
        }
    }
    



}
