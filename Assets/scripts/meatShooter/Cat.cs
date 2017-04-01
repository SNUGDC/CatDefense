using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {
	
	public float speed = 0.03f;
	// Update is called once per frame
	void Update () {
		Transform target = MeatShooter.Instance.catGoalPoint;
		Vector3 direction = (target.position - transform.position).normalized;
		transform.position += direction * speed;
	}
}
