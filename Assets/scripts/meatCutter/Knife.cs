using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IGameEndReceiver {
	public Transform left;
	public Transform right;
	public float period = 1.0f;

	public enum Direction {
		Left,
		Right
	}

	private Direction direction = Direction.Left;

	// Use this for initialization
	void Start () {
		StartCoroutine(move());	
	}

	IEnumerator move()
	{
		while (GameEnd.Instance.isGameEnd == false)
        {
            if (IsLeftReached()) {
				direction = Direction.Right;
			} else if (IsRightReached()) {
				direction = Direction.Left;
			}

			Vector3 leftToRight = (right.position.x - left.position.x) * Vector3.right;
			if (direction == Direction.Left) {
				transform.position += -1 * leftToRight * (Time.deltaTime / period);
			} else if (direction == Direction.Right) {
				transform.position += leftToRight * (Time.deltaTime / period);
			}

            yield return null;
        }
    }

    private bool IsRightReached()
    {
        if (direction == Direction.Right) {
			if (transform.position.x > right.position.x) {
				return true;
			}
		}
		return false;
    }

    private bool IsLeftReached()
    {
        if (direction == Direction.Left)
        {
            if (transform.position.x < left.position.x)
            {
                return true;
            }
        }
		return false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
