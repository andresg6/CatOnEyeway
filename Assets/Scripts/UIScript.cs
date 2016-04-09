using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    public Text LivesText;
    public Text DistanceText;
    
    public void updateLives(int newLives)
    {
        LivesText.text = "X " + newLives.ToString();
    }

    public void updateDistanceTraveled(float newDistance)
    {
        DistanceText.text = "Distance Traveled: " + newDistance.ToString("N2") + " Km";
    }
}
