using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {
	public MeatSpecies species;
	public Color highlightColor;
	
	public void Highlight()
	{
		GetComponent<SpriteRenderer>().color = highlightColor;
	}

	public void Unhighlight()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		MeatSpecies? mostValuableMeat = Cats.Instance.mostValuableMeat;
		if (mostValuableMeat == null)
		{
			Unhighlight();
			return;
		}

		if (mostValuableMeat.Value == species)
		{
			Highlight();
		}
		else
		{
			Unhighlight();
		}
	}
}
