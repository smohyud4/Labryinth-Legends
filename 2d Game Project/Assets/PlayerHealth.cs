using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField ]private float health = 100f;
    [SerializeField] private float maxHealth = 100f;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: When Player gets attacked

        if (Input.GetKeyDown(KeyCode.Space))
		{
			UpdateHealth(-10);
		}
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

        healthBar.SetHealth(health);
    }
}
