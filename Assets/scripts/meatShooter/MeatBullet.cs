using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBullet : MonoBehaviour
{

    public float speed;
    public Vector3 direction;

    private MeatPeace meatPeace;
    public MeatSpecies meatSpecies
    {
        get
        {
            return meatPeace.meatSpecies;
        }
    }
    public CuttingResult meatSize
    {
        get
        {
            return meatPeace.cuttingResult;
        }
    }

	public void SetMeatPeace(MeatPeace meatPeace)
	{
		this.meatPeace = meatPeace;
		GetComponent<MeatPeaceSelector>().meatPeace = meatPeace;
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 greenDir = transform.up;
        transform.position += speed * greenDir;
    }
}
