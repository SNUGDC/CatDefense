using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUpdater : MonoBehaviour {
	public Text moneyText;
	
	// Update is called once per frame
	void Update () {
		int money =  GlobalInfo.Instance.money;
		moneyText.text = string.Format("${0,6}", money);
	}
}
