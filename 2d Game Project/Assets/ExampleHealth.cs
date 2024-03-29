using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(5);
		}
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
        if(currentHealth < 0) currentHealth = 100;

		healthBar.SetHealth(currentHealth);
	}
}
