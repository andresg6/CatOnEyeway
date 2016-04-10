using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
    public UIScript mainUi;
    public float secondsToKilometer = 4;
    public float scoreMultiplier = 4;
    private float timePassed;
    private bool isWorking = true;

    void Start()
    {
        timePassed = 0;
    }
	void Update()
    {
        if (isWorking)
        {
            timePassed += Time.deltaTime;
            mainUi.updateDistanceTraveled(timePassed / secondsToKilometer);
        }
    }

    public float getCurrentScore()
    {
        return timePassed / secondsToKilometer;
    }
       

    public void passScore()
    {
        PlayerPrefs.SetInt("Score", Mathf.FloorToInt(timePassed * scoreMultiplier));
        isWorking = false;
    }
}
