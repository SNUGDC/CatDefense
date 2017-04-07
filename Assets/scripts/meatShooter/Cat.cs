using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CatResource
{
    public Sprite sprite;
    public MeatSpecies meatSpecies;
}

public class Cat : MonoBehaviour, IGameEndReceiver
{

    public List<CatResource> catResources;
    public MeatSelection favorite;
	public MeatSizeImage meatSizeImage;
    public GameObject heartEffect;

    public float speed = 0.03f;
    public MeatSpecies meatSpecies;
	public CuttingSize meatSize;

    bool willDestroy;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        int randomIndex = Random.Range(0, catResources.Count);
        CatResource catResource = catResources[randomIndex];
        this.meatSpecies = catResource.meatSpecies;
        favorite.meatSpecies = this.meatSpecies;
        this.GetComponent<SpriteRenderer>().sprite = catResource.sprite;

		List<CuttingSize> allCuttingResults = new List<CuttingSize> {
			CuttingSize.BIG, CuttingSize.MIDDLE, CuttingSize.SMALL
		};
		this.meatSize = allCuttingResults[Random.Range(0, allCuttingResults.Count)];
		meatSizeImage.cuttingSize = this.meatSize;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Cats.Instance.cats.Add(this);
        heartEffect.SetActive(false);
        willDestroy = false;
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Cats.Instance.cats.Remove(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (willDestroy) return;
        Transform target = MeatShooter.Instance.catGoalPoint;
        Vector3 direction = (target.position - transform.position).normalized;
        float slowMultiplier = UpgradeApplier.Instance.GetCalMovementSlowMultiplier();
        transform.position += direction * speed * slowMultiplier;

        if (transform.position.y < MeatShooter.Instance.catDieLine.position.y) {
            Debug.LogError("Game Over");
            GameEnd.Instance.Fail();
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        MeatBullet meatPiece = other.GetComponent<MeatBullet>();
        MeatSpecies wantMeat = meatSpecies;
        MeatSpecies givenMeat = meatPiece.meatSpecies;
        CuttingSize wantSize = meatSize;
        CuttingSize givenSize = meatPiece.meatSize;
        if (wantMeat == givenMeat && wantSize == givenSize)
        {
            Destroy(other.gameObject);
            GetComponent<Collider2D>().enabled = false;
            transform.FindChild("Bubble").gameObject.SetActive(false);
            transform.FindChild("favorite").gameObject.SetActive(false);
            transform.FindChild("size").gameObject.SetActive(false);
            willDestroy = true;
            heartEffect.SetActive(true);
            Destroy(gameObject, 0.5f);
            Destroy(this);
            float reward = Configurations.Instance.GoodReward;
            if (meatPiece.meatJudgement == CuttingJudgement.Perfect) {
                float perfectRewardMultiplier = UpgradeApplier.Instance.GetPerfectRewardRatioAdded();
                reward *= (Configurations.Instance.PerfectReward + perfectRewardMultiplier);
            } else if (meatPiece.meatJudgement == CuttingJudgement.Bad) {
                float badPenaltyRewardAdded = UpgradeApplier.Instance.GetBadPenaltyRatioAdded();
                reward *= (Configurations.Instance.BadReward + badPenaltyRewardAdded);
            }
            GlobalInfo.Instance.money += (int)reward;
        }
        else
        {
			Debug.Log("Different meat want : " + wantMeat + " given : " + givenMeat);
            Debug.Log("Different meat size want : " + wantSize + " given : " + givenSize);
			Destroy(other.gameObject);
        }
    }
}
