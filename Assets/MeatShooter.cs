using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatShooter : MonoBehaviour {

	public GameObject meatPiece;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject newPiece = Instantiate(meatPiece, transform.position, Quaternion.identity) as GameObject;	
			newPiece.transform.eulerAngles = transform.eulerAngles;
		}
	}
}
