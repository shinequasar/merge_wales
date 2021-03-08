using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    private int start=0; // 배경 스크롤 시작변수(중지상태)
    
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
}
