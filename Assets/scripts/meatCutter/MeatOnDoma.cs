using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatOnDoma : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	public void ShowMeat()
	{
		spriteRenderer.enabled = true;
	}

	public void HideMeat()
	{
		spriteRenderer.enabled = false;
	}
}
