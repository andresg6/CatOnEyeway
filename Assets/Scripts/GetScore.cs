using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

	public int score; // score from the game that just ended

	public Text scoreText;
	public Text highScoreText;

	void Awake() {
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}

	void Start () {
		scoreText.text = "Distance Traveled: " + score;
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt ("HighScore");
	}
}
