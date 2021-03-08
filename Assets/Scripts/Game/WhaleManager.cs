using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEditor;
using System.IO;
using LitJson;
using Newtonsoft.Json;

public class WhaleManager : MonoBehaviour
{
    
    //----------------싱글톤
    public static WhaleManager instance; // 싱글톤을 할당할 전역변수
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("씬에 두개 이상의 게임매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    //-----------------------
    

    [System.Serializable] //직렬화. 유니티 컴포넌트 창에서 편집 가능해짐. monobehaviour을 상속 받지 않아서 해줘야함.
    public class WhaleData // 고래의 레벨, 위치를 담는 클래스.
    {
        public int dataLevel { get; set; } // 고래레벨
        public string dataMousePosition { get; set; } //고래 위치
        public string dataName { get; set; } //고래 이름


        public WhaleData(string wname, string wposition, int wlevel)
        {
            this.dataName = wname;
            this.dataMousePosition = wposition;
            this.dataLevel = wlevel;
        }

    }
    
    
    
    
    public WhaleData whaleData; // 현재 생성된 고래의 정보 클래스
    private List<WhaleData> whaleList = new List<WhaleData>(); // 현재 생성된 고래의 정보를 담는 리스트

    private Whale w;
    private string wposition; //생성된 고래의 위치
    private string wname; //생성된 고래의 이름
    private int wlevel; //생성된 고래의 레벨
    public Whale _whale;

    private void Start()
    {
        LoadWhaleData();
    }


    public void SaveWhaleData()
    {
        //현재 씬에 존재하는 고래들을 배열로 받아옴.
        GameObject[] tmpActive = GameObject.FindGameObjectsWithTag("activeWhales");
        whaleList.Clear(); //리스트 비우기

        if (tmpActive == null)
        {
            Debug.Log("현재 생성된 고래 없음");
        }
        else
        {
            for (int i = 0; i < tmpActive.Length; i++)
            {

                // 해당 고래의 위치를 wposition 변수에 문자열로 저장;
                wposition = tmpActive[i].transform.position.x.ToString() + "/" +
                            tmpActive[i].transform.position.y.ToString() + "/" +
                            tmpActive[i].transform.position.z.ToString();
                wname = tmpActive[i].gameObject.GetComponent<Whale>().name;
                wlevel = tmpActive[i].gameObject.GetComponent<Whale>().level;

                whaleList.Add(new WhaleData(wname, wposition, wlevel));
                //  Debug.Log("("+ wposition + ")" +"("+ wname + ")" +"("+  wlevel+ ")");
            }

            JsonData WhaleJson = JsonMapper.ToJson(whaleList);

            File.WriteAllText(Application.persistentDataPath + "/whaleData.json", WhaleJson.ToString());
            //Debug.Log("고래정보 저장완료!");
        }
    }




    public void LoadWhaleData() //게임을 시작할 때만 기능
    {
        string filePath = Application.persistentDataPath + "/whaleData.json";
        
        if (File.Exists(filePath))
        {
            string Jsonstring = File.ReadAllText(filePath);
            // Debug.Log(Jsonstring);
            JsonData jsonData = JsonMapper.ToObject(Jsonstring);
            
            //Debug.Log("JsonData로 고래정보 불러오기 완료!");
            //Debug.Log(jsonData.Count);
            CreateJson(jsonData); //받아온 데이터를 오브젝트로 바꿔 씬에 뿌려주는 함수. 걍 한 함수가 너무 길어지는게 싫어서,,
            jsonData = null;
        }
        else
        {
            //이전 기록된 데이터가 없을땐 파일을 생성해줌

            File.WriteAllText(Application.persistentDataPath + "/whaleData.json", null);
            Debug.Log("게임을 새로 시작합니다. 파일생성");
        }


    }


    //여기 저장된 고래 수만큼 돌려서 이름,레벨에 해당하는 프리팹,위치를 담은 객체 생성시키기
    private void CreateJson(JsonData data) //받아온 데이터를 오브젝트로 바꿔 씬에 뿌려주는 함수
    {

        string dataLevel;
        string dataPos;
        string dataName;


        for (int i = 0; i < data.Count; i++) //배열안에 배열있는 꼴이라 이렇게 이중으로 돌려줘야 값이 나오는 구나
        {

            dataLevel = data[i][0].ToString();
            dataPos = data[i][1].ToString();
            dataName = data[i][2].ToString();
            // Debug.Log("dataLevel : "+dataLevel+"/"+"dataPos : "+dataPos+"/"+"dataName : "+dataName);

            //string꼴의 dataPos를 Vector3꼴로 바꿔주는 작업
            string[] tmpPosArray;
            tmpPosArray = dataPos.Split('/');
            Vector3 Pos = new Vector3(float.Parse(tmpPosArray[0]), float.Parse(tmpPosArray[1]),
                float.Parse(tmpPosArray[2]));

            var newWhale = (GameObject) Instantiate(Resources.Load("Prefabs/" + "level" + dataLevel), Pos,
                Quaternion.identity);
         
            newWhale.name = dataName;
            newWhale.gameObject.tag = "activeWhales"; //생성된 오브젝트의 태그 지정
        }



    }

    
    public void delAlldata()  //출시할땐 삭제하기(혹은 앱이 삭제될때만 발현.그래도 삭제가 나은듯?)
    {
        var objects = GameObject.FindGameObjectsWithTag("activeWhales"); 

        foreach (var obj in objects) // 주변 접촉한 것들의 배열
        {
                    Destroy(obj.gameObject);
        }
        
        SaveWhaleData();
    }
    


    //앱의 활성화 상태를 저장하는 변수(활용할 곳있으면 써. 지금은 딱히 필요없는 변수인듯)
    bool isPaused = false; 

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            isPaused = true;
            /* 앱이 비활성화 되었을 때 처리 */   
            SaveWhaleData();
        }

        else
        {
            isPaused = false;
            /* 앱이 활성화 되었을 때 처리 */    
            
        }
    }
    
    /* 앱이 종료 될 때 처리 */   
    private void OnApplicationQuit()
    {
        SaveWhaleData();
    }

}