using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSelection : MonoBehaviour {
	public Sprite sheep;
	public Sprite duck;
	public Sprite salmon;
	public Sprite cow;
	public Sprite chicken;

	public MeatSpecies? meatSpecies
	{
		get {
			return _meatSpecies;
		}
		set {
			_meatSpecies = value;
			if (value == null) {
				GetComponent<SpriteRenderer>().sprite = null;
			}
			else {
				GetComponent<SpriteRenderer>().sprite = GetSprite(value.Value);
			}
		}
	}

    private Sprite GetSprite(MeatSpecies meatSpecies)
    {
		switch (meatSpecies)
		{
			case MeatSpecies.Chicken:
				return chicken;
			case MeatSpecies.Cow:
				return cow;
			case MeatSpecies.Duck:
				return duck;
			case MeatSpecies.Salmon:
				return salmon;
			case MeatSpecies.Sheep:
				return sheep;
		}
		Debug.LogError("Cannot find sprite");
		return null;
    }

    private MeatSpecies? _meatSpecies;

	 /// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		meatSpecies = null;
	}
}
