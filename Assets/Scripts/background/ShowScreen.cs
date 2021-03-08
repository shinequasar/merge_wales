using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//게임 실행화면 크기, 꺼짐여부, 백버튼 팝업창 등을 관리하는 스크립트
public class ShowScreen : MonoBehaviour
{
    public GameObject Panel;
   
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //게임 실행 중 화면이 꺼지지 않게 하는 역할
        Screen.SetResolution(720, 1380, true); //스크린 비율고정
    }

   void Update()  // 백 버튼을 눌렀을 시에 종료 팝업창 활성화
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.SetActive(true);  
        }
    }

   public void Close() // 앱 종료
   {
        Application.Quit();  
   }
}
