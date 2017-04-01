using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configurations : MonoBehaviour {
	public float WaveTime = 10.0f;
	public float FeverTime = 5.0f;

	public static Configurations Instance;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}
}
