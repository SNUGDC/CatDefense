using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour {
	public static Cats Instance;

	public List<Cat> cats = new List<Cat>();
	public MeatSpecies? mostValuableMeat;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (cats.Count == 0)
		{
			mostValuableMeat = null;
			return;
		}

		Cat lowestCat = cats[0];
		foreach (var cat in cats)
		{
			if (cat.transform.position.y < lowestCat.transform.position.y) {
				lowestCat = cat;
			}
		}

		mostValuableMeat = lowestCat.meatSpecies;
	}
}
