using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSizeImage : MonoBehaviour
{
    public Sprite big;
    public Sprite middle;
    public Sprite small;

    private CuttingResult? _cuttingResult;
    public CuttingResult? cuttingResult
    {
        get
        {
            return _cuttingResult;
        }
        set
        {
            _cuttingResult = value;
            if (_cuttingResult == null)
            {
                GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = GetSprite();
            }
        }
    }

    private Sprite GetSprite()
    {
        switch (_cuttingResult.Value)
        {
            case CuttingResult.BIG:
                return big;
            case CuttingResult.MIDDLE:
                return middle;
            case CuttingResult.SMALL:
                return small;
        }
		
		return null;
    }
}
