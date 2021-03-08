using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScroll_Vertical : MonoBehaviour
{
    public float scrollSpeed = 0.2f; 
    [SerializeField]
    Material myMaterial;
   
  
    private static BackScroll_Vertical instance; 
        
    // BackScroll_Vertical 싱글톤화.
    public static BackScroll_Vertical Instance
    {
        get
        {
            if (instance == null)
        
            {
        
                instance = FindObjectOfType<BackScroll_Vertical>();
        
                if (instance == null)
            
                {
                    GameObject container = new GameObject("BackScroll_Vertical");
            
                    instance = container.AddComponent<BackScroll_Vertical>();
            
                }
            }
            return instance;
        }
    }
    
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        
    }


    // 아니 이거를 0으로 해놓고 그러니까 안되잖아요
    // 1로 바꿨떠니 매우 잘됨 ㅎㅎ
    private int start=1; // 배경 스크롤 시작변수(중지상태)
    
    public void StartScroll()
    {
        start = 1; //스크롤 시작
        Time.timeScale = 1;
    }
    
    public void StopScroll()
    {
        start = 0; //스크롤 중지
        Time.timeScale = 0;
    }
   
    void Update()
    {
        if (start == 1)
        {
            float newOffsetX = myMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
            Vector2 newOffset = new Vector2(0, newOffsetX);
            myMaterial.mainTextureOffset = newOffset;
        }
            

    }

}
