using UnityEngine;
using System.Collections;

public class CatHealth : MonoBehaviour {

    public int maxLives;
    private int currentLives;

    public GameObject deathSprite;

	void Start () {
        currentLives = maxLives;
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentLives--;
        Debug.Log("Current Lives: " + currentLives);
        if (currentLives <= 0)
        {
            Destroy(gameObject);
            Debug.Log("cat died");
        }
    }

    void OnDestroy()
    {
        Instantiate(deathSprite, transform.position, Quaternion.identity);
    }
}
