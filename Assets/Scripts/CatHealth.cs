using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

    public int maxLives;
    private int currentLives;

    public GameObject deathSprite;
    private Animator animator;

    public UIScript uiScript;

    public float invincibilityTime;
    private float remainingInvincibiltiyTime;

	void Start () {
        animator = GetComponent<Animator>();
        currentLives = maxLives;
        remainingInvincibiltiyTime = 0.0f;
        UpdateUI();
    }
	
	void Update () {
        remainingInvincibiltiyTime -= Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (remainingInvincibiltiyTime <= 0.0f)
            {
                TakeDamage();
            }
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

        remainingInvincibiltiyTime = invincibilityTime;
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
