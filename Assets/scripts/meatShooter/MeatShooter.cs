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

	private MeatSpecies? _meatSpecies;
	public MeatSpecies? meatSpecies {
		get {
			return _meatSpecies;
		}
		set {
			_meatSpecies = value;
			if (_meatSpecies == null) {
				meatRenderer.enabled = false;
				shooter.enabled = false;
				selectedMeatShower.meatSpecies = null;
			} else {
				meatRenderer.enabled = true;
				shooter.enabled = true;
				selectedMeatShower.meatSpecies = _meatSpecies;
			}
		}
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
		meatSpecies = null;
		shooter.shooterOutput = this;
	}

    void ShooterOutput.OnShoot()
    {
        this.meatSpecies = null;
    }
}
