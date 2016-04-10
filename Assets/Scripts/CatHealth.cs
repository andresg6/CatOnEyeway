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

	private Collider2D collided;

	void Start () {

        animator = GetComponent<Animator>();
        mainCam = FindObjectOfType<MainCameraController>();
        currentLives = maxLives;
        remainingInvincibiltiyTime = 0.0f;
        UpdateUI();
    }
	
	void Update () {
        remainingInvincibiltiyTime -= Time.deltaTime;

		//test
		if (remainingInvincibiltiyTime <= 0 && collided) {
			//Physics2D.IgnoreLayerCollision (1, 0, false);
			Physics2D.IgnoreCollision(collided, this.GetComponent<Collider2D>(), false);
		}

		//endtest
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (remainingInvincibiltiyTime <= 0.0f)
            {
				collided = collision.collider;
				Physics2D.IgnoreCollision(collided, this.GetComponent<Collider2D>(),true);
                TakeDamage();

            }
        }
    }

    void TakeDamage()
    {
        Debug.Log("taking damage");
		meow.Play ();
        
        currentLives--;
		if (currentLives > 0) {	//test1
			animator.SetTrigger ("DamageTaken");
		}
        Debug.Log(currentLives);
        UpdateUI();
        if (currentLives <= 0)
        {
			animator.SetTrigger ("Dead");	//test1
            uiScript.EndGame();
            Destroy(gameObject,2);	//test1
        }
        if (mainCam) { mainCam.addScreenShake(10); }
        remainingInvincibiltiyTime = invincibilityTime;

		//test

		Debug.Log (Physics2D.GetIgnoreCollision (collided, this.GetComponent < Collider2D>()));

    }

    void UpdateUI()
    {
        uiScript.updateLives(currentLives);
    }

}
