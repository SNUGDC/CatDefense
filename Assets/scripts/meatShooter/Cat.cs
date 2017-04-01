using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float speed = 0.03f;
    public MeatSpecies meatSpecies;

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
    }
    // Update is called once per frame
    void Update()
    {
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
        MeatPiece meatPiece = other.GetComponent<MeatPiece>();
        MeatSpecies wantMeat = meatSpecies;
        MeatSpecies givenMeat = meatPiece.meatSpecies;
        if (wantMeat == givenMeat)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
			Debug.Log("Different meat want : " + wantMeat + " given : " + givenMeat);
			Destroy(other.gameObject);
        }
    }
}
