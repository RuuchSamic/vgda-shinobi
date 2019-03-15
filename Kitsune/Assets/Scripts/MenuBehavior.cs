using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBehavior : MonoBehaviour
{

    public void LoadScene(string SceneName) // changes scene to another scene based on name of scene passed
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame() // closes the game
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
