using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSprite : MEventComponent
{
    public float duration;

    public override void Fire()
    {
        StartCoroutine(ShowCoroutine());
    }

    IEnumerator ShowCoroutine()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		renderer.enabled = true;
		yield return new WaitForSeconds(duration);
		renderer.enabled = false;
	}
}
