﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToriiScript : MonoBehaviour
{
    public string nextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Player has left the stage!");
            SceneManager.LoadScene(nextScene);
        }
    }
}
