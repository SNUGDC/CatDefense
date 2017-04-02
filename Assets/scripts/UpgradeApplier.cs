using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeApplier : MonoBehaviour {
	public static UpgradeApplier Instance;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}
	public float GetKnifeSpeedMultiplier()
	{
		return 1.0f + 0.2f * (float)GlobalInfo.Instance.GetKnifeUpgradeLevel();
	}
}
