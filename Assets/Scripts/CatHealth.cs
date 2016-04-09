using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

    public int maxLives;
    private int currentLives;

    public GameObject deathSprite;
    private Animator animator;

    public UIScript uiScript;

	void Start () {
        animator = GetComponent<Animator>();
        currentLives = maxLives;
        UpdateUI();
    }
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        animator.SetTrigger("DamageTaken");
        currentLives--;
        UpdateUI();
        if (currentLives <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateUI()
    {
        uiScript.updateLives(currentLives);
    }

    void OnDestroy()
    {
        Instantiate(deathSprite, transform.position, Quaternion.identity);
    }
}
