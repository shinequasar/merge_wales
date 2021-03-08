using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveryManager : MonoBehaviour
{
    //----------------싱글톤
    public static DiscoveryManager instance; // 싱글톤을 할당할 전역변수
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
    
    
    private int[] discoveryList = new int[60];  //만약 고래 캐릭터를업데이트 한다면 이 배열 숫자를 증가시키도록해
    private GameObject gameWhale; //DistroyImage()에 넣기 위한 변수
    void Start()
    {
        LoadDiscoveryData();
    }
    
    
    
    
    
    public void discovery(int level)  // discoveryList 이것도 제이슨에 저장해야해. 게임데이터로
    {
        discoveryList[level+1] += 1; // 새로 생성된 레벨만 1로 더해주기
       // Debug.Log("합성되어 나온 고래의 레벨 : "+ (level+1));
       // Debug.Log("discoveryList[level+1] 값 : "+ discoveryList[level+1]);
        if (discoveryList[level+1] == 1)
        {
            Particle.instance.particles();
            GameObject.Find("active").transform.Find("discoveryPanel").gameObject.SetActive(true);
            getImage(level);
        }
    }
    
    public void discoveryReset()  // discoveryList 리셋
    {
        for (int i = 0; i < discoveryList.Length; i++)
        {
            discoveryList[i] = 0;
        }
       
        SaveDiscoveryData();
        Debug.Log("디스커버리 정보가 리셋되었습니다.");
    }


    public void getImage(int level)
    {
        // 발견패널에 해당 레벨에 맞는 이름 넣기  //-----------------------여기 우변으로 고래 이름 넣어주면돼. db에 고래이름 넣어주고 이걸로 넣기
        GameObject.Find("Whalename").GetComponent<Text>().text = WhaleDB.instance.WhaleName(level);
        GameObject.Find("explanation_Text").GetComponent<Text>().text = WhaleDB.instance.WhaleProfile(level);
        Vector3 Pos = new Vector3(0, 4.3f, -8);
        var newWhale = (GameObject) Instantiate(Resources.Load("Prefabs/" + "level" + (level+1)), Pos,
            Quaternion.identity);
        newWhale.transform.SetParent(GameObject.Find("discoveryPanel").transform);
        newWhale.name = "tmpWhale"; //패널 띄워주기용 임시 고래
        newWhale.transform.localScale = new Vector3(2.5f, 2.5f, 1);
        newWhale.tag = "Untagged";
        gameWhale = newWhale; //잠시 보여줬다가 삭제할 프리팹
    }

    public void DistroyImage()
    {
       Destroy(gameWhale);
       //Debug.Log("tmpWhale 삭제함");
       
    }


    public void SaveDiscoveryData()  // discovery정보 저장
    {
        JsonData discoveryJson = JsonMapper.ToJson(discoveryList);
        // Debug.Log("셋팅메니저의 SettingJson : "+SettingJson);
        File.WriteAllText(Application.persistentDataPath + "/DiscoveryData.json", discoveryJson.ToString());
          Debug.Log("디스커버리 정보 저장완료!");
    }


    public void LoadDiscoveryData() // 게임 실행시 한번 실행 해주면 ㅇㅋ  // discovery정보 로드
    {
        string filePath = Application.persistentDataPath + "/DiscoveryData.json";
       
        
        if (File.Exists(filePath))
        {
            string Jsonstring = File.ReadAllText(filePath);
            // Debug.Log(Jsonstring);
            JsonData jsonData = JsonMapper.ToObject(Jsonstring);
            
            //  Debug.Log("JsonData로 설정정보 불러오기 완료!");
            // Debug.Log(jsonData);

            for (int i = 0; i < jsonData.Count; i++)// json배열을 풀어서 데이터를 변수에 할당
            {
                discoveryList[i] = Convert.ToInt32(jsonData[i].ToString()); 
            }
            
        }
        else
        {
            //이전 기록된 데이터가 없을땐 파일을 생성해줌

            File.WriteAllText(Application.persistentDataPath + "/DiscoveryData.json", null);
            Debug.Log("게임을 새로 시작합니다. discovery 파일생성");
            
            //처음 게임을 한다면 리스트 초기화
            for (int i = 0; i < discoveryList.Length; i++)
            {
                discoveryList[i] = 0;

            }
        }

    }
}
