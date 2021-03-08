using System.Collections;

using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour

{ //부스터 업그레이드

    public Text upgradeDisplayer;//텍스트 띄워주기용

    public string upgradeName;//업그레이드 아이템 이름

    [HideInInspector]

    public int goldByUpgrade;// 부스터 업그레이드 수치

    [HideInInspector]

    public int baseGoldByUpgrade;

    public int startGoldByUpgrade = 1;// 게임 처음할때 업그레이드 수치

    [HideInInspector]

    public int currentCost = 1;//현재가격

    public int startCurrentCost = 1;// 게임 처음할 때 시작 가격

    [HideInInspector]

    public int level = 1;

    public float upgradePow = 0.5f;// 부스터 업그레이드할 수치

    public float costPow = 3.14f;// 올라갈 가격수치

    void Start()

    {

        DataController.Instance.LoadUpgradeButton(this);

        UpdateUI();

    }

    public void PurchaseUpgrade()

    {

        if (DataController.Instance.depth >= currentCost)

        {

            DataController.Instance.depth -= currentCost;

            level++;

            DataController.Instance.goldPerClick += goldByUpgrade;

            UpdateUpgrade();

            UpdateUI();

            DataController.Instance.SaveUpgradeButton(this);

        }

    }

    public void UpdateUpgrade()

    {

        goldByUpgrade = startGoldByUpgrade * (int) Mathf.Pow(upgradePow, level);

        currentCost = startCurrentCost * (int) Mathf.Pow(costPow, level);

    }

    public void UpdateUI()

    {

        upgradeDisplayer.text = upgradeName + "\n가격 : " + currentCost + "\n레벨 : " + level +

                                "\n다음 예상 성능 : " + goldByUpgrade;

    }

}