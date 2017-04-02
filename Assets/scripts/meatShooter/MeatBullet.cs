using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBullet : MonoBehaviour
{

    public float speed;
    public Vector3 direction;

    private MeatPiece meatPiece;
    public MeatSpecies meatSpecies
    {
        get
        {
            return meatPiece.meatSpecies;
        }
    }
    public CuttingSize meatSize
    {
        get
        {
            return meatPiece.cuttingResult.size;
        }
    }

    public CuttingJudgement meatJudgement
    {
        get
        {
            return meatPiece.cuttingResult.judgement;
        }
    }

    public void SetMeatPiece(MeatPiece meatPiece)
    {
        this.meatPiece = meatPiece;
        GetComponent<MeatPieceSelector>().meatPiece = meatPiece;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 greenDir = transform.up;
        transform.position += speed * greenDir;
    }
}
