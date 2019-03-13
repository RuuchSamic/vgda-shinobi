using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    // NOTE: be sure to set the tag for the player game object and its children as "Player" tag
    // This collision will also check if the shuriken collides with the player itself when teleporting
    // and if you dont set the player's tag to "Player", the player will teleport to itself
    //
    private void OnCollisionEnter2D(Collision2D collision) // on collision teleport the player
    {
        if (collision.gameObject.tag != "Player") // make sure object being collided is not player
        {
            PlayerManager.setPlayerPosition(this.transform); // calls the static function of player manager to change
                                                             // the player's position into the position where it collides with
        }



    }
}
