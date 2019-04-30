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
    public GameObject teleProjectile;
    public AudioClip HitWall;
    public AudioClip HitFlesh;

    private Renderer spriteImage;  // renderer variable
    private BoxCollider2D colliderObj;
    private AudioSource SoundSource;

    private void Start()
    {
        SoundSource = GetComponent<AudioSource>();
        spriteImage = GetComponent<SpriteRenderer>(); // gets sprite renderer
        colliderObj = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision) // on collision teleport the player
    {

        if (collision.gameObject.tag != "Player") // make sure object being collided is not player
        {

            if (collision.gameObject.name == "Bear") //  if object hit is an enemy
                                                     // change the enemy's postion to the player's original's position
            {
                collision.transform.position = PlayerMovement.instance.playerTransform.position;//GetComponent<ThrowMechanic>().getinitialShotO; //transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                //Player shuriken hitting flesh noise
                SoundSource.PlayOneShot(HitFlesh, 1.0f);
            }

            else //Shuriken didn't hit flesh so make hit wall noise
            {
                //SoundSource.clip = HitWall;
                Debug.Log("YOU HIT THE WALL");
                SoundSource.PlayOneShot(HitWall, 1.0f);
            }

            PlayerManager.setPlayerPosition(this.transform); // calls the static function of player manager to change
                                                             // the player's position into the position where it collides with
            spriteImage.enabled = false;
            colliderObj.enabled = false;
            Destroy(teleProjectile, 2.0f);
        }
    }
}
