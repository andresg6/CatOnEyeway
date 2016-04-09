using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

    public int maxLives;
    private int currentLives;

    public GameObject deathSprite;
    private Animator animator;
    public Text livesCountText;

	void Start () {
        animator = GetComponent<Animator>();
        currentLives = maxLives;
        UpdateUI();
    }
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("DamageTaken");
        currentLives--;
        UpdateUI();
        Debug.Log("Current Lives: " + currentLives);
        if (currentLives <= 0)
        {
            Destroy(gameObject);
            Debug.Log("cat died");
        }
    }

    void UpdateUI()
    {
        livesCountText.text = currentLives.ToString();
    }

    void OnDestroy()
    {
        Instantiate(deathSprite, transform.position, Quaternion.identity);
    }
}
