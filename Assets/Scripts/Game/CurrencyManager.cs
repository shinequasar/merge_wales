using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable] //직렬화. 유니티 컴포넌트 창에서 편집 가능해짐. monobehaviour을 상속 받지 않아서 해줘야함.
public class Currency //재화들을 string꼴로 기록하는 클래스
{
    public string total_Gold=""; //골드
    public string total_pearl=""; // 진주
    public string total_dia=""; //다이아
    public string addgold="";
    public string addpearl="";
    public string adddia="";
    
    public Currency(int total_Gold, int total_pearl, int total_dia,int addgold, int addpearl, int adddia)
    {
        this.total_Gold = total_Gold.ToString();
        this.total_pearl = total_pearl.ToString();
        this.total_dia = total_dia.ToString();
        this.addgold = addgold.ToString();
        this.addpearl = addpearl.ToString();
        this.adddia = adddia.ToString();
    }

    public string[] printCurrency()
    {
        string[] CurrencyList = new string[] {total_Gold, total_pearl,total_dia,addgold,addpearl,adddia};
        return CurrencyList;
    }
    
}

public class CurrencyManager : MonoBehaviour
{
    //----------------싱글톤
    public static CurrencyManager instance; // 싱글톤을 할당할 전역변수
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

    public Currency currency;
    public int total_Gold=0; //골드
    private int total_pearl=0; // 진주
    private int total_dia=0; //다이아
    int addgold=10;
    int addpearl=2;
    int adddia=1;

    public int Total_Gold
    {
        get { return total_Gold;}
        set { total_Gold = value; }
    }
    public int Total_pearl
    {
        get { return total_pearl;}
        set { total_pearl = value; }
    }
    public int Total_dia
    {
        get { return total_dia;}
        set { total_dia = value; }
    }
    public int Addgold
    {
        get { return addgold;}
        set { addgold = value; }
        
    }
    public int Addpearl
    {
        get { return addpearl;}
        set { addpearl = value; }
    }
    public int Adddia
    {
        get { return adddia;}
        set { adddia = value; }
    }
    
    private void Start()
    {
        LoadCurrencyData();
        printTotalGold();
    }

    

    public void addGole()
    {
        addgold = 50; //새로 더해질 골드 
        
         //if (고래합쳐질때마다 모이는 골드 강화 아이템 샀으면){addgold+=100;이런식으로 아이템 강화아이템 또 만들기}
         
        
        total_Gold += addgold;
        printTotalGold();
        SaveCurrencyData();

    }
    
    

    public void SaveCurrencyData()
    {
        currency.total_Gold = total_Gold.ToString();
        currency.total_pearl = total_pearl.ToString();
        currency.total_dia = total_dia.ToString();
        currency.addgold = addgold.ToString();
        currency.addpearl = addpearl.ToString();
        currency.adddia = adddia.ToString();
        
        JsonData CurrencyJson = JsonMapper.ToJson(currency.printCurrency());
         //Debug.Log(" Currency : "+CurrencyJson);
        File.WriteAllText(Application.persistentDataPath + "/CurrencyData.json", CurrencyJson.ToString());
        //  Debug.Log("재화정보 저장완료!");
        
    }




    public void LoadCurrencyData() // 게임 실행시 한번 실행 해주면 ㅇㅋ
    {
        string filePath = Application.persistentDataPath + "/CurrencyData.json";
       
        
        if (File.Exists(filePath))
        {
            string Jsonstring = File.ReadAllText(filePath);
            // Debug.Log(Jsonstring);
            JsonData jsonData = JsonMapper.ToObject(Jsonstring);
            
              Debug.Log("JsonData로 설정정보 불러오기 완료!");
            // Debug.Log(jsonData);
           
            total_Gold = Convert.ToInt32(jsonData[0].ToString()); // json배열을 풀어서 데이터를 변수에 할당
            total_pearl = Convert.ToInt32(jsonData[1].ToString());
            total_dia = Convert.ToInt32(jsonData[2].ToString());
            addgold = Convert.ToInt32(jsonData[3].ToString());
            addpearl = Convert.ToInt32(jsonData[4].ToString());
            adddia = Convert.ToInt32(jsonData[5].ToString());
        }
        else
        {
            //이전 기록된 데이터가 없을땐 파일을 생성해줌

            File.WriteAllText(Application.persistentDataPath + "/CurrencyData.json", null);
            Debug.Log("게임을 새로 시작합니다. Currency 파일생성");
        }

    }


    public string printaddGold()
    {
        return addgold.ToString();
    }
    
    public void printTotalGold()
    {
        string goldPrint;
        goldPrint = GetThousandCommaText(total_Gold);
        GameObject.Find("goldCountText").GetComponent<Text>().text = goldPrint+"G";
    }
    
    public string GetThousandCommaText(int data) //숫자를 천단위로 바꿔줌
    {
        return string.Format("{0:#,###}", data);
    }
    
    
    
}
