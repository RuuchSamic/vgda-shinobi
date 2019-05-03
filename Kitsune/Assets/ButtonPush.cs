using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            gameObject.transform.Translate(Vector2.down  * Time.deltaTime);

            Debug.Log("-----------------------I'm standing on the button--------------------------------------");
        }
    }



}
