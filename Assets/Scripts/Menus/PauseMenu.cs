using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused;
    public static bool invOpen;
    public static bool gameOver;

    public GameObject pauseUI, gameOverUI, invUI;
	
    public void Awake() {
        gamePaused = false;
        invOpen = false;
        gameOver = false;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }else{
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (invOpen)
            {
                ResumeGame();
            }
            else
            {
                Inventory();
            }
        }

        if (gameOver==true)
        {
            GameOver();
        }
        
	}

    public void ResumeGame()
    {
        Debug.Log("game resumed");
        pauseUI.SetActive(false);
        invUI.SetActive(false);
        gamePaused = false;
        invOpen = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Debug.Log("game paused");
        pauseUI.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        Debug.Log("loading main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Inventory()
    {
        Debug.Log("Inventory opened");
        invUI.SetActive(true);
        invOpen = true;

        Time.timeScale = 0.01f;
    }
}
