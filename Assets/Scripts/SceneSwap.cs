using UnityEngine;
using System.Collections;

public class SceneSwap : MonoBehaviour {
    public int MenuScene = 0;
    public int GameScene = 1;
    public int OverScene = 2; 
	
	public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MenuScene);
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameScene);
    }

    public void LoadGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(OverScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
