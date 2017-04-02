using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configurations : MonoBehaviour {
	public float WaveTime = 10.0f;
	public float FeverTime = 5.0f;
	public float PerfectRatio = 0.1f;
	public float GoodRatio = 0.2f;

	public int GoodReward = 10;
	public float PerfectReward = 1.3f;
	public float BadReward = 0.7f;

	public float defaultKnifeSpeed = 6f;
	public int meatPrice = 5;

	public static Configurations Instance;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}
}
