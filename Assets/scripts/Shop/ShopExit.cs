using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopExit : MonoBehaviour {
	public void MoveToGame()
	{
		BackgroundMusic.FadeOutAndChangeScene("Main");
	}
}
