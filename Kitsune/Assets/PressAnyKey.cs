using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PressAnyKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            LoadScene();
        }
    }

    public void LoadScene() // changes scene to another scene based on name of scene passed
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Kenny's Scene");
    }
}
