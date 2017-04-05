using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShooterOutput
{
	void OnShoot();
}

public class MeatShooterShooter : MonoBehaviour, IGameEndReceiver {

	public MeatBullet meatPiece;
	public ShooterOutput shooterOutput;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        MeatBullet newPiece = Instantiate(meatPiece, transform.position, Quaternion.identity) as MeatBullet;
        newPiece.SetMeatPiece(MeatShooter.Instance.meatPiece);
        newPiece.transform.eulerAngles = transform.eulerAngles;
        shooterOutput.OnShoot();
    }
}
