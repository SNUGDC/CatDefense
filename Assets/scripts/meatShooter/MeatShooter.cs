using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatShooter : MonoBehaviour, ShooterOutput {
	private int currentWaveNum = 0;

	public WaveStat CurrentWave {
		get {
			return WaveDB.Instance.Get(currentWaveNum);
		}
	}

	public static MeatShooter Instance;

	public Transform catGoalPoint;
	public SpriteRenderer meatRenderer;
	public MeatShooterShooter shooter;
	public MeatSelection selectedMeatShower;
	public MeatSizeImage selectedMeatSize;
    private MeatPeace _meatPeace;

    public MeatPeace meatPeace {
		get {
			return _meatPeace;
		}
		set {
			_meatPeace = value;
			if (_meatPeace == null) {
				meatRenderer.enabled = false;
				shooter.enabled = false;
				selectedMeatShower.meatSpecies = null;
				selectedMeatSize.cuttingResult = null;
			} else {
				meatRenderer.enabled = true;
				shooter.enabled = true;
				selectedMeatShower.meatSpecies = _meatPeace.meatSpecies;
				selectedMeatSize.cuttingResult = _meatPeace.cuttingResult;
			}
		}
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
		meatPeace = null;
		shooter.shooterOutput = this;
	}

    void ShooterOutput.OnShoot()
    {
        this.meatPeace = null;
    }
}
