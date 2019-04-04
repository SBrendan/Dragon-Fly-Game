using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject Level;

    public void PlayGame ()
    {
        Debug.Log("toto");
        Instantiate(Level);
        Destroy(gameObject);
    }

    public void QuitGame ()
    {
        Debug.Log("The user asked to leave the game");
        Application.Quit();
    }
}
