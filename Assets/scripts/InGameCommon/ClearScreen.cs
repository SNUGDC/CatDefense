using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour {

	public void GoToShop()
	{
		BackgroundMusic.FadeOutAndChangeScene("Shop");
	}

	public void GoToNext()
	{
		BackgroundMusic.FadeOutAndChangeScene("Main");
	}
}
