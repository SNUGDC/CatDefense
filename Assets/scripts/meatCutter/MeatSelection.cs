using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSelection : MonoBehaviour
{
    public Sprite sheep;
    public Sprite duck;
    public Sprite salmon;
    public Sprite cow;
    public Sprite chicken;

    public MeatSpecies? meatSpecies
    {
        get
        {
            return _meatSpecies;
        }
        set
        {
            _meatSpecies = value;
            if (value == null)
            {
                GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = GetSprite(value.Value);
            }
        }
    }

    private CuttingResult? _cuttingResult;
    public CuttingResult? cCuttingResult
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
                return;
            }
            switch (_cuttingResult.Value)
            {
                case CuttingResult.BIG:
                    transform.localScale = 1.3f * Vector3.one;
                    break;
                case CuttingResult.MIDDLE:
                    transform.localScale = 1.0f * Vector3.one;
                    break;
                case CuttingResult.SMALL:
                    transform.localScale = 0.7f * Vector3.one;
                    break;
            }
        }
    }

    private Sprite GetSprite(MeatSpecies meatSpecies)
    {
        switch (meatSpecies)
        {
            case MeatSpecies.Chicken:
                return chicken;
            case MeatSpecies.Cow:
                return cow;
            case MeatSpecies.Duck:
                return duck;
            case MeatSpecies.Salmon:
                return salmon;
            case MeatSpecies.Sheep:
                return sheep;
        }
        Debug.LogError("Cannot find sprite");
        return null;
    }

    private MeatSpecies? _meatSpecies;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // trigger setter
        meatSpecies = meatSpecies;
    }
}
