using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutEffect : MonoBehaviour {
	public List<MEventComponent> events;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}

	public void Show()
	{
		events.ForEach(e => e.Fire());
	}
}
