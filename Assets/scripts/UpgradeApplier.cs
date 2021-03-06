﻿using System.Collections;
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
	public float GetShooterSpeedMultiplier()
	{
		return 1.0f + 0.5f * (float)GlobalInfo.Instance.GetShooterUpgradeLevel();
	}

	public float GetPerfectJudgementAreaAdded()
	{
		return 0.1f * GlobalInfo.Instance.GetJudgementUpgradeLevel();
	}

	public float GetCalMovementSlowMultiplier()
	{
		return 1.0f - 0.1f * GlobalInfo.Instance.GetCatSlowUpgradeLevel();
	}

	public float GetPerfectRewardRatioAdded()
	{
		return 0.2f * GlobalInfo.Instance.GetPerfectRewardUpgradeLevel();
	}

	public float GetBadPenaltyRatioAdded()
	{
		return 0.05f * GlobalInfo.Instance.GetBadPanelyUpgradeLevel();
	}

	public float GetMeatPriceMultiplier()
	{
		return 1.0f - 0.1f * GlobalInfo.Instance.GetMeatPriceUpgradeLevel();
	}
}
