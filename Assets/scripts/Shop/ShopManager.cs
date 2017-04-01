using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
	public static ShopManager Instance;

	public GameObject[] CheckMark;
	public Sprite[] PriceImages;
	public Image Name;
	public Image BigIcon;
	public Image Price;
	public Image Information;
	public Text MoneyText;

	public List<Upgrade> Upgrades;
	public List<UpgradePrice> UpgradePrices;

	private int whichUpgrade = 0;
	private int money;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		MoneyText.text = "$ " + GlobalInfo.Instance.money.ToString();

		DisplayCurrentUpgradeLevel();
		DisplayCurrentPrice();
	}

	public void ClickedUpgradeButton(int which) //which : "Which" did you clicked? 
	{
		Name.sprite = Upgrades[which].UpgradeName;
		BigIcon.sprite = Upgrades[which].UpgradeBigIcon;
		Information.sprite = Upgrades[which].UpgradeInfo;
		whichUpgrade = which;
	}

	public void CheatButton()
	{
		GlobalInfo.Instance.money = GlobalInfo.Instance.money + 1000;
	}

	[System.Serializable]
	public class Upgrade
	{
		public Sprite UpgradeBigIcon;
		public Sprite UpgradeName;
		public Sprite UpgradeInfo;
	}

	private int GetUpgradeLevel()
	{
		return GlobalInfo.Instance.UpgradeLevel[whichUpgrade];
	}

	private void DisplayCurrentUpgradeLevel()
	{
		switch(GetUpgradeLevel())
		{
			case 0:
			CheckMark[0].SetActive(false);
			CheckMark[1].SetActive(false);
			CheckMark[2].SetActive(false);
			CheckMark[3].SetActive(false);
			CheckMark[4].SetActive(false);
			break;
			case 1:
			CheckMark[0].SetActive(true);
			CheckMark[1].SetActive(false);
			CheckMark[2].SetActive(false);
			CheckMark[3].SetActive(false);
			CheckMark[4].SetActive(false);
			break;
			case 2:
			CheckMark[0].SetActive(true);
			CheckMark[1].SetActive(true);
			CheckMark[2].SetActive(false);
			CheckMark[3].SetActive(false);
			CheckMark[4].SetActive(false);
			break;
			case 3:
			CheckMark[0].SetActive(true);
			CheckMark[1].SetActive(true);
			CheckMark[2].SetActive(true);
			CheckMark[3].SetActive(false);
			CheckMark[4].SetActive(false);
			break;
			case 4:
			CheckMark[0].SetActive(true);
			CheckMark[1].SetActive(true);
			CheckMark[2].SetActive(true);
			CheckMark[3].SetActive(true);
			CheckMark[4].SetActive(false);
			break;
			case 5:
			CheckMark[0].SetActive(true);
			CheckMark[1].SetActive(true);
			CheckMark[2].SetActive(true);
			CheckMark[3].SetActive(true);
			CheckMark[4].SetActive(true);
			break;
			default:
			Debug.Log("Something is Wrong at DisplayCurrentUpgradeLevel in ShopManager");
			break;
		}
	}

	[System.Serializable]
	public class UpgradePrice
	{
		public int[] PriceImage;
	}

	private void DisplayCurrentPrice()
	{
		if(GetUpgradeLevel() == 5)
		{
			Price.sprite = PriceImages[17];
		}
		else
			Price.sprite = PriceImages[UpgradePrices[whichUpgrade].PriceImage[GetUpgradeLevel()]];
	}

	public void BuyUpgrade()
	{
		if(GetUpgradeLevel() <= 4)
		{
			if(GlobalInfo.Instance.money >= UpgradePrices[whichUpgrade].PriceImage[GetUpgradeLevel()] * 100)
			{
				GlobalInfo.Instance.money = GlobalInfo.Instance.money - UpgradePrices[whichUpgrade].PriceImage[GetUpgradeLevel()] * 100;
				GlobalInfo.Instance.UpgradeLevel[whichUpgrade] = GlobalInfo.Instance.UpgradeLevel[whichUpgrade] + 1;
			}
		}
	}
}
