using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatManager : MonoBehaviour
{
    public MeatSelection meatSelection;
    public MeatOnDoma meatOnDoma;
    private MeatSpecies? _meatSpecies;
    private MeatSpecies? meatSpecies
    {
        get
        {
            return _meatSpecies;
        }
        set
        {
            _meatSpecies = value;
            meatSelection.meatSpecies = value;
            if (_meatSpecies == null)
            {
                meatOnDoma.HideMeat();
            }
            else
            {
                meatOnDoma.ShowMeat();
            }
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        meatSpecies = null;
    }

    void Update()
    {
        MeatSpecies? selectedMeat = SelectMeat();
        if (selectedMeat != null)
        {
            meatSpecies = selectedMeat;
        }
    }

    private static MeatSpecies? SelectMeat()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            return MeatSpecies.Sheep;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            return MeatSpecies.Duck;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            return MeatSpecies.Salmon;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            return MeatSpecies.Cow;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            return MeatSpecies.Chicken;
        }
        return null;
    }
}
