using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour, WaveTimeOut, IGameEndReceiver
{
    public Transform left;
    public Transform right;
    public Cat catPrefab;

    private SpawnRoutine spawnRoutine;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (spawnRoutine != null)
        {
            if (spawnRoutine.CheckSpawn(Time.deltaTime))
            {
                SpawnCat();
            }
        }
    }

    private void SpawnCat()
    {
        Cat cat = Instantiate(catPrefab) as Cat;
        float x = UnityEngine.Random.Range(left.position.x, right.position.x);
        cat.transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void WaveTimeOut.OnWaveStart()
    {
        float defaultCool = MeatShooter.Instance.CurrentWave.defaultCooltime;
        spawnRoutine = new SpawnRoutine(defaultCool);
    }

    void WaveTimeOut.OnFeverTimeStart()
    {
        spawnRoutine.coolTime /= 2;
    }

    void WaveTimeOut.OnWaveEnd()
    {
        spawnRoutine = null;
    }
}

class SpawnRoutine
{
    public float remainCool;
    public float coolTime;

    public SpawnRoutine(float coolTime)
    {
        this.coolTime = coolTime;
    }

    public bool CheckSpawn(float dt)
    {
        remainCool -= dt;
        if (remainCool < 0)
        {
            remainCool = coolTime;
            return true;
        }
        else
        {
            return false;
        }
    }
}