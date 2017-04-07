using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{
    public MeatSpecies meatSpecies;
    public List<MEventComponent> onSelectMeat;

    public void Open()
    {
        onSelectMeat.ForEach(e => e.Fire());
    }

    void OnMouseDown()
    {
        FindObjectOfType<MeatManager>().OnSelectMeat(meatSpecies);
    }
}
