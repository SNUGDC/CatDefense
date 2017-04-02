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

public class Cat : MonoBehaviour
{

    public List<CatResource> catResources;
    public MeatSelection favorite;
	public MeatSizeImage meatSizeImage;

    public float speed = 0.03f;
    public MeatSpecies meatSpecies;
	public CuttingSize meatSize;

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
		meatSizeImage.cuttingResult = this.meatSize;
    }
    // Update is called once per frame
    void Update()
    {
        Transform target = MeatShooter.Instance.catGoalPoint;
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed;

        if (transform.position.y < MeatShooter.Instance.catDieLine.position.y) {
            Debug.LogError("Game Over");
            SceneManager.LoadScene("Start");
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
            Destroy(gameObject);
            GlobalInfo.Instance.money += 10;
        }
        else
        {
			Debug.Log("Different meat want : " + wantMeat + " given : " + givenMeat);
            Debug.Log("Different meat size want : " + wantSize + " given : " + givenSize);
			Destroy(other.gameObject);
        }
    }
}
