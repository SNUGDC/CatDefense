using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPiece : MonoBehaviour {

	public float speed;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 greenDir = transform.up;
		transform.position += speed * greenDir;
	}
}
