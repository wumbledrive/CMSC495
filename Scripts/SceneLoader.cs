using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void loadNextScene()
    {
        //Set current scene using Unity's scene loader
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Loads next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void loadMainMenuScene()
    {
        //Loads scene at index 0 (main menu)
        SceneManager.LoadScene(0);
    }
    public void loadSettingsScene()
    {
        //Loads scene at index 1 (options)
        SceneManager.LoadScene(1);
    }
    public void loadTestMapScene()
    {
        //Sam EDIT: resets game over, paused, or inventory open status when new game is selected, I'll get the scene itself resetting soon
        Time.timeScale = 1;
        PauseMenu.gameOver = false;
        PauseMenu.gamePaused = false;
        PauseMenu.invOpen = false;
        //Loads scene at index 2 (test map)
        SceneManager.LoadScene(2);
    }
}
