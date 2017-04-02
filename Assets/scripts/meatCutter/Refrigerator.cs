using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour {
	public Sprite open;
	public Sprite original;
	public MeatSpecies meatSpecies;

	public void Open()
	{
		StartCoroutine(openCoroutine());
	}

	IEnumerator openCoroutine()
	{
		GetComponent<SpriteRenderer>().sprite = open;
		yield return new WaitForSeconds(0.1f);
		GetComponent<SpriteRenderer>().sprite = original;
	}
}
