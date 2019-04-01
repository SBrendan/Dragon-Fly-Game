using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("The user asked to quit game");
        Application.Quit();
    }

    public void ResumeGame()
    {
        Debug.Log("The user asked to resume game");
        SceneManager.LoadScene(1);
    }

    public void OpenGameMenu()
    {
        SceneManager.LoadScene(2);
    }
}
