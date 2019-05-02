using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiDamageScript : MonoBehaviour
{

    public Enemy enemy;
    public bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (damaged)
        {
            enemy.health -= 5;
            damaged = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            damaged = true;
        }
    }

}
