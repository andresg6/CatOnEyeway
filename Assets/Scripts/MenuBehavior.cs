using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	public GameObject mainButtons;
	public GameObject instructions;
	public GameObject credits;

	void Start () {
		ShowMain ();
	}
	
	public void ShowInstructions() {
		mainButtons.SetActive (false);
		instructions.SetActive (true);
		credits.SetActive (false);
	}

	public void ShowCredits() {
		mainButtons.SetActive (false);
		instructions.SetActive (false);
		credits.SetActive (true);
	}

	public void ShowMain() {
		mainButtons.SetActive (true);
		instructions.SetActive (false);
		credits.SetActive (false);
	}
}
