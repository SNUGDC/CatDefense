using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeatShooter : MonoBehaviour, ShooterOutput, WaveTimeOut, IGameEndReceiver
{
    public WaveStat CurrentWave
    {
        get
        {
            return WaveDB.Instance.Get(GlobalInfo.Instance.currentWave);
        }
    }

    public static MeatShooter Instance;

    public Transform catGoalPoint;
    public Transform catDieLine;
    public SpriteRenderer meatRenderer;
    public MeatShooterShooter shooter;
    public MeatSelection selectedMeatShower;
    public MeatSizeImage selectedMeatSize;
    public MeatPieceSelector meatPieceSelector;

    private MeatPiece _meatPiece;

    public MeatPiece meatPiece
    {
        get
        {
            return _meatPiece;
        }
        set
        {
            _meatPiece = value;
            if (_meatPiece == null)
            {
                meatRenderer.enabled = false;
                shooter.enabled = false;
                selectedMeatShower.meatSpecies = null;
                selectedMeatSize.cuttingSize = null;
                meatPieceSelector.meatPiece = null;
            }
            else
            {
                meatRenderer.enabled = true;
                shooter.enabled = true;
                selectedMeatShower.meatSpecies = _meatPiece.meatSpecies;
                selectedMeatSize.cuttingSize = _meatPiece.cuttingResult.size;
                meatPieceSelector.meatPiece = _meatPiece;
            }
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
        meatPiece = null;
        shooter.shooterOutput = this;

        WaveTimeUI.Instance.input = WaveTime.Instance;
        CatSpawner spawner = FindObjectOfType<CatSpawner>();
        WaveTime.Instance.AddEventListener(spawner);
        WaveTime.Instance.AddEventListener(this);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        WaveTime.Instance.StartWaveTime();
    }

    void ShooterOutput.OnShoot()
    {
        this.meatPiece = null;
    }

    void WaveTimeOut.OnWaveStart()
    {
    }

    void WaveTimeOut.OnFeverTimeStart()
    {
    }

    void WaveTimeOut.OnWaveEnd()
    {
        GlobalInfo.Instance.currentWave += 1;
        GameEnd.Instance.Clear();
    }
}
