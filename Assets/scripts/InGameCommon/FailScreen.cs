using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailScreen : MonoBehaviour {

	public void GoToRetry()
	{
		// GlobalInfo.Instance = new GlobalInfo();
		BackgroundMusic.FadeOutAndChangeScene("Main");
	}

	public void GoToShop()
	{
		BackgroundMusic.FadeOutAndChangeScene("Shop");
	}
}
