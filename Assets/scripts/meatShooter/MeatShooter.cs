using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatShooter : MonoBehaviour {
	private int currentWaveNum = 0;

	public WaveStat CurrentWave {
		get {
			return WaveDB.Instance.Get(currentWaveNum);
		}
	}

	public static MeatShooter Instance;

	public Transform catGoalPoint;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}
}
