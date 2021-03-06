﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour, IGameEndReceiver
{
	private bool GoLeft = true;
	private float defaultSpeed;
	private float speed;

	// Use this for initialization
	void Start ()
	{
		defaultSpeed = Configurations.Instance.defaultArrowSpeed;
		speed = defaultSpeed * UpgradeApplier.Instance.GetShooterSpeedMultiplier();		
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (GoLeft == true)
		{
			Vector3 current = transform.rotation.eulerAngles;
			Vector3 next = current + new Vector3(0, 0, speed * Time.deltaTime);
			transform.rotation = Quaternion.Euler(next);
		}
		else if (GoLeft == false)
		{
			Vector3 current = transform.rotation.eulerAngles;
			Vector3 next = current - new Vector3(0, 0, speed * Time.deltaTime);
			transform.rotation = Quaternion.Euler(next);
		}

		if(transform.rotation.eulerAngles.z < 335f && transform.rotation.eulerAngles.z > 330f)
		{
			GoLeft = true;
		}
		else if(transform.rotation.eulerAngles.z > 25f && transform.rotation.eulerAngles.z < 30f)
		{
			GoLeft = false;
		}
	}
}
