using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualKnifeMoving : MonoBehaviour, IGameEndReceiver
{
	private void Update()
	{
		float defaultSpeed = Configurations.Instance.defaultArrowSpeed;
		float speed = defaultSpeed * UpgradeApplier.Instance.GetShooterSpeedMultiplier();
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
	}
}
