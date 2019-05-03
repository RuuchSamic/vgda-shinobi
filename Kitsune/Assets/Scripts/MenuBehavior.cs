using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBehavior : MonoBehaviour
{
    public Transform shurikenSelector;

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

    public void Credits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }

    public void MoveShurikenSelector(RectTransform buttonPosition)
    {

        shurikenSelector.position = new Vector3(shurikenSelector.position.x, 
            buttonPosition.position.y,
           shurikenSelector.position.z);
    }
}
