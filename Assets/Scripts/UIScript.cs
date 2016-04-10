using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    public Text LivesText;
    public Text DistanceText;

    public RectTransform blackout;
    public Text pauseText;
    public RectTransform pausePanel;
    public Button Resume;
    public Button MainMenu;

    private bool isPaused = false;
    private float lastTimescale;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(!isPaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        lastTimescale = Time.timeScale;
        Time.timeScale = 0;
        isPaused = true;

        //Turn on pause UI
        blackout.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(true);
        Resume.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = lastTimescale;
        isPaused = false;

        //Turn off pause UI
        blackout.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
    }
    
    public void updateLives(int newLives)
    {
        LivesText.text = "X " + newLives.ToString();
    }

    public void updateDistanceTraveled(float newDistance)
    {
        DistanceText.text = "Distance Traveled: " + newDistance.ToString("N2") + " Km";
    }
}
