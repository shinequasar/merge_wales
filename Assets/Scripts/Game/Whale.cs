using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;






public class Whale : MonoBehaviour
{
    public int level;
    private bool isDrag; //그냥 터치가 들어오는지 아닌지 알려주는거
    public GameObject NextPrefab;
    private Vector3 mousePosition;
    public GameObject PopUpText;
    
    
    private void Update()
    {
        CreateWhales.instance.CountPrint();
    }



    private void OnMouseDown()
    {
        isDrag = true;
        GameObject.Find("WhaleCountText").GetComponent<Text>().text = " ";
        GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage").gameObject.SetActive(false);
        GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage2").gameObject.SetActive(false);
        CreateWhales.instance.CountPrint();
    }

    private void OnMouseDrag()
    {
        if (isDrag)
        {
            mousePosition.x = Input.mousePosition.x;
            mousePosition.y = Input.mousePosition.y;
            mousePosition.z = 10;

            //마우스 좌표를 스크린 투 월드로 바꾸고 이 객체의 위치로 설정해 준다.
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    
    private void OnMouseUp()
    {
        WhaleManager.instance.SaveWhaleData();
        //OverlapSphere : 지정한 위치로부터 범위안에 접촉한 콜라이더 배열로 반환
        var Colliders = Physics.OverlapSphere(transform.position, 0.1f); 

            foreach (var col in Colliders) // 주변 접촉한 것들의 배열
            {
                if (name != col.gameObject.name) //이름 다를경우 go
                {
                    if (level == col.gameObject.GetComponent<Whale>().level) //나에게 저장된 level과 접촉한 것의 level이 같으면
                    {
                        var newWhale = Instantiate(NextPrefab, transform.position, Quaternion.identity);
                       // Debug.Log(">>>>>>>>>nextprefeb : "+NextPrefab.name);
                            newWhale.name = Random.Range(0f, 200f).ToString(); //이름은 난수생성 
                            newWhale.gameObject.tag = "activeWhales"; //생성된 오브젝트의 태그 지정
                            showPopUpText(mousePosition);  //획득 골드 팝업
                                                      
                            
                           SoundManager.instence.PlaySE("merge_sound");
                           CurrencyManager.instance.addGole();
                           
                        print(col.gameObject.name);
                        print(gameObject.name);

                        Destroy(col.gameObject);
                        Destroy(gameObject);  
                        WhaleManager.instance.SaveWhaleData();
                        DiscoveryManager.instance.discovery(level); //고래생성
                        DiscoveryManager.instance.SaveDiscoveryData();// discoverylist 저장
                        
                        break;
                    }
                }
            } 
       
        isDrag = false;
    }
    
    public void showPopUpText(Vector3 point) //획득 골드 팝업
    {
        point = new Vector3(point.x, point.y+120, point.z);
        PopUpText.gameObject.GetComponent<Text>().text = "+"+CurrencyManager.instance.printaddGold()+"G"; //골드데이터 불러오기
        var newText = Instantiate(PopUpText, point, Quaternion.identity);
        newText.transform.SetParent(GameObject.Find("goldCount").transform);
        
    }


  

}