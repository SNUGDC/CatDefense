using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatManager : MonoBehaviour
{
	public MeatSelection meatSelection;

    void Update()
    {
		MeatSpecies? selectedMeat = SelectMeat();
		if (selectedMeat != null) {
			meatSelection.meatSpecies = selectedMeat;
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
