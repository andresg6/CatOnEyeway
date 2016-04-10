using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	void Awake() {
		if (PlayerPrefs.GetFloat ("Score") > PlayerPrefs.GetFloat ("HighScore")) {
			PlayerPrefs.SetFloat ("HighScore", PlayerPrefs.GetFloat ("Score"));
		}
	}

	void Start () {
		scoreText.text = "Distance Traveled: " + (PlayerPrefs.GetFloat ("Score")).ToString("N2") + " Km";
		highScoreText.text = "High Score: " + PlayerPrefs.GetFloat ("HighScore").ToString("N2") + " Km";
	}
}
