using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	void Awake() {
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", PlayerPrefs.GetInt ("Score"));
		}
	}

	void Start () {
		scoreText.text = "Distance Traveled: " + PlayerPrefs.GetInt ("Score");
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt ("HighScore");
	}
}
