using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 20f;
    public float curHealth = 0f;
    public bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
        alive = true;

        curHealth = maxHealth;
    }

   
    public void TakeDamage(float amount)
    {
        if (!alive)
        {
            return;
        }
        if (curHealth <= 0)
        {
            curHealth = 0;
            alive = false;
            gameObject.SetActive(false);
        }
        curHealth -= amount;
    }

}
