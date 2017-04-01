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

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
