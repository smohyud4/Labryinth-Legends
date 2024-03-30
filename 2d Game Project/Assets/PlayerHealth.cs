using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData playerData;
    // [SerializeField ]private float health = 100f;
    // [SerializeField] private float maxHealth = 100f;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerData.health = playerData.maxHealth;
        healthBar.SetMaxHealth(playerData.maxHealth);
        // health = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: When Player gets attacked
         Debug.Log("Current Health: " + playerData.health);

        if (Input.GetKeyDown(KeyCode.Space))
		{
			UpdateHealth(-10);
		}
    }
    public void UpdateHealth(float mod){
        /*trying to use scriptabel object to maintain the players health, 
        /*this allows for the health to be updated in the scriptable object and not the script.
        /* Using a scriptable object will make it easier to transfer data between scenes.
        */
        playerData.health += mod;
        Console.WriteLine(playerData.health);
        if (playerData.health > playerData.maxHealth){
            playerData.health = playerData.maxHealth;
        }
        if (playerData.health <= 0){
            playerData.health = 0f;
        }

        healthBar.SetHealth(playerData.health);


        // health += mod;
        // if (health > maxHealth){
        //     health = maxHealth;
        // }
        // if (health <= 0){
        //     health = 0f;
        //     // Die();
        // }

        // healthBar.SetHealth(health);
    }
}
