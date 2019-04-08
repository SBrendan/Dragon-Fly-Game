using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject GameOption;


    public void QuitGame()
    {
        Debug.Log("The user asked to quit game");
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        GameOption.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        GameOption.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}