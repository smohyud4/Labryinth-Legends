using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame

    //Use this to update the enemy health
    public void UpdateHealth(float mod){
        health += mod;
        if (health > 100){
            health = 100;
        }
        if (health <= 0){
            health = 0f;
            Console.WriteLine("Enemy is dead");
        }
    }
}
