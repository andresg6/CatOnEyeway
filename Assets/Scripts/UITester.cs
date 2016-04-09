using UnityEngine;
using System.Collections;

public class UITester : MonoBehaviour {
    public UIScript mainUI;

    private int lives;
    private float distance;

	// Use this for initialization
	void Start () {
        lives = 10;
        distance = 1200.0f;
        mainUI.updateLives(lives);
        mainUI.updateDistanceTraveled(distance);
	}

    public void IncreaseLives()
    {
        lives++;
        mainUI.updateLives(lives);
    }

    public void DecreaseLives()
    {
        lives--;
        mainUI.updateLives(lives);
    }

    public void IncreaseDistance()
    {
        distance += 100.005f;
        mainUI.updateDistanceTraveled(distance);
    }

    public void DecreaseDistance()
    {
        distance -= 100.005f;
        mainUI.updateDistanceTraveled(distance);
    }
}
