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
        //SAM EDIT: loads scene named MainMenu
        //removes UI for game settings because I need to prevent object destruction for the settings to work across scenes
        SettingsMenu.settingsOpen = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void loadSettingsScene()
    {
        //Loads scene at index 1 (options)
        //SAM EDIT: loads scene named Options
        SceneManager.LoadScene("Options");
        SettingsMenu.settingsOpen = true;
    }

    public void loadVillageScene()
    {

        /*
        //Loads scene at index 2 (test map)
        //SAM EDIT: Resets in game menus and game speed
        if (Player.instance == null)
            Instantiate(player);
        */
        PauseMenu.gameOver = false;
        PauseMenu.gamePaused = false;
        PauseMenu.invOpen = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Village");
    }

    public void loadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    //SAM EDIT: adding exit game button/method to main menu
    public void MainQuit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
