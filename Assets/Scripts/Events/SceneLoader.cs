using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    //public Player player;

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
        //SAM EDIT: loads scene named MainMenu
        SceneManager.LoadScene("MainMenu");
    }
    public void loadSettingsScene()
    {
        //Loads scene at index 1 (options)
        //SAM EDIT: loads scene named Options
        SceneManager.LoadScene("Options");
    }
    public void loadTestMapScene()
    {

        /*
        //Loads scene at index 2 (test map)
        //SAM EDIT: Resets in game menus and game speed
        if (Player.instance == null)
            Instantiate(player);
        PauseMenu.gameOver = false;
        PauseMenu.gamePaused = false;
        PauseMenu.invOpen = false;
        Time.timeScale = 1f;
        */
        SceneManager.LoadScene(2);
    }

    //SAM EDIT: adding exit game button/method to main menu
    public void MainQuit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
