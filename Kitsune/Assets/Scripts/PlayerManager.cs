using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // this script uses the singleton pattern to ensure that only one instance of this class is made.

    public static  PlayerManager thisInstance;

    public GameObject playerPos; // holds player object
    private AudioSource soundSource;
    public AudioClip growl;

    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
        GameOverBehavior.currentScene = SceneManager.GetActiveScene().name;
    }

    private void Awake()
    {
        if (thisInstance == null)
        {
            thisInstance = this;
        }

    }


    public static void setPlayerPosition(Transform f) // change player's pos
    {
        PlayerMovement.teleportHappened = true;
        thisInstance.playerPos.transform.position = f.position; 
        Debug.Log("PlayerManager teleport = true");

    }


    public static Transform getPlayerPosition() // change player's pos
    {
        return thisInstance.playerPos.transform;
    }

    private void Update()
    {
        if (KillKitsune.KitsuneIsDead)
        {
            KillKitsune.KitsuneIsDead = false;
            SceneManager.LoadScene("gameover");
        }

        if (Enemy.bearDied)
        {
            soundSource.PlayOneShot(growl, 1.0f);
            Enemy.bearDied = false;
        }
    }



}
