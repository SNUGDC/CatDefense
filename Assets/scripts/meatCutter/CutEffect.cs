using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutEffect : MonoBehaviour {
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}

	public void Show()
	{
		StartCoroutine(ShowCoroutine());
	}

	IEnumerator ShowCoroutine()
	{
		GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(0.1f);
		GetComponent<SpriteRenderer>().enabled = false;
	}
}
