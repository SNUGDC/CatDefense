using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomaTouch : MonoBehaviour {
	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		KnifeCutting knifeCutting = FindObjectOfType<KnifeCutting>();
		var clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var prevPos = knifeCutting.transform.position;
		knifeCutting.transform.position = new Vector3(clickedPos.x, prevPos.y, prevPos.z);
		knifeCutting.CutCut();
	}
}
