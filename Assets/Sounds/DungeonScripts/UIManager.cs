using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour

{

    public Text depthDisplayer;

    public Text goldPerClickDisplayer;

    public Text goldPerSecDisplayer;

   
    public static float time;
    
    public Text TimeLimit;
    
    void Start()  //첫 시작 타이머
    {
        time = 10f;
    }
    
    private static UIManager instance; 

// UIManager 싱글톤화.
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
        
            {
                instance = FindObjectOfType<UIManager>();
        
                if (instance == null)
            
                {
                    GameObject container = new GameObject("UIManager");
            
                    instance = container.AddComponent<UIManager>();
            
                }
            }
            return instance;
        }
    }
    
    
    void Update() // 총 골드를 계속 업데이트해 txt 로 보여주는 기능
    {
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (DataController.Instance.depth <= 0) //만약 수심이 0이하로 바뀌면 클리어!
            {
                depthDisplayer.text = "CLEAR!!";
                BackScroll_Vertical.Instance.StopScroll();
                goldPerSecDisplayer.text = "";
                goldPerClickDisplayer.text = "";
                TimeLimit.text = "";
            }
            else
            {
                depthDisplayer.text = "수심 : " + DataController.Instance.depth + "M";
                goldPerClickDisplayer.text = "잠수함 성능 : " + DataController.Instance.goldPerClick;
                goldPerSecDisplayer.text = "자동 부스터 : " + DataController.Instance.goldPerClick;
                int t = Mathf.FloorToInt(time);
                TimeLimit.text = "남은 시간 : " + t;
            }

            
        }  
            if (time <= 0) //만약 남은 시간이 0에 가까워지면
            {
                time = 0;
                BackScroll_Vertical.Instance.StopScroll();
                depthDisplayer.text = "타임오버";
                goldPerSecDisplayer.text = "";
                goldPerClickDisplayer.text = "";
                TimeLimit.text = "";
            }
        
    }

    

}