using System.Collections;

using System.Collections.Generic;

using System.Security.Cryptography.X509Certificates;

using JetBrains.Annotations;

using UnityEngine;

public class DataController : MonoBehaviour  //던전 데이터 컨트롤

{

private static DataController instance; 


// DataController 싱글톤화.
public static DataController Instance 

{
    
    get
    
    {
        
        if (instance == null)
        
        {
        
            instance = FindObjectOfType<DataController>();
        
            if (instance == null)
            
            {
            
            GameObject container = new GameObject("DataController");
            
            instance = container.AddComponent<DataController>();
            
            }
        
        }
        
        return instance;
    
    }

}

// 각각의 goldPerSec 들을 모두 합쳐주는 역할

private ItemButton[] itemButtons;

public long depth // 게임에 사용되는 수심

{

    get
    
    {
    
        // 만약 depth에 아무 문장(숫자로된)도 없으면 return 0;
        
        if(!PlayerPrefs.HasKey("Depth"))
        
        {
        
            return 5000;
        
        }
        
        //숫자를 문자로 바꿔 저장(엄청 큰 숫자들도 저장하기 위해서)
        
        string tmpDepth = PlayerPrefs.GetString("Depth");
        
        return long.Parse(tmpDepth); // Parse 숫자를 문장으로 바꿔주는 역할

        
    }
        
    set
        
    {
        
        PlayerPrefs.SetString("Depth", value.ToString());
    
    }

}




public int goldPerClick

{

    get
    
    { // KET : VALUE 만약 값이 없으면 1 이옴.
    
        return PlayerPrefs.GetInt("GoldPerClick", 1);// 아무것도 못받으면 1
    
    }
    
    set
    
    {
    
         PlayerPrefs.SetInt("GoldPerClick",value);
    
    }

}

void Awake() // 게임이 처음 시작될때 시작. 주로 초기화할때 사용

{

    // 씬에 존재하는 모든 오브젝트들을 검사해서 '아이템 버튼'들을 모두 가져와서 배열에 넣기
    
    itemButtons = FindObjectsOfType<ItemButton>();

}

public void Reset()

{

    PlayerPrefs.DeleteAll();

}

// 업그레이드 버튼을 세이브하고 로드하는 기능

public void LoadUpgradeButton(UpgradeButton upgradeButton)

{

    string key = upgradeButton.upgradeName;
    
    upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    
    upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
    
    upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);

}

public void SaveUpgradeButton(UpgradeButton upgradeButton)

{
    
    string key = upgradeButton.upgradeName;
    
    PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
    
    PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
    
    PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);

}

// 아이템버튼 로드 & 세이브

public void LoadItemButton(ItemButton itemButton)

{

    string key = itemButton.itemName;
    
    itemButton.level = PlayerPrefs.GetInt(key + "_level");
    
    itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
    
    itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
    
    // 아이템 소유여부 확인
    
    if (PlayerPrefs.GetInt(key + "_isPurchased") == 1)
    
    {
    
         itemButton.isPurchased = true;
    
    }
    
    else
    
    {
    
         itemButton.isPurchased = false;
    
    }

}

public void SaveItemButton(ItemButton itemButton)

{
    
    string key = itemButton.itemName;
    
    PlayerPrefs.SetInt(key + "_level",itemButton.level);
    
    PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
    
    PlayerPrefs.SetInt(key + "_goldPerSec",itemButton.goldPerSec);
    
    
    if (itemButton.isPurchased == true)
    
    {
    
         PlayerPrefs.SetInt(key + "_isPurchased", 1);
    
    }
    
    else
    
    {
    
         PlayerPrefs.SetInt(key + "_isPurchased", 0);
    
    }

}

// 총 goldPerSec 을 모두 더하는 함수

public int GetGoldPerSec()

{

    int goldPerSec = 0;
    
    for (int i = 0; i < itemButtons.Length; i++)
    
    {
    
    goldPerSec += itemButtons[i].goldPerSec;
    
    }
    
    return goldPerSec;
    
    }

}