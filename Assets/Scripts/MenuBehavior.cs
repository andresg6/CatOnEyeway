using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	public GameObject mainButtons;
	public GameObject instructions;
	public GameObject credits;

	public GameObject cat;
	public GameObject laser;

	void Start () {
		ShowMain ();
	}
	
	public void ShowInstructions() {
		mainButtons.SetActive (false);
		instructions.SetActive (true);
		credits.SetActive (false);

		cat.SetActive (false);
		laser.SetActive (false);
	}

	public void ShowCredits() {
		mainButtons.SetActive (false);
		instructions.SetActive (false);
		credits.SetActive (true);

		cat.SetActive (true);
		laser.SetActive (true);
	}

	public void ShowMain() {
		mainButtons.SetActive (true);
		instructions.SetActive (false);
		credits.SetActive (false);

		cat.SetActive (true);
		laser.SetActive (true);
	}
}
