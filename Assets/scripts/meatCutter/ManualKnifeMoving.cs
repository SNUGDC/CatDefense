using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualKnifeMoving : MonoBehaviour
{
	private void Update()
	{
		float defaultSpeed = Configurations.Instance.defaultKnifeSpeed;
		float speed = defaultSpeed * UpgradeApplier.Instance.GetKnifeSpeedMultiplier();
		if(Input.GetKey(KeyCode.C))
		{
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		else if(Input.GetKey(KeyCode.Z))
		{
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
	}
}
