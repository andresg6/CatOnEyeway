using UnityEngine;
using System.Collections;

public class CatHealth : MonoBehaviour {

    public int maxLives;
    private int currentLives;

    public GameObject deathSprite;
    public Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
        currentLives = maxLives;
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("DamageTaken");
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
