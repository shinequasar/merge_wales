using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreateWhales : MonoBehaviour
{
   
   
   //----------------싱글톤
   public static CreateWhales instance; // 싱글톤을 할당할 전역변수
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   //-----------------------
   
   
   
   Vector3 dir;
   private int count = 7;// 생성할 수 있는 고래의 최대개수 //json 받아서 넣기

   public int Count
   {
      get { return count;}
      set { count = value; }
   }
   

 
   public void newWhales()
   {
      GameObject[] tmpActive = GameObject.FindGameObjectsWithTag("activeWhales");
      
      
      
      if (tmpActive.Length >= count)
      {
         //Debug.Log("tmpActive.Length : "+tmpActive.Length+"  count : "+count);
         
        GameObject.Find("WhaleCountText").GetComponent<Text>().text = "[아이템 강화 필요] 최대 고래 수는 '"+count+"'마리 입니다.";
        //텍스트 뒤 이미지 나타남
        GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage").gameObject.SetActive(true);
        GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage2").gameObject.SetActive(true);
           
      }
      else
      {
         GameObject.Find("WhaleCountText").GetComponent<Text>().text = " ";
         //텍스트 뒤 이미지 사라짐
         GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage").gameObject.SetActive(false);
         GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage2").gameObject.SetActive(false);
         
         float randomX = Random.Range(50f, 600f);
         float randomY = Random.Range(250f, 1000f);
      
      

         var point = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 10));
      
         var newWhale = Instantiate(Resources.Load("Prefabs/"+"level1"), point, Quaternion.identity);
         newWhale.name = Random.Range(0f, 100f).ToString();
         SoundManager.instence.PlaySE("button_sound");
         DiscoveryManager.instance.discovery(0);

      }
   }

   
   public void CountPrint() //화면UI에 마을 크기 띄우기
   {
      GameObject[] tmpActive = GameObject.FindGameObjectsWithTag("activeWhales");
      // if (GameObject.Find("CountText") == null) Debug.Log("0이다");
      // else GameObject.Find("CountText").GetComponent<Text>().text = "마을 크기 "+tmpActive.Length+" / "+count;
      GameObject.Find("CountText").GetComponent<Text>().text = "마을 크기 "+tmpActive.Length+" / "+count;
      
   }



   public void delCountdata() //출시할땐 삭제하기(혹은 앱이 삭제될때만 발현.그래도 삭제가 나은듯?)
   {
      count = 0;
   }

}
