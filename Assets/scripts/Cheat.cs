using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour {

	public void AddMoney()
	{
		GlobalInfo.Instance.money += 1000;
	}

	public void FinishWave()
	{
		Debug.Log("Finish wave called");
		WaveTime.Instance.SetRemainTimeCheat(-1);
	}
}
