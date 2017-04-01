using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
	static int money;
	public static ShopManager Instance;

	public Image Name;
	public Image BigIcon;
	public Image Price;
	public Image Information;
	public Text MoneyText;

	public List<Upgrade> Upgrades;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		MoneyText.text = "$ " + money.ToString();
	}

	public void ClickedUpgradeButton(int which) //which : "Which" did you clicked? 
	{
		Name.sprite = Upgrades[which].UpgradeName;
		BigIcon.sprite = Upgrades[which].UpgradeBigIcon;
		Information.sprite = Upgrades[which].UpgradeInfo;
	}

	public void CheatButton()
	{
		money = money + 1000;
	}

	[System.Serializable]
	public class Upgrade
	{
		public Sprite UpgradeBigIcon;
		public Sprite UpgradeName;
		public Sprite UpgradeInfo;
	}
}
