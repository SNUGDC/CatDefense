using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneFromStart : MonoBehaviour
{
	public void ClickStartButton()
	{
		SceneManager.LoadScene("Main");
	}
}
