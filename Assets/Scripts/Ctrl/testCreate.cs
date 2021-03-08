using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCreate : MonoBehaviour
{
    public GameObject testPrefeb;

    public void TestCreate()
    {
        float randomX = Random.Range(50f, 600f);
        float randomY = Random.Range(250f, 1000f);
        var point = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 10));
        
        var newWhale = Instantiate(testPrefeb, point, Quaternion.identity);
        newWhale.name = Random.Range(0f, 200f).ToString(); //이름은 난수생성 
        newWhale.gameObject.tag = "activeWhales"; //생성된 오브젝트의 태그 지정
        SoundManager.instence.PlaySE("button_sound");
    }
}
