using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField ]private float health = 100f;
    [SerializeField] private float maxHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void UpdateHealth(float mod){
        health += mod;
        if (health > maxHealth){
            health = maxHealth;
        }
        if (health <= 0){
            health = 0f;
            // Die();
        }
    }
}
