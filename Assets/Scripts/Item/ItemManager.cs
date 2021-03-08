using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // //----------------싱글톤
    // public static ItemManager instance; // 싱글톤을 할당할 전역변수
    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    // //-----------------------
    //
    // [System.Serializable] //직렬화. 유니티 컴포넌트 창에서 편집 가능해짐. monobehaviour을 상속 받지 않아서 해줘야함.
    // public class ItemData // 모든 아이템 정보들을 담는 클래스.
    // {
    //     public int UserLevel { get; set; } // 유저 레벨
    //     public TownSizeItem.TownSizeItemData townSizeItemData { get; set; } //마을크기   //클래스안에 클래스를 자료형으로 가져올땐 이렇게!
    //    
    //
    //     public ItemData(int userlevel, TownSizeItem.TownSizeItemData townsizeitemData) 
    //     {
    //         this.UserLevel = userlevel;    // 유저 레벨    
    //         this.townSizeItemData = townsizeitemData; //마을크기 아이템
    //     }
    //     
    //
    // }
    //
    //
    //
    //
    // public void SaveCurrencyData()
    // {
    //     ItemData.UserLevel = total_Gold.ToString(); //배경화면 아이템이 업그레이드 되면 레벨 증가
    //     
    //     
    //     JsonData ItemJson = JsonMapper.ToJson(currency.printCurrency());
    //     //Debug.Log(" Currency : "+CurrencyJson);
    //     File.WriteAllText(Application.persistentDataPath + "/ItemData.json", ItemJson.ToString());
    //     //  Debug.Log("재화정보 저장완료!");
    //     
    // }

   
    
    
}
