using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

    public int maxLives;
    private int currentLives;

    private Animator animator;
    private MainCameraController mainCam;

    public UIScript uiScript;

    public float invincibilityTime;
    private float remainingInvincibiltiyTime;

	public AudioSource meow;

	void Start () {
        animator = GetComponent<Animator>();
        mainCam = FindObjectOfType<MainCameraController>();
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
        Debug.Log("taking damage");
		meow.Play ();
        animator.SetTrigger("DamageTaken");
        currentLives--;
        Debug.Log(currentLives);
        UpdateUI();
        if (currentLives <= 0)
        {
            uiScript.EndGame();
            Destroy(gameObject);
        }
        if (mainCam) { mainCam.addScreenShake(10); }
        remainingInvincibiltiyTime = invincibilityTime;
    }

    void UpdateUI()
    {
        uiScript.updateLives(currentLives);
    }

}
