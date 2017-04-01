using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 current = transform.rotation.eulerAngles;
			Vector3 next = current + new Vector3(0,0,speed);
			transform.rotation = Quaternion.Euler(next);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 current = transform.rotation.eulerAngles;
			Vector3 next = current - new Vector3(0,0,speed);
			transform.rotation = Quaternion.Euler(next);
		}
	}
}
