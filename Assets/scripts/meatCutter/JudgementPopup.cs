using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementPopup : MonoBehaviour
{
    public Sprite perfect;
    public Sprite good;
    public Sprite bad;
	private IEnumerator banishCoroutine;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GetComponent<SpriteRenderer>().sprite = null;
	}
    public void SetJudgementVoid(CuttingJudgement judgement)
    {
		if (banishCoroutine != null)
		{
			StopCoroutine(banishCoroutine);
		}

        Sprite sprite = GetSprite(judgement);
		GetComponent<SpriteRenderer>().sprite = sprite;
		banishCoroutine = BanishCoroutine();
		StartCoroutine(banishCoroutine);
    }

	private IEnumerator BanishCoroutine()
	{
		yield return new WaitForSeconds(0.2f);
		
		GetComponent<SpriteRenderer>().sprite = null;
		banishCoroutine = null;
	}

    private Sprite GetSprite(CuttingJudgement judgement)
    {
        switch (judgement)
        {
            case CuttingJudgement.Perfect:
                return perfect;
            case CuttingJudgement.Good:
                return good;
            case CuttingJudgement.Bad:
                return bad;
        }

        return null;
    }
}
