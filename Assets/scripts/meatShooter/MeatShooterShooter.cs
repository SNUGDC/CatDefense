using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShooterOutput
{
	void OnShoot();
}

public class MeatShooterShooter : MonoBehaviour {

	public MeatPiece meatPiece;
	public ShooterOutput shooterOutput;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			MeatPiece newPiece = Instantiate(meatPiece, transform.position, Quaternion.identity) as MeatPiece;
			newPiece.meatSpecies = MeatShooter.Instance.meatSpecies.Value;
			newPiece.transform.eulerAngles = transform.eulerAngles;
			shooterOutput.OnShoot();
		}
	}
}
