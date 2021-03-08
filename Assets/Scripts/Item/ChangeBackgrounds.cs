using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeBackgrounds : MonoBehaviour
{
    private GameObject mainBackground;
    private Sprite currentSprite;
    public Sprite newSprite;
    private bool change;
    void Start()
    {
        mainBackground = GameObject.FindGameObjectWithTag("mainBackground");
       // Debug.Log(mainBackground.GetComponent<SpriteRenderer>().sprite);
       // Debug.Log("스타트 실행됨");
        change = false;
    }

    public void ChangSprite() //배경 스프라이트 변경
    {
        Debug.Log(newSprite);
        mainBackground = GameObject.FindGameObjectWithTag("mainBackground");
        Debug.Log("버튼 눌림");
    }

    public void ChangeTrue() //잠깐 chage를 true로!
    {
        change = true;
    }

    void Update()   //이걸 update말고 다른 함수형으로 필요할 때만 호출할 수 있는 방법 없을까?
    {
        if (change == true)
        {
            mainBackground.GetComponent<SpriteRenderer>().sprite = newSprite;  //newSprite는 어디에 있지??
            Debug.Log(newSprite+"로 바뀌어라!");
            change = false;  //배경바꾸고 다시 chage를 false로
        }
    }
}
