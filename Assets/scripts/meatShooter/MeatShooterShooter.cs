using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShooterOutput
{
	void OnShoot();
}

public class MeatShooterShooter : MonoBehaviour {

	public GameObject meatPiece;
	public ShooterOutput shooterOutput;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject newPiece = Instantiate(meatPiece, transform.position, Quaternion.identity) as GameObject;	
			newPiece.transform.eulerAngles = transform.eulerAngles;
			shooterOutput.OnShoot();
		}
	}
}
