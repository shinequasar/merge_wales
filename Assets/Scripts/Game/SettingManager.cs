using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using LitJson;
using UnityEngine;


[System.Serializable] //직렬화. 유니티 컴포넌트 창에서 편집 가능해짐. monobehaviour을 상속 받지 않아서 해줘야함.
public class Setting
{
    public string BGM;
    public string SFX;
    
    public Setting(float bgm, float sfx)
    {
        this.BGM = bgm.ToString();
        this.SFX = sfx.ToString();
    }

    public string[] printSetting()
    {
        string[] SettingList = new string[] {BGM, SFX};
        return SettingList;
    }
    
}

public class SettingManager : MonoBehaviour
{
    //----------------싱글톤
    public static SettingManager instance; // 싱글톤을 할당할 전역변수
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

    public Setting setting;
    float BGMf = 1;
    float SFXf = 1;

    private void Start()
    {
        
    }

    public void SaveSettingData()
     {
            setting.BGM = SoundManager.instance.printBGM().ToString(); //현재 BGM과 SFX 정보를 받아와 setting 클래스에 넣어주기
            setting.SFX = SoundManager.instance.printSFX().ToString();
            // Debug.Log("setting.ToString() : "+setting.ToString());
            JsonData SettingJson = JsonMapper.ToJson(setting.printSetting());
            // Debug.Log("셋팅메니저의 SettingJson : "+SettingJson);
            File.WriteAllText(Application.persistentDataPath + "/SettingData.json", SettingJson.ToString());
          //  Debug.Log("설정정보 저장완료!");
    }




    public void LoadSettingData() // 게임 실행시 한번 실행 해주면 ㅇㅋ
    {
        string filePath = Application.persistentDataPath + "/SettingData.json";
       
        
        if (File.Exists(filePath))
        {
            string Jsonstring = File.ReadAllText(filePath);
            // Debug.Log(Jsonstring);
            JsonData jsonData = JsonMapper.ToObject(Jsonstring);
            
          //  Debug.Log("JsonData로 설정정보 불러오기 완료!");
           // Debug.Log(jsonData);
           
            BGMf = Convert.ToSingle(jsonData[0].ToString()); // json배열을 풀어서 데이터를 변수에 할당
            SFXf = Convert.ToSingle(jsonData[1].ToString());
        }
        else
        {
            //이전 기록된 데이터가 없을땐 파일을 생성해줌

            File.WriteAllText(Application.persistentDataPath + "/SettingData.json", null);
            Debug.Log("게임을 새로 시작합니다. Setting 파일생성");
        }

    }
    
   

    public float printBGMf() //출력하는 함수
    {
        return BGMf;
    }
    
    public float printSFXf() //출력하는 함수
    {
        return SFXf;
    }
    
   
}
