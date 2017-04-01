using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCutting : MonoBehaviour {

	public Transform bigLimit;
	public Transform bigPos;
	public Transform middlePos;
	public Transform smallPos;
	public Transform smallLimit;

	public Transform knife;

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			CuttingResult cuttingResult = Cut();
			Debug.Log("Cutting result is " + cuttingResult);
		}
	}

    private CuttingResult Cut()
    {
		float bigMiddleMedium = Average(bigPos.position.x, middlePos.position.x);
		float middleSmallMedium = Average(middlePos.position.x, smallPos.position.x);
		float knifeX = knife.position.x;
		if (knifeX < bigMiddleMedium) {
			return CuttingResult.BIG;
		} else if (knifeX < middleSmallMedium) {
			return CuttingResult.MIDDLE;
		} else {
			return CuttingResult.SMALL;
		}
    }

    private float Average(float x1, float x2)
    {
        return (x1 + x2) / 2;
    }
}
