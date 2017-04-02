using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimeUI : MonoBehaviour {

	public static WaveTimeUI Instance;

	public Text timeText;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}

	public WaveTimeInput input;
	
	// Update is called once per frame
	void Update () {
		float? remainTime = input.getRemainTime();
		if (remainTime == null) {
			timeText.text = "00:00";
		} else {
			int seconds = (int)remainTime.Value;
			int underSeconds = (int)(remainTime.Value * 100) % 100;
			timeText.text = string.Format("{0:D2}:{1:D2}", seconds, underSeconds);
		}
	}
}
