using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSizeImage : MonoBehaviour
{
    public Sprite big;
    public Sprite middle;
    public Sprite small;

    private CuttingSize? _cuttingResult;
    public CuttingSize? cuttingResult
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
            case CuttingSize.BIG:
                return big;
            case CuttingSize.MIDDLE:
                return middle;
            case CuttingSize.SMALL:
                return small;
        }
		
		return null;
    }
}
