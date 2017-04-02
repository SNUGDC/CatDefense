using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WaveTimeOut
{
    void OnWaveStart();
    void OnFeverTimeStart();
    void OnWaveEnd();
}

public interface WaveTimeInput
{
	float? getRemainTime();
}


public class WaveTime : MonoBehaviour, WaveTimeInput
{
    public static WaveTime Instance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }

    private float? remainTime = null;
    private List<WaveTimeOut> outEvent = new List<WaveTimeOut>();

	public void AddEventListener(WaveTimeOut listener)
	{
		outEvent.Add(listener);
	}

    public void StartWaveTime()
    {
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        remainTime = Configurations.Instance.WaveTime;
        outEvent.ForEach(l => l.OnWaveStart());

        float feverTime = Configurations.Instance.FeverTime;
        while (remainTime.Value > feverTime)
        {
            remainTime = remainTime.Value - Time.deltaTime;
            yield return null;
        }

		outEvent.ForEach(l => l.OnFeverTimeStart());

        while (remainTime.Value > 0)
        {
			remainTime = remainTime.Value - Time.deltaTime;
			yield return null;
        }

		remainTime = 0;

        outEvent.ForEach(l => l.OnWaveEnd());

		remainTime = null;
    }

    float? WaveTimeInput.getRemainTime()
    {
        return remainTime;
    }
}
