using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 최대 생성 고래수와 마을 수용인원, 레벨, UI를 관리하는 게임 메니저
//씬에는 단 하나의 게임 매니저만 존재할 수 있음
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역변수
    public bool createWhale = true;  //고래 생성 가능여부(고래밥 다 떨어지면 false로 할당하기)
    public Text chanceGoraBob;  //남은 고래밥 수를 출력해 줄 텍스트;
    public Text capacity;  //남은 고래 수용인원를 출력해 줄 텍스트;
    public int level; //레벨
    
    //게임 시작과 동시에 싱글턴을 구성
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    //레벨을 증가시키는 메서드
    public void AddLevel()
    {
        level++;
    }

    //고래 생성가능여부
    
    
    
}
