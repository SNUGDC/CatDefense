using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeatResourcePerSize
{
    public Sprite big;
    public Sprite middle;
    public Sprite small;
}

public class MeatPieceSelector : MonoBehaviour
{

    public MeatResourcePerSize chickenResource;
    public MeatResourcePerSize duckResource;
    public MeatResourcePerSize salmonResource;
    public MeatResourcePerSize cowResource;
    public MeatResourcePerSize lambResource;

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
            UpdateResource();
        }
    }

    private void UpdateResource()
    {
        GetComponent<SpriteRenderer>().sprite = GetSprite(_meatPiece);
    }

    private Sprite GetSprite(MeatPiece meatPiece)
    {
		if (meatPiece == null)
		{
			return null;
		}

        MeatResourcePerSize resourcePerSize = null;
        switch (meatPiece.meatSpecies)
        {
            case MeatSpecies.Chicken:
                resourcePerSize = chickenResource;
                break;
            case MeatSpecies.Cow:
                resourcePerSize = cowResource;
                break;
            case MeatSpecies.Duck:
                resourcePerSize = duckResource;
                break;
            case MeatSpecies.Salmon:
                resourcePerSize = salmonResource;
                break;
            case MeatSpecies.Sheep:
                resourcePerSize = lambResource;
                break;
        }

        switch (meatPiece.cuttingResult)
        {
            case CuttingResult.BIG:
                return resourcePerSize.big;
            case CuttingResult.MIDDLE:
                return resourcePerSize.middle;
            case CuttingResult.SMALL:
                return resourcePerSize.small;
        }

        return null;
    }
}
