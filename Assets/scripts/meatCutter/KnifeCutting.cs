using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface KnifeCuttingOut
{
    void OnCut(CuttingResult cuttingResult);
}

public class KnifeCutting : MonoBehaviour, IGameEndReceiver
{

    public Transform bigLimit;
    public Transform bigPos;
    public Transform middlePos;
    public Transform smallPos;
    public Transform smallLimit;

    public Transform knife;

    public KnifeCuttingOut cuttingEventOut;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CuttingResult cuttingResult = Cut();
            cuttingEventOut.OnCut(cuttingResult);
        }
    }

    private CuttingResult Cut()
    {
		float bigLimitX = bigLimit.position.x;
		float bigMiddleMedium = Average(bigPos.position.x, middlePos.position.x);
        float middleSmallMedium = Average(middlePos.position.x, smallPos.position.x);
		float smallLimitX = smallLimit.position.x;
        float knifeX = knife.position.x;

		CuttingSize size;
		CuttingJudgement judgement;
        if (knifeX < bigMiddleMedium)
        {
            size = CuttingSize.BIG;
			judgement = Judge(bigLimitX, knifeX, bigMiddleMedium);
        }
        else if (knifeX < middleSmallMedium)
        {
            size = CuttingSize.MIDDLE;
			judgement = Judge(bigMiddleMedium, knifeX, middleSmallMedium);
        }
        else
        {
            size = CuttingSize.SMALL;
			judgement = Judge(middleSmallMedium, knifeX, smallLimitX);
        }

		return new CuttingResult(size, judgement);
    }

    private CuttingSize GetCuttingSize()
    {
        float bigMiddleMedium = Average(bigPos.position.x, middlePos.position.x);
        float middleSmallMedium = Average(middlePos.position.x, smallPos.position.x);
        float knifeX = knife.position.x;
        if (knifeX < bigMiddleMedium)
        {
            return CuttingSize.BIG;
        }
        else if (knifeX < middleSmallMedium)
        {
            return CuttingSize.MIDDLE;
        }
        else
        {
            return CuttingSize.SMALL;
        }
    }

    private CuttingJudgement Judge(float left, float value, float right)
    {
        float length = Mathf.Abs(right - left);
		float middle = Average(left, right);
		float diff = Mathf.Abs(middle - value);
		float diffRatio = diff / (length / 2);

		float defaultPerfectRatio = Configurations.Instance.PerfectRatio;
        float perfectUpgrade = UpgradeApplier.Instance.GetPerfectJudgementAreaAdded();
        float perfectRatio = defaultPerfectRatio + perfectUpgrade;
		if (diffRatio < perfectRatio)
		{
			return CuttingJudgement.Perfect;
		}

		float goodRatio = Configurations.Instance.GoodRatio;
		if (diffRatio < perfectRatio + goodRatio)
		{
			return CuttingJudgement.Good;
		}

		return CuttingJudgement.Bad;
    }

    private float Average(float x1, float x2)
    {
        return (x1 + x2) / 2;
    }
}
