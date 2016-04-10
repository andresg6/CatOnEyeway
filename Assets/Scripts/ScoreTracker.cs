﻿using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
    public UIScript mainUi;
    public float secondsToKilometer = 4;
    public float scoreMultiplier = 4;
    private float timePassed;

    void Start()
    {
        timePassed = 0;
    }
	void Update()
    {
        timePassed += Time.deltaTime;
        mainUi.updateDistanceTraveled(timePassed / secondsToKilometer);
    }

    public void passScore()
    {
        PlayerPrefs.SetInt("Score", Mathf.FloorToInt(timePassed * scoreMultiplier));
    }
}