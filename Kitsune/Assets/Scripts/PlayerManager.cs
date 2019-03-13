using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static  PlayerManager thisInstance;
    public GameObject playerPos;
    private void Awake()
    {
        if (thisInstance == null)
        {
            thisInstance = this;
        }

    }

    public static void setPlayerPosition(Transform f)
    {
         thisInstance.playerPos.transform.position = f.position;
    }



}
