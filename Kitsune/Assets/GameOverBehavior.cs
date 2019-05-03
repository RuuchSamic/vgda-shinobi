using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverBehavior : MonoBehaviour
{
    public Transform shurikenSelector;
    public static string currentScene;

    private void Start()
    {
        Debug.Log("Player died at this scene: ");
        Debug.Log(currentScene);
    }

    public void LoadScene() // changes scene to the scene where the player died
    {
        Time.timeScale = .5f;
        SceneManager.LoadScene(currentScene);
    }

    public void ExitGame() // closes the game
    {
        Time.timeScale = .5f;
        Application.Quit();
    }

    public void MainMenuScene()
    {
        Time.timeScale = .5f;
        SceneManager.LoadScene("Kenny's Scene");
    }

    public void MoveShurikenSelector(RectTransform buttonPosition)
    {

        shurikenSelector.position = new Vector3(shurikenSelector.position.x,
            buttonPosition.position.y,
           shurikenSelector.position.z);
    }
}
