using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class TownSizeItem : MonoBehaviour //이걸로 마을크기아이템 몇 레벨 이상이어야 아이템을 구입할 때 필요한 최소레벨 정하기 여기서 수정!
{
    
    //----------------싱글톤
    public static TownSizeItem instance; // 싱글톤을 할당할 전역변수
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

    
    
    [System.Serializable] //직렬화. 유니티 컴포넌트 창에서 편집 가능해짐. monobehaviour을 상속 받지 않아서 해줘야함.
    public class TownSizeItemData // 고래의 레벨, 위치를 담는 클래스.
    {
        public int TownCount { get; set; } // 마을크기
        public string ItemTownText { get; set; } //아이템 설명
        public int ItemSizeLvText { get; set; } //사이템 구입가능 레벨
        public string ItemTowngoldText { get; set; } //아이템 가격
        
        public int TownItemLv { get; set; } //TownCount()에서 쓰이는 구입한 마을크기 아이템 단계
        
        public int NeedLv { get; set; } //마을크기 아이템을 구입하기 위해 필요한 레벨
        

        public TownSizeItemData(int towncount, string itemtownText, int needlv, string itemtowngoldText, int townitemLv)
        {
            this.TownCount = towncount;    // 마을크기 --> a
            this.ItemTownText = itemtownText;    //아이템 설명 --> b
            this.ItemSizeLvText = needlv;    //마을크기 아이템을 구입하기 위해 필요한 레벨 --> f
            this.ItemTowngoldText = itemtowngoldText;    //아이템 가격 --> d
            this.TownItemLv = townitemLv;    //TownCount()에서 쓰이는 구입한 마을크기 아이템 단계 --> e
        }

    }
    
    //json화 시킬 여기저기 널린 데이터 가져올 변수. 가져왔다가 한번에  TownSizeItemData 넣을 예정
    private int a;
    private string b;
    private int c;
    private string d;
    private int e;
    private List<TownSizeItemData> dataList = new List<TownSizeItemData>(); // 현재 생성된 TownSizeItemData 정보를 담는 리스트
   // private List<dataList> DataList = new List<dataList>(); // 현재 생성된 고래의 정보를 담는 리스트
    
    private int townItemLv = 0;//TownCount()에서 쓰이는 구입한 마을크기 아이템 단계 (i에 저장할거) 이것도 start에서 load필요
    private int UserLv = 1; //유저의 레벨---------------? 배경화면 구입시 저장되는걸 load로 받아와야함
    private int needLV = 1; //마을크기 아이템을 구입하기 위해 필요한 레벨
    
    private int[] TownItemCost= //아이템 구입시 증가비용. 마을크기 개수만큼 필요 //이건 일단 더미데이터------------------------------------------
    {
        5,10,15,20,25,30,25,30,25,30,
        30,25,30,25,30,25,30,25,30,25,
        30,25,30,25,30,25,30,25,30,25,
        30,25,30,0
    }; //마을확장 아이템 가격
    
    public void printButton() //얘 어디서 사용하지? ->TownCount()에서 씀
    {
        if (CreateWhales.instance.Count != 40)
        {
            GameObject.Find("Item_townText").GetComponent<Text>().text 
                = "[영구] 마을 크기를 "+Convert.ToString(CreateWhales.instance.Count)+
                  "->"+Convert.ToString(CreateWhales.instance.Count+1)+"만큼 증가시킨다."; //여기까진 됨
            b =  "[영구] 마을 크기를 "+Convert.ToString(CreateWhales.instance.Count)+
                 "->"+Convert.ToString(CreateWhales.instance.Count+1)+"만큼 증가시킨다."; //json파일 만들거
            CurrencyManager.instance.printTotalGold(); //메인화면에 골드 수정
        }
        else
        {
            GameObject.Find("Item_townText").GetComponent<Text>().text 
                = "[영구] 마을 크기 아이템 ALL CLEAR!"; 
            b = "[영구] 마을 크기 아이템 ALL CLEAR!"; //json파일 만들거
        }
        
    }


    string[] townPurchase_status = //최대 마을크기40까지 생성가능, 0은 구입X, 1은 구입O
    {
        "0","0","0","0","0","0","0","0","0","0",
        "0","0","0","0","0","0","0","0","0","0",
        "0","0","0","0","0","0","0","0","0","0",
        "0","0","0","end"
    };


    
    
    public void TownCount()//마을 크기를 강화하는 아이템 구입
    {
         for (int i = townItemLv; i < townPurchase_status.Length; i++) //
         {
             if (townPurchase_status[i] == "end")
             {
                 townPurchase_status[i] = "1"; //전부 구입했다는 표시
                 GameObject.Find("Item_townText").GetComponent<Text>().text 
                     = "[영구] 마을 크기 아이템 ALL CLEAR!";
                 b = "[영구] 마을 크기 아이템 ALL CLEAR!"; //json파일 만들거
                 popup("전부 구입한 아이템입니다.");
                 break;
             }
             else{
                 
                 if (townPurchase_status[i] == "1")
                 {
                     GameObject.Find("Item_townText").GetComponent<Text>().text 
                         = "[영구] 마을 크기 아이템 ALL CLEAR!"; 
                     b = "[영구] 마을 크기 아이템 ALL CLEAR!"; //json파일 만들거
                     popup("전부 구입한 아이템입니다.");
                     break;
                 }
                 else
                 {
                     //만약 전체 골드
                     if (townPurchase_status[i] == "0") //만약 해당 아이템 구입 전이면
                     {
                         //이걸로 몇 레벨 이상이어야 아이템을 구입할 때 필요한 최소레벨 정하기 ----------지금은 더미데이터!!
                         if (townItemLv == 5){needLV=2; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV;}
                         else if (townItemLv == 10) {needLV=3; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV; }
                         else if (townItemLv == 15) {needLV=4; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV; }
                         else if (townItemLv == 20) {needLV=5; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV; }
                         else if (townItemLv == 25) {needLV=6; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV; }
                         else if (townItemLv == 30) {needLV=7; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV; }
                         else if (townItemLv == 35) {needLV=8; GameObject.Find("Item_size_LvText").GetComponent<Text>().text = "LV." + needLV + " 이상";c = needLV; }
                         
                         if (CurrencyManager.instance.Total_Gold >= TownItemCost[i] && UserLv >= needLV)
                         {
                             //해당 단계아이템가격 지불 후 구입
                             CurrencyManager.instance.Total_Gold = CurrencyManager.instance.Total_Gold - TownItemCost[i]; //차감
                             townPurchase_status[i] = (i+1)+" 구입함";
                             CurrencyManager.instance.SaveCurrencyData(); //저장
                             CreateWhales.instance.Count += 1; //마을 수 하나 증가
                                a = CreateWhales.instance.Count; //json파일 만들거
                             townItemLv = i;//현재 타운아이템 구입단계 인덱스.
                                e = townItemLv;//json파일 만들거
                             GameObject.Find("Item_towngoldText").GetComponent<Text>().text  = TownItemCost[townItemLv].ToString(); //아이템 가격수정
                                d = TownItemCost[townItemLv].ToString();//json파일 만들거
                             CurrencyManager.instance.printTotalGold(); //메인화면에 골드 수정
                             printButton();
                             Debug.Log(TownItemCost[i]+" i: "+i);
                             popup("마을 아이템 구입이 완료되었습니다.");
                             break;
                             
                         }
                         else if(CurrencyManager.instance.Total_Gold < TownItemCost[i] && UserLv < needLV)
                         {
                             popup("골드와 현재 LV 이 부족합니다.");
                             break;
                         }
                         else if(CurrencyManager.instance.Total_Gold < TownItemCost[i])
                         {
                             popup("골드가 부족합니다.");
                             break;
                         }
                         else if(UserLv < needLV)
                         {
                             popup("LV 이 부족합니다. 현재 나의 레벨 : LV."+UserLv);
                             break;
                         }
                     }
                 }

                
             }    
         }
         dataList.Add( new TownSizeItemData(a, b, c, d, e)); 
     
    }
    
    void popup(string mesege)
    {
        GameObject.Find("active").transform.Find("popupText").GetComponent<Text>().text = mesege;
        //텍스트 뒤 이미지 나타남
        GameObject.Find("active").transform.Find("popupImage").gameObject.SetActive(true);
        GameObject.Find("active").transform.Find("popupImage2").gameObject.SetActive(true);
        Debug.Log(mesege);
        //0.7초후 사라짐
        StartCoroutine(SetActiveObjInSecond(GameObject.Find("active").transform.Find("popupText").gameObject, 0.7f));
        StartCoroutine(SetActiveObjInSecond(GameObject.Find("active").transform.Find("popupImage").gameObject, 0.7f));
        StartCoroutine(SetActiveObjInSecond(GameObject.Find("active").transform.Find("popupImage2").gameObject, 0.7f));
        GameObject.Find("WhaleCountText").GetComponent<Text>().text = " ";
        //텍스트 뒤 이미지 사라짐
        GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage").gameObject.SetActive(false);
        GameObject.Find("TextGameObjects").transform.Find("WhaleCountImage2").gameObject.SetActive(false);
             
    }
         
    //오브젝트가 사라지게하는 코루틴
    IEnumerator SetActiveObjInSecond(GameObject obj, float second)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(second);
        obj.SetActive(false);
    }
    
   
        
   
    

}
