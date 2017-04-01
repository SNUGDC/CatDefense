using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveDB : MonoBehaviour {
	public List<WaveStat> waveStats;
	public static WaveDB Instance;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}

	public WaveStat Get(int waveNum) {
		if (waveStats.Count >= waveNum) {
			return waveStats.Last();
		}
		return waveStats[waveNum];
	}
}

[System.Serializable]
public class WaveStat
{
	public float defaultCooltime;
}