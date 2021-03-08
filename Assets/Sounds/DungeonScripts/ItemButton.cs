using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class ItemButton : MonoBehaviour

{

    public Text itemDisplyer;

    public string itemName;

    public int level;

    [HideInInspector]

    public int currentCost;

    public int startCurrentCost = 1;

    [HideInInspector]

// 일초에 골드를 자동으로 몇만큼 증가시키는지.

    public int goldPerSec;

// 처음 아이템을 구입했을때 초기값

    public int startGoldPerSec = 1;

    public float costPow = 3.14f;

//아이템 구입시마다 몇배나 goldPerSec 가 증가할지

    public float upgradePow = 0.5f;

    [HideInInspector]

// 구매 했는지 안했는지 여부

    public bool isPurchased = false;

    void Start()

    {

        DataController.Instance.LoadItemButton(this);

        StartCoroutine("AddGoldLoop");

        UpdateUI();

    }

// 아이템 구입

    public void PurchaseItem()

    {

        if (DataController.Instance.depth >= currentCost)

        {

            isPurchased = true;

            DataController.Instance.depth -= currentCost;

            level++;

            UpdateItem();

            UpdateUI();

//아이템 구매정보들이 Datacontroller 에 저장

            DataController.Instance.SaveItemButton(this);

        }

    }

// 코루틴 : yield 문은 만나면 대기시간을 가짐. 다른 함수들과 같이 돌아갈 수 있음. 일정시간의 간격을 두고 어떤 행위를 반복 실행할때 좋음.

    IEnumerator AddGoldLoop()

    {

        while (true)

        {

            if (isPurchased)

            {

                DataController.Instance.depth += goldPerSec;

            }

            yield return new WaitForSeconds(1.0f); // 1초마다 골드 증가

        }

    }

    public void UpdateItem()

    {

        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);

        currentCost = startCurrentCost * (int) Mathf.Pow(costPow, level);

    }

    public void UpdateUI()

    {

        itemDisplyer.text = itemName + "\n레벨 : " + level + "\n가격 : " + currentCost + "\n잠수함 성능 : " +

                            goldPerSec +"m"+ "\n구매여부: " + isPurchased;

    }

}