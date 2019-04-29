using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // this script uses the singleton pattern to ensure that only one instance of this class is made.

    public static  PlayerManager thisInstance;

    public GameObject playerPos; // holds player object

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



}
