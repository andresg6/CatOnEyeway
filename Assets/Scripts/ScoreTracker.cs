using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
    public UIScript mainUi;
    private float timePassed;

    void Start()
    {
        timePassed = 0;
    }
	void Update()
    {
        timePassed += Time.deltaTime;
        mainUi.updateDistanceTraveled(timePassed / 4);
    }

    public void passScore()
    {
        PlayerPrefs.SetInt("Score", Mathf.FloorToInt(timePassed / 4));
    }
}
