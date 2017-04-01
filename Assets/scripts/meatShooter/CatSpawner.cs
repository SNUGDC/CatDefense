using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public Transform left;
    public Transform right;
	public Cat catPrefab;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
		// TODO: 웨이브 시작할 때마다 어디선가 불러주는 코드 필요
		StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
		float remainTime = Configurations.Instance.WaveTime;
        while (remainTime > 0)
        {
			SpawnCat();
			float coolTime = MeatShooter.Instance.CurrentWave.defaultCooltime;
			if (remainTime < Configurations.Instance.FeverTime) {
				coolTime = coolTime / 2;
			}
			yield return new WaitForSeconds(coolTime);
			remainTime -= coolTime;
        }
    }

    private void SpawnCat()
    {
        Cat cat = Instantiate(catPrefab) as Cat;
		float x = UnityEngine.Random.Range(left.position.x, right.position.x);
		cat.transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
