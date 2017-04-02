using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualKnifeMoving : MonoBehaviour
{
	private void Update()
	{
		if(Input.GetKey(KeyCode.C))
		{
			transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
		}
		else if(Input.GetKey(KeyCode.Z))
		{
			transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
		}
	}
}
