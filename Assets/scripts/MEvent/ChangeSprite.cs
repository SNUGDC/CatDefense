using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MEventComponent {
	public Sprite toChange;
	Sprite original;
	public float delay;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		original = GetComponent<SpriteRenderer>().sprite;
	}
    public override void Fire()
    {
		StartCoroutine(ChangeColorCoroutine());
    }

	IEnumerator ChangeColorCoroutine()
	{
		GetComponent<SpriteRenderer>().sprite = toChange;
		yield return new WaitForSeconds(delay);
		GetComponent<SpriteRenderer>().sprite = original;
	}
}
